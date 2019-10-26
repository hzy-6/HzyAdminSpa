using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DbFrame
{
    //
    using System.Linq.Expressions;
    using System.Reflection;
    using DbFrame.BaseClass;
    using System.Text;

    public static class DbMappingExtension
    {
        /// <summary>
        /// DataRow 转换 实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this DataRow dr) where T : class, new()
        {
            var _Entity = Parser.CreateInstance<T>();
            var list = _Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (list.Length == 0) throw new Exception("找不到任何 公共属性！");

            foreach (var item in list)
            {
                string AttrName = item.Name;
                if (!dr.Table.Columns.Contains(AttrName)) continue;
                if (dr[AttrName] == DBNull.Value) continue;
                item.SetValue(_Entity, dr[AttrName], null);
            }
            return _Entity;
        }

        /// <summary>
        /// IDataReader 转换 实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this IDataReader _IDataReader) where T : class, new()
        {
            var _Entity = Parser.CreateInstance<T>();
            var list = _Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (list.Length == 0) throw new Exception("找不到任何 公共属性！");

            List<string> field = new List<string>(_IDataReader.FieldCount);
            for (int i = 0; i < _IDataReader.FieldCount; i++)
            {
                field.Add(_IDataReader.GetName(i));
            }

            foreach (var item in list)
            {
                string AttrName = item.Name;
                if (!field.Contains(AttrName)) continue;
                if (_IDataReader[AttrName] == DBNull.Value) continue;
                item.SetValue(_Entity, _IDataReader[AttrName], null);
            }
            return _Entity;
        }

        /// <summary>
        /// 将 datatable 转换为 list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            var list = new List<T>();

            var _Entity = Parser.CreateInstance<T>();
            var propertyInfo = _Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (DataRow dr in table.Rows)
            {
                _Entity = Parser.CreateInstance<T>();
                foreach (var item in propertyInfo)
                {
                    string AttrName = item.Name;
                    if (!dr.Table.Columns.Contains(AttrName)) continue;
                    if (dr[AttrName] == DBNull.Value) continue;
                    item.SetValue(_Entity, dr[AttrName], null);
                }
                list.Add(_Entity);
            }
            return list;
        }

        /// <summary>
        /// datatable 转换为 List<Dictionary<string,object>>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> ToList(this DataTable table, string DateTimeStringFormat = "yyyy-MM-dd HH:mm", Action<Type, object> Success = null)
        {
            var list = new List<Dictionary<string, object>>();
            var dic = new Dictionary<string, object>();
            foreach (DataRow dr in table.Rows)
            {
                if (dic != null) dic = new Dictionary<string, object>();
                foreach (DataColumn dc in table.Columns)
                {
                    object value = null;
                    if (dr[dc.ColumnName] != DBNull.Value)
                        value = (dc.DataType == typeof(DateTime)) ? Convert.ToDateTime(dr[dc.ColumnName]).ToString(DateTimeStringFormat) : dr[dc.ColumnName];
                    Success?.Invoke(dc.DataType, value);
                    dic.Add(dc.ColumnName, value);
                }
                list.Add(dic);
            }
            return list;
        }

        #region IDataReader TO List<Dictionary<string, object>> And DataTable

        /// <summary>
        /// 将 IDataReader 对象转换为 List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_IDataReader"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this IDataReader _IDataReader)
        {
            if (_IDataReader.IsClosed) throw new DbFrameException("IDataReader 对象连接已关闭！");

            var res = new List<T>();

            var _Entity = Parser.CreateInstance<T>();
            var propertyInfo = _Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            List<string> field = new List<string>(_IDataReader.FieldCount);
            for (int i = 0; i < _IDataReader.FieldCount; i++)
            {
                field.Add(_IDataReader.GetName(i));
            }

            while (_IDataReader.Read())
            {
                _Entity = Parser.CreateInstance<T>();
                foreach (var item in propertyInfo)
                {
                    string AttrName = item.Name;
                    if (!field.Contains(AttrName)) continue;
                    if (_IDataReader[AttrName] == DBNull.Value) continue;
                    item.SetValue(_Entity, _IDataReader[AttrName], null);
                }
                res.Add(_Entity);
            }

            return res;
        }

        /// <summary>
        /// 将IDataReader对象转换为字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_IDataReader"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> ToList(this IDataReader _IDataReader)
        {
            if (_IDataReader.IsClosed) throw new DbFrameException("IDataReader 对象连接已关闭！");

            var res = new List<Dictionary<string, object>>();

            List<string> field = new List<string>(_IDataReader.FieldCount);
            for (int i = 0; i < _IDataReader.FieldCount; i++)
            {
                field.Add(_IDataReader.GetName(i));
            }

            while (_IDataReader.Read())
            {
                var dic = new Dictionary<string, object>();
                foreach (var item in field)
                {
                    dic[item] = (_IDataReader[item] == DBNull.Value) ? null : _IDataReader[item];
                }

                res.Add(dic);
            }

            return res;
        }

        /// <summary>
        /// IDataReader 转换为 DataTable
        /// </summary>
        /// <param name="_IDataReader"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this IDataReader _IDataReader)
        {
            DataTable dt = new DataTable();
            dt.Load(_IDataReader);
            return dt;
        }

        #endregion



        /// <summary>
        /// 将匿名对象转换为字典
        /// </summary>
        /// <param name="Attribute"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDic<T>(this T Attribute) where T : class, new()
        {
            var di = new Dictionary<string, object>();

            Type ty = Attribute.GetType();

            var fields = ty.GetProperties().ToList();

            foreach (var item in fields) di.Add(item.Name, item.GetValue(Attribute).ToString());

            return di;
        }

        /// <summary>
        /// 两实体映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="M"></typeparam>
        /// <param name="Entity"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static M ToNewEntity<T, M>(this T Entity, M Model) where T : class, new()
        {
            //old
            var oldList = Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var newList = Model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var oldM in oldList)
            {
                foreach (var newM in newList)
                {
                    if (oldM.Name != newM.Name) continue;
                    if (oldM.PropertyType == typeof(bool) & (newM.PropertyType == typeof(int) | newM.PropertyType == typeof(int?)))
                    {
                        var _Value = (bool)oldM.GetValue(Entity);
                        newM.SetValue(Model, _Value ? 1 : 0);
                    }
                    else if (newM.PropertyType == typeof(bool) & (oldM.PropertyType == typeof(int) | oldM.PropertyType == typeof(int?)))
                    {
                        var _Value = (int?)oldM.GetValue(Entity);
                        newM.SetValue(Model, _Value == null ? false : (_Value == 1 ? true : false));
                    }
                    else
                    {
                        newM.SetValue(Model, oldM.GetValue(Entity));
                    }
                }
            }

            return Model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="M"></typeparam>
        /// <param name="EntityList"></param>
        /// <param name="ModelList"></param>
        /// <returns></returns>
        public static List<M> ToNewList<T, M>(this List<T> EntityList, List<M> ModelList)
            where M : class, new()
            where T : class, new()
        {
            foreach (var item in EntityList)
            {
                var _M = new M();
                item.ToNewEntity(_M);
                ModelList.Add(_M);
            }
            return ModelList;
        }

        /************sql****************/
        /// <summary>
        /// 在 拉姆达表达式 where 表达式中使用 w => w.In(w.t1.Member_ID, guidsArray)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool In<T, T1>(this HzyTuple obj, T1 field, List<T> array) => true;

        /// <summary>
        /// 在 拉姆达表达式 where 表达式中使用 w => w.NotIn(w.t1.Member_ID, guidsArray)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool NotIn<T, T1>(this HzyTuple obj, T1 field, List<T> array) => true;

        /// <summary>
        /// 一般在Where 条件中使用 例如 : w.SqlStr("convert(varchar(50),UserName,23)")
        /// 
        /// 一般用来支持这种语法》CONVERT(varchar(100), GETDATE(), 23)    -- 2006-05-16 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SqlStr(this HzyTuple obj, string value) => true;

        /// <summary>
        /// 一般在Where 条件中使用 例如 : w.SqlStr("convert(varchar(50),UserName,23)")
        /// 
        /// 一般用来支持这种语法》CONVERT(varchar(100), GETDATE(), 23)    -- 2006-05-16 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TReturn SqlStr<TReturn>(this HzyTuple obj, string value) => default(TReturn);

        /// <summary>
        /// UNION 操作符选取不同的值。如果允许重复的值，请使用 UNION ALL。 
        /// </summary>
        /// <param name="Sql1"></param>
        /// <param name="Sql2"></param>
        /// <returns></returns>
        public static SQL Union(this SQL Sql1, SQL Sql2)
        {
            StringBuilder _StringBuilder = new StringBuilder();
            var _ParameterList = Sql1.Parameter.Concat(Sql2.Parameter).ToList();
            _StringBuilder.Append(Sql1.Code);
            _StringBuilder.Append(" UNION ");
            _StringBuilder.Append(Sql2.Code);

            var res = new SQL();
            res.Code = _StringBuilder;
            res.Parameter = _ParameterList;
            return res;
        }

        /// <summary>
        /// UNION ALL 命令会列出所有的值。
        /// </summary>
        /// <param name="Sql1"></param>
        /// <param name="Sql2"></param>
        /// <returns></returns>
        public static SQL UnionAll(this SQL Sql1, SQL Sql2)
        {
            StringBuilder _StringBuilder = new StringBuilder();
            var _ParameterList = Sql1.Parameter.Concat(Sql2.Parameter).ToList();
            _StringBuilder.Append(Sql1.Code);
            _StringBuilder.Append(" UNION ALL ");
            _StringBuilder.Append(Sql2.Code);

            var res = new SQL();
            res.Code = _StringBuilder;
            res.Parameter = _ParameterList;
            return res;
        }






    }



    public class Parser
    {
        /// <summary>
        /// 将 Model 转换为 MemberInitExpression 类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static MemberInitExpression ModelToMemberInitExpression<T>(T Model)
        {
            var proInfo = Parser.GetPropertyInfos(typeof(T));

            var list = new List<MemberBinding>();

            foreach (var item in proInfo) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(Model), item.PropertyType)));

            var newExpr = Expression.New(typeof(T));

            return Expression.MemberInit(newExpr, list);
        }

        /// <summary>
        /// 获取 PropertyInfo 集合
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_bindingFlags"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertyInfos(Type _type, BindingFlags _bindingFlags = (BindingFlags.Instance | BindingFlags.Public)) => _type.GetProperties(_bindingFlags);

        /// <summary>
        /// 创建 对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInstance<T>()
        {
            var _Type = typeof(T);
            if (_Type.IsValueType || typeof(T) == typeof(string))
                return default(T);
            return (T)Activator.CreateInstance(_Type);
        }

        /// <summary>
        /// 获取 对象 中 某个属性得 标记
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_type"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(Type _type, string _name)
            where T : Attribute
            => Parser.GetPropertyInfo(_type, _name).GetCustomAttribute(typeof(T)) as T;

        /// <summary>
        /// 获取 PropertyInfo 对象
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo(Type _type, string _name) => _type.GetProperty(_name);

        /// <summary>
        /// 获取 TableAttribute
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static TableAttribute GetTableAttribute(Type _type) => (TableAttribute)Attribute.GetCustomAttributes(_type, true).Where(item => item is TableAttribute).FirstOrDefault();

        /// <summary>
        /// Eval
        /// </summary>
        /// <param name="_Expression"></param>
        /// <returns></returns>
        public static object Eval(Expression _Expression)
        {
            var cast = Expression.Convert(_Expression, typeof(object));
            return Expression.Lambda<Func<object>>(cast).Compile().Invoke();
        }

        /// <summary>
        /// 根据实体对象 的 ID 创建 Expression<Func<HzyTuple<T>, bool>> 表达式树 例如： Lambda = ( w=>w.t1.Key==Guid.Empty )
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_KeyName"></param>
        /// <param name="_KeyValue"></param>
        /// <returns></returns>
        public static Expression<Func<HzyTuple<T>, bool>> WhereById<T>(string _KeyName, object _KeyValue, string _ParName = "_Where_Parameter")
        {
            //创建 Where Lambda表达式树
            var _Type = typeof(HzyTuple<T>);
            var _Parmeter = Expression.Parameter(_Type, "w");
            var _Where_Parameter = Expression.Parameter(_Type, _ParName);
            var _Property = _Type.GetProperty(nameof(HzyTuple<T>.t1));
            //元组参数
            var _Left = Expression.Property(_Parmeter, _Property);
            //字段名
            var _KeyProperty = _Property.PropertyType.GetProperty(_KeyName);
            //w=>w.t1.Key
            var _NewLeft = Expression.Property(_Left, _KeyProperty);
            //==Guid.Empty
            var _Sign = _KeyValue == null;
            if (!_Sign) _Sign = (_KeyValue is string & string.IsNullOrWhiteSpace(_KeyValue.ToString()));
            if (_KeyProperty.PropertyType == typeof(Guid) & _Sign) _KeyValue = Guid.Empty;
            if (_KeyProperty.PropertyType == typeof(int) & _Sign) _KeyValue = Int32.MinValue;
            if (_KeyProperty.PropertyType == typeof(Guid) & !_Sign) _KeyValue = Guid.Parse(_KeyValue.ToString());
            if (_KeyProperty.PropertyType == typeof(int) & !_Sign) _KeyValue = Int32.Parse(_KeyValue.ToString());
            try
            {
                var _Where_Body = Expression.Equal(_NewLeft, Expression.Constant(_KeyValue, _KeyProperty.PropertyType));
                return Expression.Lambda<Func<HzyTuple<T>, bool>>(_Where_Body, _Where_Parameter);
            }
            catch (Exception ex)
            {
                if (_KeyProperty.PropertyType != _KeyValue.GetType())
                    throw new DbFrameException("请将主键值 转换为 正确的类型值！");
                else
                    throw ex;
            }
        }


    }


    public class DbSettings
    {

        /// <summary>
        /// 默认连接字符串
        /// </summary>
        public static string DefaultConnectionString { get; set; }

        /// <summary>
        /// 关键字处理 函数
        /// </summary>
        public static Func<string, string> KeywordHandle;

    }

    /// <summary>
    /// 多表连接类型
    /// </summary>
    public enum EJoinType
    {
        /// <summary>
        /// join
        /// </summary>
        JOIN,

        /// <summary>
        /// 内连接 inner join
        /// </summary>
        INNER_JOIN,

        /// <summary>
        /// 左连接 left join
        /// </summary>
        LEFT_JOIN,

        /// <summary>
        /// 左外连接 left outer join
        /// </summary>
        LEFT_OUTER_JOIN,

        /// <summary>
        /// 右连接 right join
        /// </summary>
        RIGHT_JOIN,

        /// <summary>
        /// 右外连接 right outer join
        /// </summary>
        RIGHT_OUTER_JOIN,

        /// <summary>
        /// 全连接 full join
        /// </summary>
        FULL_JOIN,

        /// <summary>
        /// 全外连接 full outer join
        /// </summary>
        FULL_OUTER_JOIN,

        /// <summary>
        /// 交叉连接 cross join
        /// </summary>
        CROSS_JOIN
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbContextType
    {
        SqlServer,
        MySql,
        Oracle,
        PostgreSQL
    }


}
