using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.AppService
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Security.Claims;
    using Toolkit;
    using Logic.SysClass;

    /// <summary>
    /// Action 拦截验证授权码
    /// </summary>
    public class ApiCheckTokenFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 忽略本特性
        /// </summary>
        public bool Ignore { get; set; } = false;

        /// <summary>
        /// 每次请求Action之前发生，，在行为方法执行前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (Ignore) return;

            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                throw new MessageBox(new { status = EMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{EMessageBoxStatus.接口授权码无效.ToString()}" });

            //得到 jwt 信息
            var _Controller = context.Controller as Admin.Controllers.Admin.AdminBaseController;
            if (_Controller == null)
                throw new MessageBox(new { status = EMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{EMessageBoxStatus.接口授权码无效.ToString()}" });
            var _ClaimsIdentity = _Controller.User.Identity as ClaimsIdentity;

            var _Id = _ClaimsIdentity.Name;

            if (_Id.ToGuid() == Guid.Empty)
                throw new MessageBox(new { status = EMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{EMessageBoxStatus.接口授权码无效.ToString()}" });

            var _AccountLogic = new AccountLogic();

            //这里对你 _Controller  里面的 用户变量赋值
            _Controller._Account = _AccountLogic.GetAccountByUserId(_Id.ToGuid()).Result;
            AccountLogic.InsertAppLog(context.HttpContext, _Id.ToGuid());

        }


    }

    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class AppExceptionFilter : IExceptionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnException(ExceptionContext context)
        {
            var _Exception = context.Exception;
            if (_Exception is MessageBox _Error)
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 200;

                if (_Error.Model.status == (int)EMessageBoxStatus.自定义)
                    context.Result = new JsonResult(_Error.Model.msg);
                else
                    context.Result = new JsonResult(_Error.Model);
            }
            else
            {
                Tools.Log.Write(_Exception, context.HttpContext.Connection.RemoteIpAddress.ToString());//nlog 写入日志到 txt
                var _MessageBoxModel = new MessageBoxModel($"服务端出现异常![异常消息：{_Exception.Message}]", EMessageBoxStatus.服务端异常);
                context.Result = new JsonResult(_MessageBoxModel);
            }
        }
    }



}
