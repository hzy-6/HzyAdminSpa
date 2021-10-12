using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

/// <summary>
/// 数据字典仓储
/// </summary>
public class SysDictionaryRepository : EFCoreBaseRepository<SysDictionary>
{
    public SysDictionaryRepository(AdminBaseDbContext context) : base(context)
    {

    }
}
