using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Class
{
    using DbFrame.BaseClass;
    using Entitys.SysClass;
    using Entitys;

    public class EntitySet
    {

        public static void Register(DbTable tabs)
        {

            tabs.Register(typeof(Sys_AppLog));
            tabs.Register(typeof(Sys_Function));
            tabs.Register(typeof(Sys_Menu));
            tabs.Register(typeof(Sys_MenuFunction));
            tabs.Register(typeof(Sys_Role));
            tabs.Register(typeof(Sys_RoleMenuFunction));
            tabs.Register(typeof(Sys_User));
            tabs.Register(typeof(Sys_UserRole));
        }

    }
}
