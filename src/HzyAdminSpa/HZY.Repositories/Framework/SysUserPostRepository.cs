using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

public class SysUserPostRepository : EFCoreBaseRepository<SysUserPost>
{
    public SysUserPostRepository(AdminBaseDbContext context) : base(context)
    {

    }




}