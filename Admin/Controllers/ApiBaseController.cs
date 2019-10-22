using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    using DbFrame.DbContext.SqlServer;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using Toolkit;

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


        /// <summary>
        /// 处理上传文件
        /// </summary>
        /// <param name="_IFormFile"></param>
        /// <param name="_WebRootPath"></param>
        /// <param name="Format"></param>
        /// <param name="GroupName"></param>
        /// <param name="Check"></param>
        /// <returns></returns>
        [NonAction]
        public async Task<string> HandleUpFile(IFormFile _IFormFile, string _WebRootPath, string[] Format = null, string GroupName = null, Action<IFormFile> Check = null)
        {
            Check?.Invoke(_IFormFile);

            string ExtensionName = Path.GetExtension(_IFormFile.FileName).ToLower().Trim();//获取后缀名

            if (Format != null && !Format.Contains(ExtensionName.ToLower()))
            {
                throw new MessageBox("请上传后缀名为：" + string.Join("、", Format) + " 格式的文件");
            }
            //GroupName
            var _Directory = $"/Content/UploadFiles/{(string.IsNullOrWhiteSpace(GroupName) ? "" : GroupName + "/")}";

            if (!Directory.Exists(_WebRootPath + _Directory)) Directory.CreateDirectory(_WebRootPath + _Directory);
            string filePath = $"{_Directory}{Guid.NewGuid()}_{_IFormFile.FileName}";
            // 创建新文件
            using (FileStream fs = System.IO.File.Create(_WebRootPath + filePath))
            {
                await _IFormFile.CopyToAsync(fs);
                // 清空缓冲区数据
                await fs.FlushAsync();
            }

            return filePath;
        }

        


    }
}