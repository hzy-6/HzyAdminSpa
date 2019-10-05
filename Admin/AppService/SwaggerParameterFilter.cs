using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.AppService
{
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// swagger 设置默认参数
    /// </summary>
    public class SwaggerParameterFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
            var descriptor = (context.ApiDescription.ActionDescriptor as ControllerActionDescriptor);
            if (descriptor == null) return;
            var _FilterDescriptors = descriptor.FilterDescriptors;
            //链接中添加accesstoken值 在头部
            if (_FilterDescriptors.Any(item => item.Filter is ApiCheckTokenFilterAttribute))
            {
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,//query header body path formData
                    //Style = ParameterStyle.DeepObject,
                    Required = true //是否必选
                });
            }

            //foreach (var attr in attrs)
            //{
            //    // 如果 Attribute 是我们自定义的验证过滤器
            //    if (attr.GetType() == typeof(AopCheckTokenFilterAttribute))
            //    {
            //        operation.Parameters.Add(new NonBodyParameter()
            //        {
            //            Name = "Authorization",
            //            In = "header",
            //            Type = "string",
            //            Required = false
            //        });
            //    }
            //}
        }

    }
}
