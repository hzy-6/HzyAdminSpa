using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZY.Models.Entities.BaseEntitys;

public class CreateBaseEntity<TKey> : BaseEntity<TKey>, ICreateBaseEntity, IBaseEntity<TKey>
{
    public virtual Guid? CreateUserId { get; set; }
    public virtual DateTime CreateTime { get; set; }
}

public interface ICreateBaseEntity
{
    /// <summary>
    /// 创建用户
    /// </summary>
    Guid? CreateUserId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    DateTime CreateTime { get; set; }
}