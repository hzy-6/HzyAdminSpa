using System;
//
//
using DbFrame.BaseClass;
using Entitys.Attributes;

namespace Entitys.SysClass
{
    /// <summary>
    /// 功能 Function_ID, Function_Num, Function_Name, Function_ByName, Function_CreateTime
    /// </summary>
    [Table("Sys_Function")]
    public class Sys_Function : Class.BaseClass
    {

        [Field(IsKey = true)]
        public Guid Function_ID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Function_Num { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        [CRequired(ErrorMessage = "{name}不能为空")]
        [CRepeat(ErrorMessage = "{name}已存在")]
        public string Function_Name { get; set; }

        /// <summary>
        /// 功能英文名
        /// </summary>
        [CRequired(ErrorMessage = "{name}不能为空")]
        [CRepeat(ErrorMessage = "{name}已存在")]
        public string Function_ByName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? Function_CreateTime { get; set; }




    }
}
