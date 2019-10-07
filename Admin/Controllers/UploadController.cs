using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{

    using global::Admin.AppService;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Filters;
    using Toolkit;

    /// <summary>
    /// 上传文件
    /// </summary>
    [ApiExplorerSettings(GroupName = nameof(ApiVersionsEnum.Admin))]
    [Route("[controller]")]
    public class UploadController : ApiBaseController
    {


        private IWebHostEnvironment _IWebHostEnvironment = null;
        private string _WebRootPath = string.Empty;
        public UploadController(IWebHostEnvironment IWebHostEnvironment)
        {
            this._IWebHostEnvironment = IWebHostEnvironment;
            _WebRootPath = this._IWebHostEnvironment.WebRootPath;
        }

        public class FilesModel
        {
            [FromForm]
            public IList<IFormFile> files { get; set; }
        }

        /// <summary>
        /// 上传单个文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        [HttpPost("Single")]
        public async Task<string> Post(IFormFile files, string GroupName)
        {
            if (files == null) throw new MessageBox("找不到任何文件!");
            //var _Path = new List<object>();
            //_Path.Add(new
            //{
            //    name = files.FileName,
            //    url = await this.HandleUpFile(files, _WebRootPath, null, GroupName)
            //});
            return await this.HandleUpFile(files, _WebRootPath, null, GroupName);
        }

        /// <summary>
        /// 上传多个文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        [HttpPost("Multiple")]
        public async Task<IActionResult> Post(IFormFileCollection files, string GroupName)
        {
            if (files?.Count == 0) throw new MessageBox("找不到任何文件!");
            var _Path = new List<object>();
            foreach (var item in files)
            {
                _Path.Add(new
                {
                    name = item.FileName,
                    url = await this.HandleUpFile(item, _WebRootPath, null, GroupName)
                });
            }
            return Json(_Path);
        }


















    }
}