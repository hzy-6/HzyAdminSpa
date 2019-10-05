using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers.Admin
{
    using AppService;
    using Logic.SysClass;

    /// <summary>
    /// 授权 获取 token
    /// </summary>
    [ApiExplorerSettings(GroupName = nameof(ApiVersionsEnum.Admin))]
    [Route("Admin/[controller]")]
    public class AuthorizationController : ApiBaseController
    {

        protected AccountLogic _Logic = new AccountLogic();

        /// <summary>
        /// 检查帐户并获取 token
        /// </summary>
        /// <param name="UserName">用户名称</param>
        /// <param name="UserPassword">用户密码</param>
        /// <param name="LoginCode">验证码(不填)</param>
        /// <returns></returns>
        [HttpPost(nameof(Check))]
        public async Task<IActionResult> Check(string UserName, string UserPassword, string LoginCode)
        {
            var _Toekn = await _Logic.CheckedAsync(UserName, UserPassword, LoginCode);

            var _TokenType = "Bearer ";

            return this.Json(new
            {
                status = 1,
                token = _TokenType + _Toekn,
                tokenType = _TokenType
            });
        }

    }
}