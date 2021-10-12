using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysUserRepository : EFCoreBaseRepository<SysUser>
{
    public SysUserRepository(AdminBaseDbContext context) : base(context)
    {
    }
}