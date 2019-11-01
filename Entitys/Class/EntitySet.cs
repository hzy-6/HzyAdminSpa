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
            var _types = new List<Type>();
            _types.Add(typeof(Sys_AppLog));
            _types.Add(typeof(Sys_Function));
            _types.Add(typeof(Sys_Menu));
            _types.Add(typeof(Sys_MenuFunction));
            _types.Add(typeof(Sys_Role));
            _types.Add(typeof(Sys_RoleMenuFunction));
            _types.Add(typeof(Sys_User));
            _types.Add(typeof(Sys_UserRole));
            _types.Add(typeof(Member));

            //
            //注册 Model 并解析 xml 注解
            //
            foreach (var item in _types)
            {
                tabs.Register(item, (propertyinfo, fielddescribe, tableType) =>
                {
                    fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
                });
            }

        }

    }
}
