using System;
using System.Collections.Generic;
using System.Text;

namespace Entitys.SysClass
{
    //
    using DbFrame.BaseClass;
    using Entitys.Attributes;

    /// <summary>
    /// [AppLog_ID], [AppLog_Api], [AppLog_IP], [AppLog_UserID], [AppLog_Parameter], [AppLog_CreateTime]
    /// </summary>
    public class Sys_AppLog : Class.BaseClass
    {

        [Field("ID", IsKey = true)]
        public Guid AppLog_ID { get; set; }

        [Field("Api")]
        public string AppLog_Api { get; set; }

        [Field("IP")]
        public string AppLog_IP { get; set; }

        [Field("操作人")]
        public Guid? AppLog_UserID { get; set; }

        [Field("参数")]
        public string AppLog_Parameter { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? AppLog_CreateTime { get; set; }

    }
}
