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

        [Field(IsKey = true)]
        public Guid AppLog_ID { get; set; }

        /// <summary>
        /// #Api#
        /// </summary>
        public string AppLog_Api { get; set; }

        /// <summary>
        /// #IP#
        /// </summary>
        public string AppLog_IP { get; set; }

        /// <summary>
        /// #操作人#
        /// </summary>
        public Guid? AppLog_UserID { get; set; }

        /// <summary>
        /// #参数#
        /// </summary>
        public string AppLog_Parameter { get; set; }

        /// <summary>
        /// #创建时间#
        /// </summary>
        [Field(IsIgnore = true)]
        public DateTime? AppLog_CreateTime { get; set; }

    }
}
