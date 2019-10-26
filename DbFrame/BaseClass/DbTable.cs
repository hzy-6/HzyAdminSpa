using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DbFrame.BaseClass
{


    /// <summary>
    /// 注册表类
    /// </summary>
    public class DbTable
    {
        private static ConcurrentDictionary<string, List<FieldDescribe>> Tables { get; set; } = new ConcurrentDictionary<string, List<FieldDescribe>>();
        private static string Error = "请在程序启动时注册你的Models";

        /// <summary>
        /// 注册表
        /// </summary>
        /// <param name="TableType"></param>
        public void Register(Type TableType)
        {
            var _TableName = TableType.Name;
            var _TableAttribute = TableType.GetCustomAttribute<TableAttribute>() as TableAttribute;
            if (_TableAttribute != null) _TableName = _TableAttribute.TableName;

            if (Tables.ContainsKey(_TableName)) throw new DbFrameException($"表 {_TableName} 已经注册过!");

            var _Fields = TableType.GetProperties();

            var list = new List<FieldDescribe>();
            foreach (var item in _Fields)
            {
                var _FieldAttribute = item.GetCustomAttribute<FieldAttribute>() as FieldAttribute;
                var _FieldDescribe = new FieldDescribe();

                if (_FieldAttribute != null)
                {
                    _FieldDescribe.Alias = _FieldAttribute.Alias;
                    _FieldDescribe.IsKey = _FieldAttribute.IsKey;
                    _FieldDescribe.IsIdentity = _FieldAttribute.IsIdentity;
                    _FieldDescribe.IsIgnore = _FieldAttribute.IsIgnore;
                    _FieldDescribe.IsColumn = _FieldAttribute.IsColumn;
                }
                _FieldDescribe.Name = item.Name;
                _FieldDescribe.Type = item.PropertyType;

                list.Add(_FieldDescribe);
            }

            //检测有无 Key
            //if (list.FirstOrDefault(w => w.IsKey) == null) throw new DbFrameException($"表 {_TableName} 未设置主键!");

            Tables[_TableName] = list;
        }

        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <param name="TableType"></param>
        /// <returns></returns>
        public static Tuple<string, List<FieldDescribe>> GetTable(Type TableType)
        {
            var _TableName = GetTableName(TableType);

            if (!Tables.ContainsKey(_TableName)) throw new DbFrameException($"表 {_TableName} 没有注册!{Error}");

            return new Tuple<string, List<FieldDescribe>>(_TableName, Tables[GetTableName(TableType)]);
        }

        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <param name="TableType"></param>
        /// <returns></returns>
        public static Tuple<string, List<FieldDescribe>> GetTable(string _TableName)
        {
            if (!Tables.ContainsKey(_TableName)) throw new DbFrameException($"表 {_TableName} 没有注册!{Error}");

            return new Tuple<string, List<FieldDescribe>>(_TableName, Tables[_TableName]);
        }

        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <param name="TableType"></param>
        /// <returns></returns>
        public static Tuple<string, List<FieldDescribe>> GetTable<T>(T Model)
        {
            var TableType = Model.GetType();
            var _TableName = GetTableName(TableType);

            if (!Tables.ContainsKey(_TableName)) throw new DbFrameException($"表 {_TableName} 没有注册!{Error}");

            var _Tuple = new Tuple<string, List<FieldDescribe>>(_TableName, Tables[GetTableName(TableType)]);

            foreach (var item in TableType.GetProperties())
            {
                var Entity = _Tuple.Item2.FirstOrDefault(w => w.Name == item.Name);
                if (Entity == null) continue;
                Entity.Value = item.GetValue(Model);
            }

            return _Tuple;
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="TableType"></param>
        /// <returns></returns>
        public static string GetTableName(Type TableType)
        {
            var _TableName = TableType.Name;
            var _TableAttribute = TableType.GetCustomAttribute<TableAttribute>() as TableAttribute;
            if (_TableAttribute != null) _TableName = _TableAttribute.TableName;
            return _TableName;
        }

        /// <summary>
        /// 获取所有的表信息
        /// </summary>
        /// <returns></returns>
        public static ConcurrentDictionary<string, List<FieldDescribe>> GetAll()
        {
            return Tables;
        }

    }

    /// <summary>
    /// 字段描述
    /// </summary>
    public class FieldDescribe
    {
        public FieldDescribe()
        {
            this.Name = string.Empty;
            this.Alias = string.Empty;
            this.IsKey = false;
            this.IsIdentity = false;
            this.IsIgnore = false;
            this.IsColumn = true;
            this.Type = null;
            this.Value = null;
        }

        public string Name { get; set; }

        public string Alias { get; set; }

        public bool IsKey { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsIgnore { get; set; }

        public bool IsColumn { get; set; }

        public Type Type { get; set; }

        public object Value { get; set; }

    }





}
