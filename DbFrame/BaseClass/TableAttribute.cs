using System;

namespace DbFrame.BaseClass
{
    public class TableAttribute : Attribute
    {

        public string TableName = string.Empty;

        public TableAttribute(string _TableName)
        {
            this.TableName = _TableName;
        }

    }
}
