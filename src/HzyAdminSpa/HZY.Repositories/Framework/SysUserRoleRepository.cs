using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysUserRoleRepository : EFCoreBaseRepository<SysUserRole>
{
    public SysUserRoleRepository(AdminBaseDbContext context) : base(context)
    {
    }
}