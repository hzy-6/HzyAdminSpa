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
        [Field("ID", IsKey = true)]
        public Guid? UserRole_ID { get; set; }

        [Field("用户ID")]
        public Guid? UserRole_UserID { get; set; }

        [Field("角色ID")]
        public Guid? UserRole_RoleID { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? UserRole_CreateTime { get; set; }



    }
}
