using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysOrganizationRepository : EFCoreBaseRepository<SysOrganization>
{
    public SysOrganizationRepository(AdminBaseDbContext context) : base(context)
    {

    }




}