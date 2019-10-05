using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Class
{
    using DbFrame.DbContext.SqlServer;
    using DbFrame.BaseClass;
    using System.Linq;
    using System.Reflection;
    using System.Collections;

    public class AppBase
    {
        public string ErrorMessage = "操作失败！";

        private static DbContextSqlServer _db;
        /// <summary>
        /// 数据访问对象
        /// </summary>
        public static DbContextSqlServer db
        {
            get
            {
                return _db;
            }
            set
            {
                if (_db == null) _db = value;
            }
        }

        protected void SetErrorMessage(string _ErrorMessage) => this.ErrorMessage = _ErrorMessage;

        /// <summary>
        /// 将多个数据对象转换为 Hashtable
        /// </summary>
        /// <param name="Models">除了实体以外的对象</param>
        /// <param name="ModelsPaparameter">实体</param>
        /// <returns></returns>
        public static Hashtable ObjectToHashtable(object Models, params object[] ModelsPaparameter)
        {
            Hashtable _Hashtable = new Hashtable();
            var type = Models.GetType();
            var _PropertyInfoList = type.GetProperties((BindingFlags.Instance | BindingFlags.Public));

            foreach (var item in _PropertyInfoList)
            {
                var _Value = item.GetValue(Models);
                _Hashtable.Add(item.Name, _Value);
            }

            if (ModelsPaparameter == null) return _Hashtable;

            foreach (var item in ModelsPaparameter)
            {
                type = item.GetType();
                _PropertyInfoList = type.GetProperties((BindingFlags.Instance | BindingFlags.Public));

                Tuple<string, List<FieldDescribe>> _Tuple = DbTable.GetTable(item);

                foreach (var _Item2 in _Tuple.Item2)
                {
                    if (_Hashtable.ContainsKey(_Item2.Name))
                    {
                        _Hashtable[$"{_Tuple.Item1}_" + _Item2.Name] = _Item2.Value;
                        continue;
                    }
                    _Hashtable[_Item2.Name] = _Item2.Value;
                }
            }

            return _Hashtable;
        }

        /// <summary>
        /// 将多个数据对象转换为 字典
        /// </summary>
        /// <param name="Models">除了实体以外的对象</param>
        /// <param name="ModelsPaparameter">实体</param>
        /// <returns></returns>
        public static Dictionary<string, object> ObjectToDictionary(object Models, params object[] ModelsPaparameter)
        {
            Dictionary<string, object> _Dictionary = new Dictionary<string, object>();
            var type = Models.GetType();
            var _PropertyInfoList = type.GetProperties((BindingFlags.Instance | BindingFlags.Public));

            foreach (var item in _PropertyInfoList)
            {
                var _Value = item.GetValue(Models);
                _Dictionary.Add(item.Name, _Value);
            }

            if (ModelsPaparameter == null) return _Dictionary;

            foreach (var item in ModelsPaparameter)
            {
                type = item.GetType();
                _PropertyInfoList = type.GetProperties((BindingFlags.Instance | BindingFlags.Public));

                Tuple<string, List<FieldDescribe>> _Tuple = DbTable.GetTable(item);

                foreach (var _Item2 in _Tuple.Item2)
                {
                    if (_Dictionary.ContainsKey(_Item2.Name))
                    {
                        _Dictionary[$"{_Tuple.Item1}_" + _Item2.Name] = _Item2.Value;
                        continue;
                    }
                    _Dictionary[_Item2.Name] = _Item2.Value;
                }
            }

            return _Dictionary;
        }






    }
}
