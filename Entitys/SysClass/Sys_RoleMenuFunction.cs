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

        [Field(IsKey = true)]
        public Guid? RoleMenuFunction_ID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid? RoleMenuFunction_RoleID { get; set; }

        /// <summary>
        /// 功能ID
        /// </summary>
        public Guid? RoleMenuFunction_FunctionID { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public Guid? RoleMenuFunction_MenuID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? RoleMenuFunction_CreateTime { get; set; }

    }
}
