using System;
//
using DbFrame.BaseClass;
using Entitys.Attributes;

namespace Entitys.SysClass
{
    /// <summary>
    /// 用户 User_ID, User_Name, User_LoginName, User_Pwd, User_Email, User_Token, User_CreateTime
    /// </summary>
    [Table("Sys_User")]
    public class Sys_User : Class.BaseClass
    {

        [Field( IsKey = true)]
        public Guid User_ID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [CRequired(ErrorMessage = "{name}不能为空")]
        public string User_Name { get; set; }

        /// <summary>
        /// 登陆名
        /// </summary>
        [CRepeat(ErrorMessage = "{name}不能重复")]
        public string User_LoginName { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        public string User_Pwd { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string User_Email { get; set; }

        /// <summary>
        /// 是否可删除=> 1：是 2：否
        /// </summary>
        public int? User_IsDelete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? User_CreateTime { get; set; }


    }
}
