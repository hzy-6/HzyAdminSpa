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

        [Field("ID", IsKey = true)]
        public Guid Menu_ID { get; set; }

        [Field("编号")]
        public string Menu_Num { get; set; }

        [Field("菜单名称")]
        public string Menu_Name { get; set; }

        [Field("地址")]
        public string Menu_Url { get; set; }

        [Field("菜单图标")]
        public string Menu_Icon { get; set; }

        [Field("父级ID")]
        public Guid? Menu_ParentID { get; set; }

        /// <summary>
        /// 是否显示 1:是 2：否
        /// </summary>
        [Field("是否显示")]
        public int? Menu_IsShow { get; set; } = 1;

        [Field("创建时间", IsIgnore = true)]
        public DateTime? Menu_CreateTime { get; set; }

    }
}
