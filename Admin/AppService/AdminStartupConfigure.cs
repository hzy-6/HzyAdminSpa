using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.AppService
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Toolkit;
    using Toolkit.Entitys;
    using DbFrame.DbContext.SqlServer;
    using System.IO;
    using Toolkit.LogService;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;

    public static class AdminStartupConfigure
    {
        private static readonly IEnumerable<string> _VersionList = typeof(ApiVersionsEnum).GetEnumNames().ToList().OrderBy(w => w);

        public static void AdminConfigureServices(this IServiceCollection services, IConfiguration Configuration, IWebHostEnvironment _IWebHostEnvironment)
        {

            #region HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region AppConfig
            //配置 AppConfigs
            AppConfig.AdminAppConfig = Configuration.GetSection("AppConfig").Get<AdminAppConfig>();
            #endregion

            #region DbFrame
            //注入链接字符串
            DbContextSqlServer.Register(AppConfig.AdminAppConfig.SqlServerConnStr, (tabs) =>
            {
                //注册Models
                Entitys.Class.EntitySet.Register(tabs);
            });
            //将DbContextSqlServer对象注册Logic层静态对象中
            Logic.Class.AppBase.db = new DbContextSqlServer();
            //将DbContextSqlServer对象注册UI层构造函数中
            //services.AddSingleton(Logic.Class.BaseLogic.db.GetType());
            #endregion

            #region JWT
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = AppConfig.AdminAppConfig.JwtKeyName,//Audience
                        ValidIssuer = AppConfig.AdminAppConfig.JwtKeyName,//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(AppConfig.AdminAppConfig.JwtSecurityKey))//拿到SecurityKey
                    };
                });
            #endregion

            #region Swagger 注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(option =>
            {
                foreach (var item in _VersionList)
                {
                    var _SwaggerInfo = new OpenApiInfo();
                    _SwaggerInfo.Version = item;
                    //_SwaggerInfo.Title = "v_" + item;
                    //_SwaggerInfo.Description = "author：hzy";
                    //_SwaggerInfo.TermsOfService = "None";
                    option.SwaggerDoc(item, _SwaggerInfo);
                }
                // 为 Swagger JSON and UI设置xml文档注释路径
                //var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(System.AppContext.BaseDirectory, "App.xml");
                option.IncludeXmlComments(xmlPath, true);

                #region Jwt token 配置
                //option.OperationFilter<AppService.SwaggerParameterFilter>(); // 给每个接口配置授权码传入参数文本框
                //
                option.OperationFilter<AddResponseHeadersFilter>();
                option.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                // 很重要！这里配置安全校验，和之前的版本不一样
                option.OperationFilter<SecurityRequirementsOperationFilter>();

                // 开启 oauth2 安全描述
                option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                #endregion

            });

            #endregion
        }

        public static void AdminConfigure(this IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IHostApplicationLifetime applicationLifetime)
        {
            #region nlog 日志
            //初始化NLog
            LogHelper.Init(app, $"{env.ContentRootPath}/NLog/nlog.config", loggerFactory);

            //程序启动
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Tools.Log.Write("App启动");
            });
            //程序正在结束中
            applicationLifetime.ApplicationStopping.Register(() =>
            {
                Tools.Log.Write("App结束中...");
            });
            //程序已结束
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                Tools.Log.Write("App已结束");
            });
            //applicationLifetime.StopApplication();//停止程序
            #endregion

            #region HttpContext
            //将 对象 IHttpContextAccessor 注入 HttpContextHelper 静态对象中
            Toolkit.HttpContextService.HttpContextHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            #endregion

            #region JWT
            //注意添加这一句，启用jwt验证
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            #region Swagger
            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(option =>
            {
                foreach (var item in _VersionList) option.SwaggerEndpoint($"/swagger/{item}/swagger.json", item);
                option.RoutePrefix = "swagger";
            });
            #endregion

            #region WebSocket

            //WebSocket
            //Logic.WebSocket.WebSocketWork.Register(app);

            #endregion



        }


    }
}
