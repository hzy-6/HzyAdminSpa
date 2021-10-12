using HZY.Infrastructure;
using HZY.Infrastructure.ScanDIService.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZY.Infrastructure.Token;

/// <summary>
/// token 服务
/// </summary>
public class TokenService : IDITransientSelf
{
    private readonly AppConfiguration _appConfiguration;
    private readonly HttpContext _httpContext;

    public TokenService(AppConfiguration appConfiguration, IHttpContextAccessor httpContextAccessor)
    {
        _appConfiguration = appConfiguration;
        _httpContext = httpContextAccessor.HttpContext;
    }

    /// <summary>
    /// 根据 id 创建token
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string CreateTokenByAccountId(Guid id)
    {
        return JwtTokenUtil.CreateToken(id.ToString(), this._appConfiguration.JwtSecurityKey, this._appConfiguration.JwtKeyName);
    }

    /// <summary>
    /// 获取 token 并得到 id
    /// </summary>
    /// <returns></returns>
    public Guid GetAccountIdByToken()
    {
        if (this._httpContext == null)
        {
            return Guid.Empty;
        }

        var token = this._httpContext.Request.Headers[this._appConfiguration.AuthorizationKeyName].ToString();

        if (string.IsNullOrWhiteSpace(token))
        {
            return default;
        }

        if (this._httpContext.User.Identity == null)
        {
            return default;
        }

        //var id = JwtTokenUtil.ReadJwtToken(token).ToGuid();

        return this._httpContext.User.Identity.Name.ToGuid();
    }

}