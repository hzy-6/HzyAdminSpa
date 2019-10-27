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
        private static ConcurrentDictionary<string, List<FieldDescribe>> Tables { get; } = new ConcurrentDictionary<string, List<FieldDescribe>>();
        private static string Error = "请在程序启动时注册你的Models";

        /// <summary>
        /// 注册表
        /// </summary>
        /// <param name="TableType"></param>
        public void Register(Type TableType, Action<PropertyInfo, FieldDescribe, Type> Call = null)
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
                    _FieldDescribe.IsKey = _FieldAttribute.IsKey;
                    _FieldDescribe.IsIdentity = _FieldAttribute.IsIdentity;
                    _FieldDescribe.IsIgnore = _FieldAttribute.IsIgnore;
                    _FieldDescribe.IsColumn = _FieldAttribute.IsColumn;
                }
                _FieldDescribe.TableFieldName = string.IsNullOrWhiteSpace(_FieldAttribute?.TableFieldName) ? item.Name : _FieldAttribute?.TableFieldName;
                _FieldDescribe.Name = item.Name;
                _FieldDescribe.Type = item.PropertyType;

                Call?.Invoke(item, _FieldDescribe, TableType);

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
        public static Tuple<string, List<FieldDescribe>> GetTable(Type TableType) => GetTable(GetTableName(TableType));

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
        public static ConcurrentDictionary<string, List<FieldDescribe>> GetAll() => Tables;

    }

    /// <summary>
    /// 字段描述
    /// </summary>
    public class FieldDescribe
    {
        /// <summary>
        /// 实体属性名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 字段在数据库中的名称 如果设置了 以设置为准
        /// </summary>
        public string TableFieldName { get; set; } = string.Empty;

        /// <summary>
        /// 显示名称 一般用于设置中文 ，该字段在 程序 注册时 自动 通过xml 配置
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        public bool IsKey { get; set; } = false;

        public bool IsIdentity { get; set; } = false;

        public bool IsIgnore { get; set; } = false;

        public bool IsColumn { get; set; } = true;

        public Type Type { get; set; } = null;

        public object Value { get; set; } = null;

    }





}
