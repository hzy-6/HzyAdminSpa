using System;

namespace DbFrame.BaseClass
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute(string TableFieldName = null)
        {
            this.TableFieldName = TableFieldName;
        }

        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 字段在数据库中的名称 如果设置了 以设置为准
        /// </summary>
        public string TableFieldName { get; set; } = string.Empty;

        public bool IsKey { get; set; } = false;

        public bool IsIdentity { get; set; } = false;

        public bool IsIgnore { get; set; } = false;

        public bool IsColumn { get; set; } = true;

        public Type Type { get; set; } = null;


    }
}
