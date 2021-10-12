using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysRoleMenuFunctionRepository : EFCoreBaseRepository<SysRoleMenuFunction>
{
    public SysRoleMenuFunctionRepository(AdminBaseDbContext context) : base(context)
    {

    }
}