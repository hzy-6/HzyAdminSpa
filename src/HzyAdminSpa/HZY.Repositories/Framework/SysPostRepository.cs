using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysPostRepository : EFCoreBaseRepository<SysPost>
{
    public SysPostRepository(AdminBaseDbContext context) : base(context)
    {

    }

}