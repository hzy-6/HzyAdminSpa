using HZY.Infrastructure;
using HZY.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HZY.Controllers.Admin.ControllersAdmin;

[Authorize]//是否授权 Authorize
[ApiExplorerSettings(GroupName = nameof(ApiVersions.Admin))]
[Route("api/admin/[controller]")]
public class AdminBaseController<TDefaultService> : ApiBaseController<TDefaultService> where TDefaultService : class
{
    public AdminBaseController(TDefaultService defaultService) : base(defaultService)
    {

    }
}

[Authorize]//是否授权 Authorize
[ApiExplorerSettings(GroupName = nameof(ApiVersions.Admin))]
[Route("api/admin/[controller]")]
public class AdminBaseController : ApiBaseController
{

}