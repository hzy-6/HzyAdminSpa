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
        /// 上传文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Files(IFormFileCollection files)//IFormFile files
        {
            if (files?.Count == 0) throw new MessageBox("找不到任何文件!");
            var _Path = new List<object>();
            foreach (var item in files.GetFiles("files"))
            {
                _Path.Add(new
                {
                    name = item.FileName,
                    url = await this.HandleUpFile(item, _WebRootPath)
                });
            }
            return Json(_Path);
        }





















    }
}