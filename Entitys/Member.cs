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


        [Field("ID", IsKey = true)]
        public Guid Member_ID { get; set; }

        [Field("编号")]
        public string Member_Num { get; set; }

        [Field("会员名称")]
        public string Member_Name { get; set; }

        [Field("联系电话")]
        public string Member_Phone { get; set; }

        [Field("性别")]
        public string Member_Sex { get; set; } = "男";

        [Field("生日")]
        public DateTime? Member_Birthday { get; set; }

        [Field("头像")]
        public string Member_Photo { get; set; }

        [Field("帐户ID")]
        public Guid? Member_UserID { get; set; }

        [Field("介绍")]
        public string Member_Introduce { get; set; }

        [Field("文件地址")]
        public string Member_FilePath { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? Member_CreateTime { get; set; }




    }
}
