using System;
//
//
using DbFrame.BaseClass;
using Entitys.Attributes;

namespace Entitys.SysClass
{
    /// <summary>
    /// 角色菜单功能绑定 RoleMenuFunction_ID, RoleMenuFunction_RoleID, RoleMenuFunction_FunctionID, RoleMenuFunction_MenuID, RoleMenuFunction_CreateTime
    /// </summary>
    [Table("Sys_RoleMenuFunction")]
    public class Sys_RoleMenuFunction : Class.BaseClass
    {

        [Field("ID", IsKey = true)]
        public Guid? RoleMenuFunction_ID { get; set; }

        [Field("角色ID")]
        public Guid? RoleMenuFunction_RoleID { get; set; }

        [Field("功能ID")]
        public Guid? RoleMenuFunction_FunctionID { get; set; }

        [Field("菜单ID")]
        public Guid? RoleMenuFunction_MenuID { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? RoleMenuFunction_CreateTime { get; set; }

    }
}
