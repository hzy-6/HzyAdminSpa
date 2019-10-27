using System;
using System.Collections.Generic;
using System.Text;

namespace Entitys
{
    //
    using DbFrame.BaseClass;
    using Entitys.Attributes;
    /// <summary>
    /// [Member_ID], [Member_Num], [Member_Name], [Member_Phone], [Member_Sex], [Member_Birthday], [Member_Photo], [Member_UserID], [Member_Introduce], [Member_FilePath], [Member_CreateTime]
    /// </summary>
    public class Member : Class.BaseClass
    {


        [Field(IsKey = true)]
        public Guid Member_ID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Member_Num { get; set; }

        /// <summary>
        /// 会员名称
        /// </summary>
        public string Member_Name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Member_Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Member_Sex { get; set; } = "男";

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Member_Birthday { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Member_Photo { get; set; }

        /// <summary>
        /// 帐户ID
        /// </summary>
        public Guid? Member_UserID { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Member_Introduce { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string Member_FilePath { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? Member_CreateTime { get; set; }




    }
}
