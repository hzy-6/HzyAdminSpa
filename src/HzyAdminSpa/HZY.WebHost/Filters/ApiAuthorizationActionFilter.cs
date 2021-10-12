using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using HZY.Services.Admin.Framework;
using HZY.Services.Accounts;
using HZY.Infrastructure.Permission.Attributes;
using HZY.Infrastructure;
using HZY.Infrastructure.ApiResultManage;
using System.Linq;
using System;

namespace HZY.WebHost.Filters;

/// <summary>
/// 后台 权限 管理 控制
/// </summary>
public class ApiAuthorizationActionFilter : IActionFilter
{
    private readonly SysMenuService _sysMenuService;
    private readonly IAccountService _accountService;

    public ApiAuthorizationActionFilter(SysMenuService sysMenuService, IAccountService accountService)
    {
        _sysMenuService = sysMenuService;
        _accountService = accountService;
    }

    /// <summary>
    /// Action 执行前
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnActionExecuting(ActionExecutingContext context)
    {
        var routeValues = context.ActionDescriptor.RouteValues;
        //var areaName = routeValues["area"];
        var controllerName = routeValues["controller"];
        var actionName = routeValues["action"];

        #region 拦截操作数据库的 接口 方便发布线上演示

        //拦截操作数据库的 接口

        //var actionList = new[] { "SaveForm", "DeleteList", "ChangePassword" };
        //if (actionList.Any(w => w.ToLower() == actionName.ToLower()))
        //{
        //    MessageBox.Show("请下载源代码本地运行!");
        //}

        #endregion

        var controller = (ControllerBase)context.Controller;
        //获取 class 上面所有的 自定义 特性
        var customAttributes = controller.GetType().GetCustomAttributes();
        //处理 控制器 class 上面 带有 ControllerDescriptorAttribute 标记
        var adminApiDescribeAttribute = (ControllerDescriptorAttribute)customAttributes
            .FirstOrDefault(w => w is ControllerDescriptorAttribute);
        if (adminApiDescribeAttribute == null) return;

        var httpContext = context.HttpContext;
        const string unAuthMessage = "未授权,请先登录授权!";

        #region 检查是否登录 授权

        if (this._accountService.GetAccountInfo() == null)
        {
            var data = ApiResult.ResultMessage(ApiResultCodeEnum.UnAuth, unAuthMessage);
            context.Result = new JsonResult(data);
        }

        #endregion

        var menuId = adminApiDescribeAttribute.GetMenuId().ToGuid();
        var actionDescriptorAttribute = (ActionDescriptorAttribute)context.ActionDescriptor.EndpointMetadata
            .FirstOrDefault(w => w is ActionDescriptorAttribute);

        #region 检查页面权限信息

        if (menuId == Guid.Empty) return;

        if (actionDescriptorAttribute == null) return;

        var functionName = actionDescriptorAttribute.GetFunctionName();
        //收集用户权限 未授权让他重新登录
        var power = this._sysMenuService.GetPowerStateByMenuId(menuId).Result;

        if (power.ContainsKey(functionName) && !power[functionName])
        {
            var data = ApiResult.ResultMessage(ApiResultCodeEnum.UnAuth, unAuthMessage);
            context.Result = new JsonResult(data);
        }

        #endregion

        //LogUtil.Write("OnActionExecuting");
    }

    /// <summary>
    /// Action 执行后
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnActionExecuted(ActionExecutedContext context)
    {
        // LogUtil.Write("OnActionExecuted");
    }
}