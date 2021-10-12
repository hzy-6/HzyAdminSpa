using HZY.EFCore.DbContexts;
using HZY.EFCore.Repositories;
using HZY.Models.Entities.Framework;

namespace HZY.Repositories.Framework;

/// <summary>
/// 操作日志 仓储
/// </summary>
public class SysOperationLogRepository : EFCoreBaseRepository<SysOperationLog>
{
    public SysOperationLogRepository(AdminBaseDbContext context) : base(context)
    {

    }





}