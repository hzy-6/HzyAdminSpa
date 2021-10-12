using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysMenuFunctionRepository : EFCoreBaseRepository<SysMenuFunction>
{
    public SysMenuFunctionRepository(AdminBaseDbContext context) : base(context)
    {
    }
}