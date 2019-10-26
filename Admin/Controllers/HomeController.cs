using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    using Microsoft.AspNetCore.Diagnostics;
    using Toolkit;

    [
        Route("[controller]"),
        ApiExplorerSettings(IgnoreApi = true)//该标记用于 忽略添加到 swagger 接口文档中
    ]
    public class HomeController : ApiBaseController
    {
        [HttpGet(nameof(Index))]
        public IActionResult Index() => Content("程序已启动！");

    }
}
