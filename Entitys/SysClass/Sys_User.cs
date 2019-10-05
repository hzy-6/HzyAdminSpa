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

        [Field("ID", IsKey = true)]
        public Guid User_ID { get; set; }

        [CRequired(ErrorMessage = "{name}不能为空")]
        [Field("用户名称")]
        public string User_Name { get; set; }

        [CRepeat(ErrorMessage = "{name}不能重复")]
        [Field("登陆名")]
        public string User_LoginName { get; set; }

        [Field("登陆密码")]
        public string User_Pwd { get; set; }

        [Field("邮件")]
        public string User_Email { get; set; }

        /// <summary>
        /// 1：是 2：否
        /// </summary>
        [Field("是否可删除")]
        public int? User_IsDelete { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? User_CreateTime { get; set; }


    }
}
