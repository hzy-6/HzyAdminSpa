using System;
using System.Collections.Generic;
using System.Text;

namespace Entitys.SysClass
{
    public class Sys_FileInfo
    {

        public Sys_FileInfo() { }

        public Sys_FileInfo(string Name, string Url)
        {
            this.name = Name;
            this.url = Url;
        }

        public string name { get; set; } = string.Empty;

        public string url { get; set; } = string.Empty;

    }
}
