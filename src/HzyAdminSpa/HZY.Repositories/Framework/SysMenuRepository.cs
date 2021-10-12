using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysMenuRepository : EFCoreBaseRepository<SysMenu>
{
    public SysMenuRepository(AdminBaseDbContext context) : base(context)
    {
    }
}