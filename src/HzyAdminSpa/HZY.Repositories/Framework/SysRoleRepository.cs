using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysRoleRepository : EFCoreBaseRepository<SysRole>
{
    public SysRoleRepository(AdminBaseDbContext context) : base(context)
    {

    }
}