using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Class
{
    using DbFrame;
    using DbFrame.BaseClass;
    using Entitys.Attributes;
    using System.Reflection;
    using Toolkit;

    /// <summary>
    /// 检查模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CheckModel<T> : BaseLogic
    {
        public bool Check(T _Model)
        {
            var list = Parser.GetPropertyInfos(_Model.GetType());

            foreach (var item in list)
            {
                if (!this.Start(item, _Model))
                    return false;
            }

            return true;
        }

        private bool Start(PropertyInfo item, T _Model)
        {
            var DisplayName = Parser.GetAttribute<FieldAttribute>(_Model.GetType(), item.Name).Alias;
            var Value = item.GetValue(_Model);
            if (!CRequired(item, _Model, DisplayName, Value))
                return false;
            if (!CStringLength(item, _Model, DisplayName, Value))
                return false;
            if (!CRegularExpression(item, _Model, DisplayName, Value))
                return false;
            if (!CCompare(item, _Model, DisplayName, Value))
                return false;
            if (!CRepeat(item, _Model, DisplayName, Value))
                return false;
            if (!SetNumber(item, _Model, DisplayName, Value))
                return false;
            return true;
        }

        /// <summary>
        /// 非空验证
        /// </summary>
        /// <param name="item"></param>
        /// <param name="_Model"></param>
        /// <param name="DisplayName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool CRequired(PropertyInfo item, T _Model, string DisplayName, object Value)
        {
            var fileName = item.Name;
            var _Attribute = Parser.GetAttribute<CRequiredAttribute>(_Model.GetType(), item.Name);
            if (_Attribute == null)
                return true;
            if (Value == null)
                return SetErrorMessage(_Attribute.ErrorMessage, DisplayName + "不能为空", DisplayName);
            if (item.PropertyType == typeof(string) && string.IsNullOrEmpty(Value.ToStr()))
                return SetErrorMessage(_Attribute.ErrorMessage, DisplayName + "不能为空", DisplayName);
            if (item.PropertyType == typeof(Guid?) && Value.ToGuid() == Guid.Empty)
                return SetErrorMessage(_Attribute.ErrorMessage, DisplayName + "不能为空", DisplayName);
            return true;
        }

        /// <summary>
        /// 字符串长度验证
        /// </summary>
        /// <param name="item"></param>
        /// <param name="_Model"></param>
        /// <param name="DisplayName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool CStringLength(PropertyInfo item, T _Model, string DisplayName, object Value)
        {
            if (Value == null) return true;
            //获取有特性标记的属性【字符串长度验证】
            var _Attribute = Parser.GetAttribute<CStringLengthAttribute>(_Model.GetType(), item.Name);
            if (_Attribute != null && (Value.ToString().Length < _Attribute.MinLength || Value.ToString().Length > _Attribute.MaxLength))
                return SetErrorMessage(_Attribute.ErrorMessage, DisplayName + "长度介于" + _Attribute.MinLength + "-" + _Attribute.MaxLength + "之间", DisplayName);
            return true;
        }

        /// <summary>
        /// 正则表达式验证
        /// </summary>
        /// <param name="item"></param>
        /// <param name="_Model"></param>
        /// <param name="DisplayName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool CRegularExpression(PropertyInfo item, T _Model, string DisplayName, object Value)
        {
            if (Value == null) return true;
            //获取有特性标记的属性【正则表达式验证】
            var _Attribute = Parser.GetAttribute<CRegularExpressionAttribute>(_Model.GetType(), item.Name);
            if (_Attribute != null && !System.Text.RegularExpressions.Regex.IsMatch(Value.ToString(), _Attribute.Pattern))
                return SetErrorMessage(_Attribute.ErrorMessage, DisplayName + "格式不正确", DisplayName);
            return true;
        }

        /// <summary>
        /// 比较两字段值是否相同
        /// </summary>
        /// <param name="item"></param>
        /// <param name="_Model"></param>
        /// <param name="DisplayName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool CCompare(PropertyInfo item, T _Model, string DisplayName, object Value)
        {
            if (Value == null) return true;
            //获取有特性标记的属性【比较两字段值是否相同】
            var _Attribute = Parser.GetAttribute<CCompareAttribute>(_Model.GetType(), item.Name);
            if (_Attribute == null) return true;
            var list = Parser.GetPropertyInfos(_Model.GetType());
            foreach (var info in list)
            {
                var infoname = Parser.GetAttribute<CCompareAttribute>(_Model.GetType(), info.Name);
                if (info.Name.Equals(_Attribute.OtherProperty) && !info.GetValue(_Model).Equals(Value))
                    return SetErrorMessage(_Attribute.ErrorMessage, DisplayName + "的值与" + infoname + "不匹配", DisplayName);
            }
            return true;
        }

        /// <summary>
        /// 验证数据是否重复
        /// </summary>
        /// <param name="item"></param>
        /// <param name="_Model"></param>
        /// <param name="DisplayName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool CRepeat(PropertyInfo item, T _Model, string DisplayName, object Value)
        {
            if (Value == null) return true;
            var _TableInfo = DbTable.GetTable(_Model);
            string TableName = _TableInfo.Item1;
            var _KeyInfo = _TableInfo.Item2.Find(w => w.IsKey);
            //获取有特性标记的属性【非空】
            var _Attribute = Parser.GetAttribute<CRepeatAttribute>(_Model.GetType(), item.Name);
            if (_Attribute == null) return true;
            //取ID的值
            string KeyValue = string.Empty, KeyName = string.Empty;
            var list = Parser.GetPropertyInfos(_Model.GetType());
            KeyValue = _KeyInfo.Value.ToStr();
            KeyName = _KeyInfo.Name;
            string where = string.Empty;
            if (!string.IsNullOrEmpty(KeyValue) && !KeyValue.ToString().Equals(Guid.Empty.ToString()))
                where = " AND " + KeyName + "<>'" + KeyValue + "'";

            //判断条件，是否存在  || 自定义条件 语法  ：and filed1='{filed1}' ||
            if (!string.IsNullOrEmpty(_Attribute.Where))
            {
                foreach (var pi in list)
                {
                    if (_Attribute.Where.Contains("{" + pi.Name + "}"))
                    {
                        where += _Attribute.Where + " ";
                        where = where.Replace("{" + pi.Name + "}", pi.GetValue(_Model) == null ? "" : pi.GetValue(_Model).ToString());
                    }
                }
            }

            string sql = "SELECT COUNT(1) FROM " + TableName + " WHERE 1=1 AND " + item.Name + "='" + Value + "' " + where;
            if (db.QuerySingleOrDefault<int>(sql, null) > 0)
                return SetErrorMessage(_Attribute.ErrorMessage, DisplayName + "已存在", DisplayName);
            return true;
        }

        /// <summary>
        /// 设置编号
        /// </summary>
        /// <param name="item"></param>
        /// <param name="entity"></param>
        /// <param name="DisplayName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool SetNumber(PropertyInfo item, T entity, string DisplayName, object Value)
        {
            var _TableInfo = DbTable.GetTable(entity.GetType());
            string TableName = _TableInfo.Item1;
            var _KeyInfo = _TableInfo.Item2.Find(w => w.IsKey);
            //获取有特性标记的属性【编号】
            var sign = Parser.GetAttribute<CSetNumberAttribute>(entity.GetType(), item.Name);
            //
            if (sign != null)
            {
                var list = Parser.GetPropertyInfos(entity.GetType());
                var where = string.Empty;
                //where 处理
                if (!string.IsNullOrWhiteSpace(sign.Where))
                {
                    foreach (var pi in list)
                    {
                        if (sign.Where.Contains("{" + pi.Name + "}"))
                        {
                            where += sign.Where + " ";
                            where = where.Replace("{" + pi.Name + "}", pi.GetValue(entity) == null ? "" : pi.GetValue(entity).ToString());
                        }
                    }
                }

                //取ID的值
                string KeyValue = string.Empty;

                KeyValue = _KeyInfo.Value.ToStr();
                if (string.IsNullOrEmpty(KeyValue) || KeyValue.ToString().Equals(Guid.Empty.ToString()))
                {
                    var MaxNumber = db.QuerySingleOrDefault<int>($"SELECT ISNULL(MAX({item.Name}),0) FROM {TableName} Where 1=1 {where}", null) + 1;

                    if (MaxNumber == 0)
                        throw new AggregateException("设置编号错误：数据无法查出！");
                    if (item.PropertyType == typeof(int) || item.PropertyType == typeof(int?))
                        item.SetValue(entity, (MaxNumber.ToString().PadLeft(sign.Length, sign.Str)).ToInt32());
                    else
                        item.SetValue(entity, (MaxNumber).ToStr().PadLeft(sign.Length, sign.Str));
                }
            }
            return true;
        }






        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="error1">开发者自己设定的错误</param>
        /// <param name="error2">程序设定的错误</param>
        /// <param name="name">字段的中文名称</param>
        private bool SetErrorMessage(string error1, string error2, string name)
        {
            if (string.IsNullOrEmpty(error1))
                this.ErrorMessage = error2;
            else
            {
                if (error1.Contains("{name}"))
                    this.ErrorMessage = error1.Replace("{name}", name);
                else
                    this.ErrorMessage = error1;
            }
            return false;
        }


    }
}
