using System;
//
//
using DbFrame.BaseClass;
using Entitys.Attributes;

namespace Entitys.SysClass
{
    /// <summary>
    /// 菜单与功能绑定 MenuFunction_ID, MenuFunction_MenuID, MenuFunction_FunctionID, MenuFunction_CreateTime
    /// </summary>
    [Table("Sys_MenuFunction")]
    public class Sys_MenuFunction : Class.BaseClass
    {

        [Field(IsKey = true)]
        public Guid? MenuFunction_ID { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public Guid? MenuFunction_MenuID { get; set; }

        /// <summary>
        /// 功能ID
        /// </summary>
        public Guid? MenuFunction_FunctionID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? MenuFunction_CreateTime { get; set; }


    }
}
