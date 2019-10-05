using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    using DbFrame.DbContext.SqlServer;
    using Microsoft.AspNetCore.Cors;

    //[ApiController]
    [EnableCors("ApiAny")]
    public class ApiBaseController : ControllerBase
    {

        /// <summary>
        /// 数据访问对象
        /// </summary>
        protected DbContextSqlServer db => Logic.Class.AppBase.db;

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <returns>{status:1}</returns>
        [NonAction]
        public IActionResult Json()
        {
            return this.Json(new { status = 1 });
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="Data"></param>
        /// <returns>Data</returns>
        [NonAction]
        public IActionResult Json(object Data)
        {
            return new JsonResult(Data);
        }


    }
}