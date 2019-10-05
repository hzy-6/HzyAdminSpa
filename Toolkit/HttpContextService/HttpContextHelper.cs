namespace Toolkit.HttpContextService
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// HttpContext注入类
    /// </summary>
    public static class HttpContextHelper
    {

        private static IHttpContextAccessor _accessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;

    }
}
