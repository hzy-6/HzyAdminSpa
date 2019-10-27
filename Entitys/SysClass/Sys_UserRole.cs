using System;
//
using DbFrame.BaseClass;
using Entitys.Attributes;

namespace Entitys.SysClass
{
    /// <summary>
    /// 用户角色绑定 UserRole_ID, UserRole_UserID, UserRole_RoleID, UserRole_CreateTime
    /// </summary>
    [Table("Sys_UserRole")]
    public class Sys_UserRole : Class.BaseClass
    {
        [Field(IsKey = true)]
        public Guid? UserRole_ID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? UserRole_UserID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid? UserRole_RoleID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? UserRole_CreateTime { get; set; }



    }
}
