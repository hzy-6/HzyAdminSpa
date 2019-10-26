using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers.Admin.Sys
{
    using System.Collections;
    using Entitys.SysClass;
    using Logic;
    using Logic.SysClass;
    using Microsoft.AspNetCore.Http;
    using DbFrame;
    using Toolkit;
    using Logic.Class;
    using Microsoft.AspNetCore.Hosting;
    using System.Text;
    using System.IO;

    /// <summary>
    /// 代码创建 工具
    /// </summary>
    [ApiExplorerSettings(GroupName = nameof(AppService.ApiVersionsEnum.Admin))]
    [Route("Admin/[controller]")]
    public class CCTController : ApiBaseController
    {
        private string _WebRootPath = string.Empty;
        public CCTController(IWebHostEnvironment IWebHostEnvironment)
        {
            _WebRootPath = IWebHostEnvironment.WebRootPath;
        }

        Sys_CreateCodeLogic _Logic = new Sys_CreateCodeLogic();

        /// <summary>
        /// 获取所有的 表名 及对应的 字段
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetTableNameAndFields))]
        public async Task<IActionResult> GetTableNameAndFields() => Json(new { status = 1, data = await _Logic.GetTableNameAndFields() });

        /// <summary>
        /// 获取 Model 代码
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [HttpPost(nameof(GetModelCode))]
        public async Task<IActionResult> GetModelCode(string TableName)
        {
            var TempUrl = _WebRootPath + "/Content/CodeTemp/Model.txt";

            if (!System.IO.File.Exists(TempUrl))
                throw new MessageBox("模板文件不存在");

            return Json(new { status = 1, data = await _Logic.CreateModelCode(TableName, await System.IO.File.ReadAllTextAsync(TempUrl, Encoding.UTF8)) });
        }

        /// <summary>
        /// 获取 注册 数据库 表 代码
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetDbSetCode))]
        public async Task<IActionResult> GetDbSetCode() => Json(new { status = 1, data = await _Logic.CreateDbSetCode() });

        /// <summary>
        /// 获取 Logic 代码
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [HttpPost(nameof(GetLogicCode))]
        public async Task<IActionResult> GetLogicCode(string TableName)
        {
            var TempUrl = _WebRootPath + "/Content/CodeTemp/Logic.txt";

            if (!System.IO.File.Exists(TempUrl))
                throw new MessageBox("模板文件不存在");

            return Json(new { status = 1, data = await _Logic.CreateLogicCode(TableName, await System.IO.File.ReadAllTextAsync(TempUrl, Encoding.UTF8)) });
        }

        /// <summary>
        /// 获取 Logic 代码
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [HttpPost(nameof(GetControllersCode))]
        public async Task<IActionResult> GetControllersCode(string TableName)
        {
            var TempUrl = _WebRootPath + "/Content/CodeTemp/Controllers.txt";

            if (!System.IO.File.Exists(TempUrl))
                throw new MessageBox("模板文件不存在");

            return Json(new { status = 1, data = await _Logic.CreateControllersCode(TableName, await System.IO.File.ReadAllTextAsync(TempUrl, Encoding.UTF8)) });
        }

        /// <summary>
        /// 获取 Form 代码
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Fields"></param>
        /// <returns></returns>
        [HttpPost(nameof(GetFormCode))]
        public async Task<IActionResult> GetFormCode(string TableName, List<string> Fields)
        {
            var TempUrl = _WebRootPath + "/Content/CodeTemp/Form.txt";

            if (!System.IO.File.Exists(TempUrl))
                throw new MessageBox("模板文件不存在");

            if (Fields?.Count == 0)
            {
                Fields = new List<string>();
                var _Cols = await _Logic.GetColsByTableName(TableName);
                foreach (var _Col in _Cols)
                {
                    Fields.Add($"{TableName}/{_Col.COLUMN_NAME}");
                }
            }

            return Json(new { status = 1, data = await _Logic.CreateFormCode(Fields, await System.IO.File.ReadAllTextAsync(TempUrl, Encoding.UTF8)) });
        }

        /// <summary>
        /// 下载当前代码
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(Download))]
        public IActionResult Download(string TableName, string CodeType, string Content)
        {
            var Suffix = string.Empty;
            var FileType = ".cs";

            if (CodeType == "Model") Suffix = ".cs";

            if (CodeType == "Logic") Suffix = "Logic.cs";

            if (CodeType == "Controller") Suffix = "Controller.cs";

            if (CodeType == "Form")
            {
                Suffix = ".vue";
                FileType = ".vue";
            }

            var _Bytes = Encoding.UTF8.GetBytes(Content);
            return File(_Bytes, Tools.GetFileContentType[".cs"], $"{TableName}{Suffix}");
        }

        /// <summary>
        /// 下载所有 代码
        /// </summary>
        /// <param name="CodeType">代码类型</param>
        /// <returns></returns>
        [HttpGet(nameof(DownloadAll))]
        public async Task<IActionResult> DownloadAll(string CodeType)
        {
            var Suffix = string.Empty;
            var Temp = string.Empty;
            var TempUrl = string.Empty;

            if (CodeType == "Model")
            {
                Suffix = ".cs";
                TempUrl = _WebRootPath + "/Content/CodeTemp/Model.txt";
            }

            if (CodeType == "Logic")
            {
                Suffix = "Logic.cs";
                TempUrl = _WebRootPath + "/Content/CodeTemp/Logic.txt";
            }

            if (CodeType == "Controller")
            {
                Suffix = "Controller.cs";
                TempUrl = _WebRootPath + "/Content/CodeTemp/Controllers.txt";
            }

            if (CodeType == "Form")
            {
                Suffix = ".vue";
                TempUrl = _WebRootPath + "/Content/CodeTemp/Form.txt";
            }

            Temp = await System.IO.File.ReadAllTextAsync(TempUrl, Encoding.UTF8);

            //List<StringBuilder> _Codes = new List<StringBuilder>();
            Dictionary<string, Stream> _DicStream = new Dictionary<string, Stream>();

            var _TableNames = await _Logic.GetAllTable();
            foreach (var item in _TableNames)
            {
                StringBuilder _StringBuilder = new StringBuilder();

                if (CodeType == "Model")
                {
                    _StringBuilder.Append(await _Logic.CreateModelCode(item, Temp));
                }

                if (CodeType == "Logic")
                {
                    _StringBuilder.Append(await _Logic.CreateLogicCode(item, Temp));
                }

                if (CodeType == "Controller")
                {
                    _StringBuilder.Append(await _Logic.CreateControllersCode(item, Temp));
                }

                if (CodeType == "Form")
                {
                    //获取表下面的所有 字段
                    var _Cols = await _Logic.GetColsByTableName(item);
                    var list = new List<string>();
                    foreach (var _Col in _Cols)
                    {
                        list.Add($"{item}/{_Col}");
                    }
                    _StringBuilder.Append(await _Logic.CreateFormCode(list, Temp));
                }

                //_Codes.Add(_StringBuilder);
                _DicStream[$"{item}{Suffix}"] = new MemoryStream(Encoding.UTF8.GetBytes(_StringBuilder.ToString()));
            }

            var _Bytes = new byte[] { };

            await Task.Run(() =>
            {
                _Bytes = Tools.PackageManyZip(_DicStream);
            });

            return File(_Bytes, Tools.GetFileContentType[".zip"], $"{CodeType}.zip");
        }




    }
}
