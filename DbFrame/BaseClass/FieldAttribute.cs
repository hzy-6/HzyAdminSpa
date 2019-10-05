using System;

namespace DbFrame.BaseClass
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute(string alias)
        {
            this.Alias = alias;
            this.Name = string.Empty;
            //this.Alias = string.Empty;
            this.IsKey = false;
            this.IsIdentity = false;
            this.IsIgnore = false;
            this.IsColumn = true;
            this.Type = null;
        }

        public string Name { get; set; }

        public string Alias { get; set; }

        public bool IsKey { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsIgnore { get; set; }

        public bool IsColumn { get; set; }

        public Type Type { get; set; }


    }
}
