using System;
//
//
using DbFrame.BaseClass;
using Entitys.Attributes;

namespace Entitys.SysClass
{
    /// <summary>
    /// 角色 Role_ID, Role_Num, Role_Name, Role_Remark, Role_CreateTime
    /// </summary>
    [Table("Sys_Role")]
    public class Sys_Role : Class.BaseClass
    {

        [Field("ID", IsKey = true)]
        public Guid Role_ID { get; set; }

        [Field("编号")]
        public string Role_Num { get; set; }

        [Field("角色名")]
        public string Role_Name { get; set; }

        [Field("备注")]
        public string Role_Remark { get; set; }

        /// <summary>
        /// 1：是 2：否
        /// </summary>
        [Field("是否可删除")]
        public int? Role_IsDelete { get; set; } = 1;

        [Field("创建时间", IsIgnore = true)]
        public DateTime? Role_CreateTime { get; set; }

    }
}
