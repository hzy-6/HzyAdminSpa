using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SysClass
{
    using Toolkit;
    using Logic.Class;
    using Entitys.SysClass;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Http;

    public class AccountLogic : BaseLogic
    {

        /// <summary>
        /// 账号检查
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <param name="loginCode"></param>
        public async Task<string> CheckedAsync(string uName, string uPwd, string loginCode)
        {
            if (string.IsNullOrEmpty(uName)) throw new MessageBox("请输入用户名");
            if (string.IsNullOrEmpty(uPwd)) throw new MessageBox("请输入密码");
            //if (string.IsNullOrEmpty(loginCode)) throw new MessageBox("请输入验证码");

            var _Sys_User = await db.FindAsync<Sys_User>(w => w.t1.User_LoginName == uName);

            if (_Sys_User.User_ID.ToGuid() == Guid.Empty) throw new MessageBox("用户不存在");
            //Tools.MD5Encrypt(userpwd)))//
            if (_Sys_User.User_Pwd.ToStr().Trim() != uPwd) throw new MessageBox("密码错误");
            //string code = Tools.GetCookie("loginCode");
            //if (string.IsNullOrEmpty(code)) throw new MessageBox("验证码失效");
            //if (!code.ToLower().Equals(loginCode.ToLower())) throw new MessageBox("验证码不正确");

            return new JwtTokenUtil().GetToken(_Sys_User.User_ID.ToStr());
        }

        /// <summary>
        /// 根据用户信息获取 Account 对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountByUserId(Guid Id)
        {
            var _Sys_User = await db.FindByIdAsync<Sys_User>(Id);
            var _Account = new Account();
            var _Sys_UserRole = await db.Query<Sys_UserRole>(w => w.t1.UserRole_UserID == _Sys_User.User_ID).ToListAsync();
            //
            _Account.RoleIDList = _Sys_UserRole.Select(w => w.UserRole_RoleID.ToGuid()).ToList();
            _Account.UserID = _Sys_User.User_ID.ToGuid();
            _Account.UserName = _Sys_User.User_Name;
            _Account._Sys_User = _Sys_User;
            //如果是超级管理员 帐户
            _Account.IsSuperManage = _Sys_UserRole.Any(w => w.UserRole_RoleID == AppConfig.Admin_RoleID.ToGuid());
            return _Account;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldpwd"></param>
        /// <param name="newpwd"></param>
        /// <param name="newlypwd"></param>
        public async Task ChangePwd(string oldpwd, string newpwd, string newlypwd)
        {
            if (string.IsNullOrEmpty(oldpwd)) throw new MessageBox("旧密码不能为空");
            if (string.IsNullOrEmpty(newpwd)) throw new MessageBox("新密码不能为空");
            if (string.IsNullOrEmpty(newlypwd)) throw new MessageBox("重复新密码不能为空");
            if (newpwd != newlypwd) throw new MessageBox("两次密码不一致");
            var _Sys_User = await db.FindByIdAsync<Sys_User>(_Account.UserID);
            if (_Sys_User.User_Pwd != oldpwd) throw new MessageBox("旧密码不正确");
            await db.UpdateAsync(() => new Sys_User { User_Pwd = newlypwd }, w => w.t1.User_ID == _Account.UserID);
        }

        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="_HttpContext"></param>
        /// <param name="UserID"></param>
        public static void InsertAppLog(HttpContext _HttpContext, Guid UserID)
        {
            var _QueryString = _HttpContext.Request.QueryString.ToString();
            var _ApiUrl = _HttpContext.Request.Path + _QueryString;
            var _IP = _HttpContext.Connection.RemoteIpAddress.ToString();
            var _FormJson = string.Empty;

            //if (_IP == "::1") return;

            try
            {
                var _Form = _HttpContext.Request.Form;
                var _Dictionary = new Dictionary<string, object>();

                foreach (var key in _Form.Keys)
                {
                    _Dictionary[key] = _Form[key];
                }

                _FormJson = JsonConvert.SerializeObject(_Dictionary);
            }
            catch (Exception) { }

            db.Insert(new Sys_AppLog
            {
                AppLog_Api = _ApiUrl,
                AppLog_IP = _IP,
                AppLog_Parameter = _FormJson,
                AppLog_UserID = UserID
            });
        }




    }
}
