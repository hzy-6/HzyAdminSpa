using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers.Admin
{
    using DbFrame.DbContext.SqlServer;
    using Entitys.SysClass;
    using AppService;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using System.Collections;
    using System.IO;
    using Toolkit;

    [Microsoft.AspNetCore.Authorization.Authorize]
    [ApiExplorerSettings(GroupName = nameof(ApiVersionsEnum.Admin))]
    [Route("Admin/[controller]")]
    public class AdminBaseController : ApiBaseController
    {
        /// <summary>
        /// 账户
        /// </summary>
        public Account _Account { get; set; } = new Account();

        /// <summary>
        /// 表单标识
        /// </summary>
        public string FormKey { get; set; }

        /// <summary>
        /// 将  FormCollection  转换为  Dictionary
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected Hashtable FormCollectionToHashtable(IFormCollection _IFormCollection)
        {
            var _Hashtable = new Hashtable();
            if (_IFormCollection != null)
            {
                foreach (var item in _IFormCollection.Keys)
                {
                    _Hashtable.Add(item, System.Net.WebUtility.UrlDecode(_IFormCollection[item]));
                }
                //检查地址栏是否有参数
                var _Query = Request.Query;
                foreach (var item in _Query.Keys)
                {
                    _Hashtable.Add(item, _Query[item]);
                }
            }
            return _Hashtable;
        }

        /// <summary>
        /// 数据源
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        [NonAction]
        protected virtual Task<TableViewModel> DataSourceAsync(int Page, int Rows, Hashtable Search) => throw new Exception("未实现!");


    }
}