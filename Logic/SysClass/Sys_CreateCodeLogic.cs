using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SysClass
{
    using Toolkit;
    using Logic.Class;
    using DbFrame;
    using Entitys.Class;
    using Entitys.SysClass;

    public class Sys_CreateCodeLogic : BaseLogic
    {
        /// <summary>
        /// 获取 ZTree 需要的 表数据
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetZTreeAllTable()
        {
            string SqlString = @"select TABLE_NAME+' [表]' name,TABLE_NAME id,null pId from INFORMATION_SCHEMA.TABLES
union all
select case when CHARACTER_MAXIMUM_LENGTH is null then COLUMN_NAME+' [字段类型:'+DATA_TYPE+']'
when CHARACTER_MAXIMUM_LENGTH is not null then COLUMN_NAME+' [字段类型:'+DATA_TYPE+'('+CONVERT(varchar(10),CHARACTER_MAXIMUM_LENGTH)+')]' end
name,TABLE_NAME+'$~'+COLUMN_NAME id,TABLE_NAME from INFORMATION_SCHEMA.COLUMNS
order by id";
            return db.Query<Dictionary<string, object>>(SqlString).ToList();
        }

        /// <summary>
        /// 根据表名称 获取列
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<TABLES_COLUMNS> GetColByTable(string table)
        {
            string SqlString = @"select a.COLUMN_NAME,case when a.COLUMN_NAME=b.COLUMN_NAME then 'YES' else null end COLUMN_KEY,a.DATA_TYPE 
from INFORMATION_SCHEMA.COLUMNS a 
left join INFORMATION_SCHEMA.KEY_COLUMN_USAGE b on a.TABLE_NAME=b.TABLE_NAME and b.CONSTRAINT_NAME like 'PK_%' 
where a.TABLE_NAME='" + table + "' ";
            return db.Query<TABLES_COLUMNS>(SqlString).ToList();
        }

        /// <summary>
        /// 获取所有的表名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllTable()
        {
            string SqlString = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES order by TABLE_NAME";
            return db.Query<string>(SqlString).ToList();
        }

        public async Task Save(string Type, string Url, string Template, string Str, bool IsCreateAll, string TableName)
        {

            //if (System.IO.Directory.Exists(Url + "\\Model"))
            //{
            //    var dir = new System.IO.DirectoryInfo(Url + "\\");
            //    var fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
            //    foreach (var i in fileinfo)
            //    {
            //        if (i is System.IO.DirectoryInfo)            //判断是否文件夹
            //        {
            //            var subdir = new System.IO.DirectoryInfo(i.FullName);
            //            subdir.Delete(true);          //删除子目录和文件
            //        }
            //        else
            //        {
            //            System.IO.File.Delete(i.FullName);      //删除指定文件
            //        }
            //    }
            //    //System.IO.Directory.Delete(Url + "\\");
            //}

            await Task.Run(() =>
            {
                switch (Type)
                {
                    case "Model":
                        Url = (Url + "\\Model");
                        Template = Template + "Model\\Model.txt";
                        Str = string.IsNullOrEmpty(Str.ToStr()) ? "" : Str.ToStr();
                        var _Content = this.GetContent(Template, Url);
                        if (IsCreateAll)
                        {
                            foreach (var item in this.GetAllTable())
                            {
                                this.CreateModel(_Content, Url, Str, item);
                            }
                        }
                        else
                        {
                            this.CreateModel(_Content, Url, Str, TableName);
                        }
                        break;
                    case "Logic":
                        Url = (Url + "\\Logic");
                        Template = Template + "Logic\\Logic.txt";
                        Str = string.IsNullOrEmpty(Str.ToStr()) ? "Logic" : Str.ToStr();
                        _Content = this.GetContent(Template, Url);
                        if (IsCreateAll)
                        {
                            foreach (var item in this.GetAllTable())
                            {
                                this.CreateLogic(_Content, Url, Str, item);
                            }
                        }
                        else
                        {
                            this.CreateLogic(_Content, Url, Str, TableName);
                        }
                        break;
                    case "ViewsControllers":
                        //Controller
                        var _Url = (Url + "\\ViewsControllers");
                        var _Template = Template + "ViewsControllers\\Controllers.txt";
                        var _Str = string.IsNullOrEmpty(Str.ToStr()) ? "Controller" : Str.ToStr();
                        _Content = this.GetContent(_Template, _Url);

                        if (IsCreateAll)
                        {
                            foreach (var item in this.GetAllTable())
                            {
                                this.CreateControllers(_Content, _Url, _Str, item);
                            }
                        }
                        else
                        {
                            this.CreateControllers(_Content, _Url, _Str, TableName);
                        }

                        //Index.cshtml
                        _Url = (Url + "\\ViewsControllers");
                        _Template = Template + "ViewsControllers\\Index.txt";
                        _Str = string.IsNullOrEmpty(Str.ToStr()) ? "" : Str.ToStr();
                        _Content = this.GetContent(_Template, _Url);

                        if (IsCreateAll)
                        {
                            foreach (var item in this.GetAllTable())
                            {
                                this.CreateViews(_Content, _Url, _Str, item, "Index");
                            }
                        }
                        else
                        {
                            this.CreateViews(_Content, _Url, _Str, TableName, "Index");
                        }

                        //Info.cshtml
                        _Url = (Url + "\\ViewsControllers");
                        _Template = Template + "ViewsControllers\\Info.txt";
                        _Str = string.IsNullOrEmpty(Str.ToStr()) ? "" : Str.ToStr();
                        _Content = this.GetContent(_Template, _Url);

                        if (IsCreateAll)
                        {
                            foreach (var item in this.GetAllTable())
                            {
                                this.CreateViews(_Content, _Url, _Str, item, "Info");
                            }
                        }
                        else
                        {
                            this.CreateViews(_Content, _Url, _Str, TableName, "Info");
                        }


                        break;
                    default:
                        break;
                }

            });


        }

        private void CreateModel(string Content, string Url, string Str, string TableName)
        {
            var ClassName = TableName + Str;
            Content = Content.Replace("<#ClassName#>", ClassName);
            Content = Content.Replace("<#TableName#>", TableName);
            var _TABLES_COLUMNS = this.GetColByTable(TableName);
            var KeyName = _TABLES_COLUMNS.Find(w => !string.IsNullOrEmpty(w.COLUMN_KEY));
            //if (KeyName == null) throw new MessageBox("表》" + TableName + "未设置主键");
            if (KeyName == null)
            {
                KeyName = _TABLES_COLUMNS.FirstOrDefault();
            }

            Content = Content.Replace("<#KeyName#>", KeyName.COLUMN_NAME);

            StringBuilder _StringBuilder = new StringBuilder();
            foreach (var item in _TABLES_COLUMNS)
            {
                var _Type = string.Empty;
                var _Key = item.COLUMN_KEY;
                switch (item.DATA_TYPE)
                {
                    case "uniqueidentifier":
                        _Type = !string.IsNullOrEmpty(_Key) ? "Guid" : "Guid?";
                        break;
                    case "bit":
                    case "int":
                        _Type = !string.IsNullOrEmpty(_Key) ? "int" : "int?";
                        break;
                    case "datetime":
                        _Type = "DateTime?";
                        break;
                    case "float":
                        _Type = "float?";
                        break;
                    case "money":
                        _Type = "double?";
                        break;
                    case "decimal":
                        _Type = "decimal?";
                        break;
                    default:
                        _Type = "string";
                        break;
                }

                if (!string.IsNullOrEmpty(_Key))
                {
                    _StringBuilder.Append("\t\t[Field(\"ID\", IsKey = true)]\r\n");
                }
                else
                {
                    if (item.COLUMN_NAME.Contains("_CreateTime") && _Type == "DateTime?")
                        _StringBuilder.Append("\t\t[Field(\"创建时间\", IsIgnore = true)]\r\n");
                    else
                        _StringBuilder.Append("\t\t[Field(\"" + item.COLUMN_NAME + "\")]\r\n");
                }
                _StringBuilder.Append("\t\tpublic " + _Type + " " + item.COLUMN_NAME + " { get; set; }\r\n\r\n");
            }

            Content = Content.Replace("<#Filds#>", _StringBuilder.ToString());
            var _Path = Url + "\\" + ClassName + ".cs";
            if (System.IO.File.Exists(_Path)) System.IO.File.Delete(_Path);
            System.IO.File.WriteAllText(_Path, Content, Encoding.UTF8);
        }

        private void CreateLogic(string Content, string Url, string Str, string TableName)
        {
            var ClassName = TableName + Str;
            Content = Content.Replace("<#ClassName#>", ClassName);
            Content = Content.Replace("<#TableName#>", TableName);
            var _TABLES_COLUMNS = this.GetColByTable(TableName);
            var KeyName = _TABLES_COLUMNS.Find(w => !string.IsNullOrEmpty(w.COLUMN_KEY));
            //if (KeyName == null) throw new MessageBox("表》" + TableName + "未设置主键");
            if (KeyName == null)
            {
                KeyName = _TABLES_COLUMNS.FirstOrDefault();
            }

            Content = Content.Replace("<#KeyName#>", KeyName.COLUMN_NAME);
            var _Path = Url + "\\" + ClassName + ".cs";
            if (System.IO.File.Exists(_Path)) System.IO.File.Delete(_Path);
            System.IO.File.WriteAllText(_Path, Content, Encoding.UTF8);
        }

        private void CreateControllers(string Content, string Url, string Str, string TableName)
        {
            var ClassName = TableName + Str;
            Content = Content.Replace("<#ClassName#>", ClassName);
            Content = Content.Replace("<#TableName#>", TableName);
            var _TABLES_COLUMNS = this.GetColByTable(TableName);
            var KeyName = _TABLES_COLUMNS.Find(w => !string.IsNullOrEmpty(w.COLUMN_KEY));
            //if (KeyName == null) throw new MessageBox("表》" + TableName + "未设置主键");
            if (KeyName == null)
            {
                KeyName = _TABLES_COLUMNS.FirstOrDefault();
            }

            Content = Content.Replace("<#KeyName#>", KeyName.COLUMN_NAME);
            var _Path = Url + "\\" + ClassName + ".cs";
            if (System.IO.File.Exists(_Path)) System.IO.File.Delete(_Path);
            System.IO.File.WriteAllText(_Path, Content, Encoding.UTF8);
        }

        private void CreateViews(string Content, string Url, string Str, string TableName, string FileName)
        {
            var ClassName = TableName + Str;
            Content = Content.Replace("<#ClassName#>", ClassName);
            Content = Content.Replace("<#TableName#>", TableName);
            var _TABLES_COLUMNS = this.GetColByTable(TableName);
            var KeyName = _TABLES_COLUMNS.Find(w => !string.IsNullOrEmpty(w.COLUMN_KEY));
            //if (KeyName == null) throw new MessageBox("表》" + TableName + "未设置主键");
            if (KeyName == null)
            {
                KeyName = _TABLES_COLUMNS.FirstOrDefault();
            }

            Content = Content.Replace("<#KeyName#>", KeyName.COLUMN_NAME);

            var _File = Url + "\\" + TableName;

            if (!System.IO.Directory.Exists(_File))
            {
                System.IO.Directory.CreateDirectory(_File);
            }
            var _Path = _File + "\\" + FileName + ".cshtml";
            if (System.IO.File.Exists(_Path)) System.IO.File.Delete(_Path);
            System.IO.File.WriteAllText(_File + "\\" + FileName + ".cshtml", Content, Encoding.UTF8);
        }


        private string GetContent(string TempUrl, string Url)
        {
            if (System.IO.Directory.Exists(Url)) System.IO.Directory.Delete(Url, true);

            System.IO.Directory.CreateDirectory(Url);

            if (!System.IO.File.Exists(TempUrl))
                throw new MessageBox("模板文件不存在");

            return System.IO.File.ReadAllText(TempUrl, Encoding.UTF8);
        }

        /// <summary>
        /// 生产 DbSet 代码
        /// </summary>
        /// <returns></returns>
        public List<string> CreateDbSetCode()
        {
            //tabs.Register(typeof(Entitys.SysClass.Sys_Function));
            //tabs.Register(typeof(Entitys.SysClass.Sys_Menu));
            //tabs.Register(typeof(Entitys.SysClass.Sys_MenuFunction));
            //tabs.Register(typeof(Entitys.SysClass.Sys_Role));
            //tabs.Register(typeof(Entitys.SysClass.Sys_RoleMenuFunction));
            //tabs.Register(typeof(Entitys.SysClass.Sys_User));
            //tabs.Register(typeof(Entitys.SysClass.Sys_UserRole));

            List<string> list = new List<string>();
            foreach (var item in this.GetAllTable())
            {
                list.Add($"tabs.Register(typeof({item}));");
            }
            return list;
        }


    }
}
