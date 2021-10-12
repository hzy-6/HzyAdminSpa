using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysFunctionRepository : EFCoreBaseRepository<SysFunction>
{
    public SysFunctionRepository(AdminBaseDbContext context) : base(context)
    {
    }
}