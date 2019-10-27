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

            tabs.Register(typeof(Sys_AppLog), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            tabs.Register(typeof(Sys_Function), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            tabs.Register(typeof(Sys_Menu), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            tabs.Register(typeof(Sys_MenuFunction), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            tabs.Register(typeof(Sys_Role), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            tabs.Register(typeof(Sys_RoleMenuFunction), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            tabs.Register(typeof(Sys_User), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            tabs.Register(typeof(Sys_UserRole), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
            //
            tabs.Register(typeof(Member), (propertyinfo, fielddescribe, tableType) =>
            {
                fielddescribe.DisplayName = Toolkit.ReadXmlSummary.XMLForMember(propertyinfo)?.InnerText?.Trim()?.Split("=>")?[0];
            });
        }

    }
}
