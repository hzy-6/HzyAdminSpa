using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers.Admin.Base
{
    using System.Collections;
    using Entitys.SysClass;
    using Logic;
    using Logic.SysClass;
    using Microsoft.AspNetCore.Http;
    using DbFrame;
    using Toolkit;
    using Entitys;
    using Microsoft.AspNetCore.Hosting;
    using System.Text.Json;
    using Logic.Class;

    /// <summary>
    /// 会员管理
    /// </summary>
    public class MemberController : AdminBaseController
    {
        private IWebHostEnvironment _IWebHostEnvironment = null;
        private string _WebRootPath = string.Empty;
        public MemberController(IWebHostEnvironment IWebHostEnvironment)
        {
            this._IWebHostEnvironment = IWebHostEnvironment;
            _WebRootPath = this._IWebHostEnvironment.WebRootPath;
        }

        protected MemberLogic _Logic = new MemberLogic();

        #region 增、删、改、查

        /// <summary>
        /// 数据源
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        [NonAction]
        protected override async Task<TableViewModel> DataSourceAsync(int Page, int Rows, Hashtable Search) => await _Logic.FindList(Page, Rows, Search);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="Page">页码</param>
        /// <param name="Rows">每页显示多少条</param>
        /// <param name="_IFormCollection">参数</param>
        /// <returns></returns>
        [HttpPost(nameof(FindList)), AppService.ApiCheckTokenFilter]
        public async Task<TableViewModel> FindList(int Page, int Rows, IFormCollection _IFormCollection)
        {
            _Logic._Account = this._Account;//将当前用户信息传入 Logic层
            var _HashtableQuery = this.FormCollectionToHashtable(_IFormCollection);
            var _DataViewModel = await this.DataSourceAsync(Page, Rows, _HashtableQuery);
            return _DataViewModel;
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="_IFormCollection"></param>
        /// <returns></returns>
        [HttpGet(nameof(ExportExcel)), AppService.ApiCheckTokenFilter]
        public async Task<IActionResult> ExportExcel(IFormCollection _IFormCollection) =>
            File(AppBase.HandleExportExcel(await this.FindList(1, 999999, _IFormCollection)), Tools.GetFileContentType[".xls"].ToStr(), Guid.NewGuid().ToString() + ".xls");

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Member_Photo_Files"></param>
        /// <param name="Member_FilePath_Files"></param>
        /// <returns></returns>
        [HttpPost(nameof(Save)), AppService.ApiCheckTokenFilter]
        public async Task<IActionResult> Save(Member model, IFormFile Member_Photo_Files, List<IFormFile> Member_FilePath_Files)
        {
            this.FormKey = await _Logic.Save(model, async member =>
              {
                  if (Member_Photo_Files != null)
                  {
                      member.Member_Photo = await this.HandleUpFile(Member_Photo_Files, _WebRootPath);
                  }
                  if (Member_FilePath_Files.Count > 0)
                  {
                      var _Path = new List<object>();
                      if (!string.IsNullOrWhiteSpace(model.Member_FilePath))
                          _Path = JsonSerializer.Deserialize<List<object>>(model.Member_FilePath);
                      if (_Path == null) _Path = new List<object>();
                      foreach (var item in Member_FilePath_Files)
                      {
                          _Path.Add(new { name = item.FileName, url = await this.HandleUpFile(item, _WebRootPath) });
                      }
                      if (_Path.Count > 0) member.Member_FilePath = _Path.Serialize();
                  }
                  return member;
              });

            return Json();
        }

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="Id">Id集合</param>
        /// <returns></returns>
        [HttpPost(nameof(Delete)), AppService.ApiCheckTokenFilter]
        public IActionResult Delete(List<Guid> Id)
        {
            _Logic.Delete(Id);
            return Json();
        }

        /// <summary>
        /// 加载表单
        /// </summary>
        /// <param name="Id">主表Id</param>
        /// <returns></returns>
        [HttpPost(nameof(LoadForm)), AppService.ApiCheckTokenFilter]
        public IActionResult LoadForm(Guid? Id)
        {
            return Json(new
            {
                status = 1,
                Form = _Logic.LoadForm(Id)
            });
        }

        #endregion

        #region 其他

        #endregion
    }
}