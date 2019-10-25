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
        /// 获取表名和字段
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, List<TABLES_COLUMNS>>> GetTableNameAndFields()
        {
            var _TableNames = (await this.GetAllTable()).ToList();

            var dic = new Dictionary<string, List<TABLES_COLUMNS>>();

            for (int i = 0; i < _TableNames.Count; i++)
            {
                var item = _TableNames[i];
                var _Cols = (await this.GetColsByTableName(item));
                dic[item] = _Cols;
            }

            return dic;
        }

        /// <summary>
        /// 创建 Model 代码
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public async Task<string> CreateModelCode(string TableName, string Temp)
        {
            var _Cols = await this.GetColsByTableName(TableName);

            var _Code = Temp.ToString();
            var _ClassName = TableName;
            var _Fields = new StringBuilder();

            foreach (var item in _Cols)
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
                    _Fields.Append("\t[Field(\"ID\", IsKey = true)]\r\n");
                }
                else
                {
                    if (item.COLUMN_NAME.Contains("_CreateTime") && _Type == "DateTime?")
                        _Fields.Append("\t[Field(\"创建时间\", IsIgnore = true)]\r\n");
                    else
                        _Fields.Append("\t[Field(\"" + item.COLUMN_NAME + "\")]\r\n");
                }
                _Fields.Append("\tpublic " + _Type + " " + item.COLUMN_NAME + " { get; set; }\r\n\r\n");
            }

            _Code = _Code.Replace("<#ClassName#>", _ClassName);
            _Code = _Code.Replace("<#TableName#>", TableName);
            _Code = _Code.Replace("<#Fields#>", _Fields.ToString());

            return _Code.ToString();
        }

        /// <summary>
        /// 创建 Logic 代码
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Temp"></param>
        /// <returns></returns>
        public async Task<string> CreateLogicCode(string TableName, string Temp)
        {
            var _Cols = await this.GetColsByTableName(TableName);

            var _Code = Temp.ToString();
            var _ClassName = TableName + "Logic";
            var _KeyName = _Cols.Find(w => !string.IsNullOrEmpty(w.COLUMN_KEY));
            //
            var _NameCol = _Cols.Count > 2 ? _Cols[1] : null;
            var _Name = _NameCol == null ? "" : _NameCol.COLUMN_NAME;

            var _Select = _Cols.FindAll(w => string.IsNullOrEmpty(w.COLUMN_KEY));

            var _QueryCode = new StringBuilder().Append(@$"

                var IQuery = db
                    .Query<Sys_Function>()
                    .WhereIF(!string.IsNullOrEmpty(Search[""{_Name}""].ToStr()), w => w.t1.{_Name}.Contains(Search[""{_Name}""].ToStr()));

                if (string.IsNullOrEmpty(Search[""sortName""].ToStr()))
                    IQuery.OrderBy(w => new {{ w.t1.{TableName}_CreateTime }});
                else
                    IQuery.OrderBy(w => Search[""sortName""].ToStr() + "" "" + Search[""sortOrder""].ToStr());//前端自动排序

                IQuery.Select(w => new
                {{
                    {(_Select == null ? "" : "w.t1." + string.Join(",w.t1.", _Select.Select(w => w.COLUMN_NAME)))}
                    _ukid = w.t1.{_KeyName.COLUMN_NAME}
                }});

            ");

            _Code = _Code.Replace("<#ClassName#>", _ClassName);
            _Code = _Code.Replace("<#TableName#>", TableName);
            _Code = _Code.Replace("<#KeyName#>", _KeyName.COLUMN_NAME);
            _Code = _Code.Replace("<#QueryCode#>", _QueryCode.ToString());

            return _Code.ToString();
        }

        /// <summary>
        /// 创建 Controllers 代码
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Temp"></param>
        /// <returns></returns>
        public async Task<string> CreateControllersCode(string TableName, string Temp)
        {
            //var _Cols = await this.GetColsByTableName(TableName);
            var _Code = Temp.ToString();

            await Task.Run(() =>
            {
                var _ClassName = TableName + "Controller";

                _Code = _Code.Replace("<#ClassName#>", _ClassName);
                _Code = _Code.Replace("<#TableName#>", TableName);
            });

            return _Code.ToString();
        }

        /// <summary>
        /// 生产 DbSet 代码
        /// </summary>
        /// <returns></returns>
        public async Task<string> CreateDbSetCode()
        {
            //tabs.Register(typeof(Entitys.SysClass.Sys_Function));
            //tabs.Register(typeof(Entitys.SysClass.Sys_Menu));
            //tabs.Register(typeof(Entitys.SysClass.Sys_MenuFunction));
            //tabs.Register(typeof(Entitys.SysClass.Sys_Role));
            //tabs.Register(typeof(Entitys.SysClass.Sys_RoleMenuFunction));
            //tabs.Register(typeof(Entitys.SysClass.Sys_User));
            //tabs.Register(typeof(Entitys.SysClass.Sys_UserRole));

            StringBuilder _StringBuilder = new StringBuilder();
            var _TableNames = await this.GetAllTable();
            foreach (var item in _TableNames)
            {
                _StringBuilder.Append($"tabs.Register(typeof({item}));\r\n");
            }
            return _StringBuilder.ToString();
        }

        /// <summary>
        /// 根据表名称 获取列
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public async Task<List<TABLES_COLUMNS>> GetColsByTableName(string TableName)
        {
            string SqlString = @$"select a.COLUMN_NAME,case when a.COLUMN_NAME=b.COLUMN_NAME then 'YES' else null end COLUMN_KEY,a.DATA_TYPE 
from INFORMATION_SCHEMA.COLUMNS a 
left join INFORMATION_SCHEMA.KEY_COLUMN_USAGE b on a.TABLE_NAME=b.TABLE_NAME and b.CONSTRAINT_NAME like 'PK_%' 
where a.TABLE_NAME='{TableName}' ";
            return (await db.QueryAsync<TABLES_COLUMNS>(SqlString)).ToList();
        }

        /// <summary>
        /// 获取所有的表名称
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetAllTable()
        {
            string SqlString = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES order by TABLE_NAME";
            return (await db.QueryAsync<string>(SqlString)).ToList();
        }






    }
}
