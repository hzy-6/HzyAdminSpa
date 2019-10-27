using System;
//
using DbFrame.BaseClass;
using Entitys.Attributes;

namespace Entitys.SysClass
{
    /// <summary>
    /// 菜单 Menu_ID, Menu_Num, Menu_Name, Menu_Url, Menu_Icon, Menu_ParentID, Menu_CreateTime
    /// </summary>
    [Table("Sys_Menu")]
    public class Sys_Menu : Class.BaseClass
    {

        [Field( IsKey = true)]
        public Guid Menu_ID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Menu_Num { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Menu_Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Menu_Url { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Menu_Icon { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid? Menu_ParentID { get; set; }

        /// <summary>
        /// 是否显示=> 1:是 2：否
        /// </summary>
        public int? Menu_IsShow { get; set; } = 1;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? Menu_CreateTime { get; set; }

    }
}
