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

        [Field(IsKey = true)]
        public Guid Role_ID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Role_Num { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Role_Remark { get; set; }

        /// <summary>
        /// 是否可删除=> 1：是 2：否
        /// </summary>
        public int? Role_IsDelete { get; set; } = 1;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? Role_CreateTime { get; set; }

    }
}
