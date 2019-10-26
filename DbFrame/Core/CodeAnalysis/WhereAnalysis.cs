using System;
using System.Collections.Generic;
using System.Text;
namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;
    using System.Collections;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Where 解析
    /// </summary>
    public class WhereAnalysis : ExpressionVisitor
    {
        protected readonly SQL sql;

        public WhereAnalysis(SQL sql)
        {
            this.sql = sql;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            //检查括号
            this.CheckBrackets(node.ToString(), (_AddBrackets) =>
            {
                //左边
                this.CheckBrackets(node.Left.ToString(), (_AddBrackets_Left) =>
                {
                    this.Visit(node.Left);
                });

                sql.Code_Where.Append(this.GetOperatorStr(node.NodeType));

                //右边
                this.CheckBrackets(node.Right.ToString(), (_AddBrackets_Right) =>
                {
                    this.Visit(node.Right);
                });
            });

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression == null)
                this.EvalToSql(node);
            else
            {
                var _MemberStr = node.ToString();
                if (node.Expression is MemberExpression & _MemberStr.Count(w => w == '.') == 2)
                {
                    //取上一个member为参数名称 别名
                    var _pName = this.AddAlias((node.Expression as MemberExpression).Member.Name);
                    sql.Code_Where.Append(_pName);
                    //字段名
                    var _MemberName = DbSettings.KeywordHandle(node.Member.Name);
                    sql.Code_Where.Append(_MemberName);
                }
                else if (node.Expression.GetType().Name == "TypedParameterExpression")
                {
                    sql.Code_Where.Append(DbSettings.KeywordHandle(node.Member.Name));
                }
                else
                {
                    this.EvalToSql(node);
                }
            }

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            this.AddParameter(node.Value);
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            return base.Visit(node.Operand);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var _MethodName = node.Method.Name;
            var _MethodNames = Enum.GetNames(typeof(MethodName_Enum));

            if (_MethodNames.Contains(_MethodName))
            {
                if (node.Object != null & node.Arguments.Count == 1 & _MethodNames.Contains(_MethodName))
                {
                    var _Object = node.Object;
                    this.Visit(_Object);
                    var _Argument1 = node.Arguments[0];
                    sql.Code_Where.Append((_MethodName == MethodName_Enum.Equals.ToString()) ? " = " : " LIKE ");

                    if (_MethodName == MethodName_Enum.StartsWith.ToString())
                    {
                        this.Visit(_Argument1);
                        sql.Code_Where.Append(" + '%' ");
                    }
                    else if (_MethodName == MethodName_Enum.Contains.ToString())
                    {
                        sql.Code_Where.Append(" '%'+ ");
                        this.Visit(_Argument1);
                        sql.Code_Where.Append(" + '%' ");
                    }
                    else if (_MethodName == MethodName_Enum.EndsWith.ToString())
                    {
                        sql.Code_Where.Append(" '%'+ ");
                        this.Visit(_Argument1);
                    }
                    else if (_MethodName == MethodName_Enum.Equals.ToString())
                    {
                        this.Visit(_Argument1);
                    }
                }
                else if (node.Object == null & node.Arguments.Count == 2 & _MethodName == MethodName_Enum.SqlStr.ToString())
                {
                    var _Argument1 = node.Arguments[0];
                    var _Argument2 = node.Arguments[1];
                    sql.Code_Where.Append(this.Eval(_Argument2));
                }
                else if (node.Object == null && node.Arguments.Count == 3 & (_MethodName == MethodName_Enum.In.ToString() | _MethodName == MethodName_Enum.NotIn.ToString()))
                {
                    var _Argument1 = node.Arguments[0];
                    var _Argument2 = node.Arguments[1];
                    var _Argument3 = node.Arguments[2];

                    this.Visit(_Argument2);
                    sql.Code_Where.Append(_MethodName == "In" ? " IN " : " NOT IN ");
                    sql.Code_Where.Append(" ( ");
                    this.Visit(_Argument3);
                    sql.Code_Where.Append(" ) ");
                }
            }
            else
            {
                this.EvalToSql(node);
            }

            return node;
        }

        /// <summary>
        /// 运算符
        /// </summary>
        /// <param name="_ExpressionType"></param>
        /// <returns></returns>
        private string GetOperatorStr(ExpressionType _ExpressionType)
        {
            switch (_ExpressionType)
            {
                case ExpressionType.Or:
                case ExpressionType.OrElse: return " OR ";
                case ExpressionType.And:
                case ExpressionType.AndAlso: return " AND ";
                case ExpressionType.GreaterThan: return " > ";
                case ExpressionType.GreaterThanOrEqual: return " >= ";
                case ExpressionType.LessThan: return " < ";
                case ExpressionType.LessThanOrEqual: return " <= ";
                case ExpressionType.Equal: return " = ";
                case ExpressionType.NotEqual: return " <> ";
                case ExpressionType.Add: return " + ";
                case ExpressionType.Subtract: return " - ";
                case ExpressionType.Multiply: return " * ";
                case ExpressionType.Divide: return " / ";
                case ExpressionType.Modulo: return " % ";
                default: throw new DbFrameException("无法解析的表达式！");
            }
        }

        /// <summary>
        /// 检查是否有 括号
        /// </summary>
        /// <param name="_Expression"></param>
        /// <param name="_ParserArgs"></param>
        /// <param name="_Action"></param>
        private void CheckBrackets(string _Str, Action<bool> _Action)
        {
            //检查是否有括号
            var _AddBrackets = !string.IsNullOrEmpty(_Str) && _Str.Length > 5 && _Str.StartsWith("((") && _Str.EndsWith("))");

            if (_AddBrackets) sql.Code_Where.Append(" (");

            _Action(_AddBrackets);

            if (_AddBrackets) sql.Code_Where.Append(" )");
        }

        /// <summary> 
        /// 追加参数
        /// </summary>
        private void AddParameter(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                sql.Code_Where.Append("NULL");
                sql.Code_Where.Replace(" = NULL", " IS NULL ");
                sql.Code_Where.Replace(" <> NULL", " IS NOT NULL ");
            }
            else
            {
                string name = $"Param_{sql.Parameter.Count}";
                sql.Parameter.Add(new DbParam() { ParameterName = name, Value = obj });
                sql.Code_Where.Append('@');
                sql.Code_Where.Append(name);
            }
        }

        /// <summary>
        /// 追加别名
        /// </summary>
        private string AddAlias(string Alias)
        {
            if (sql.IsAlias)
                return $"{DbSettings.KeywordHandle(Alias)}.";
            return string.Empty;
        }

        private void EvalToSql(Expression _Expression)
        {
            UnaryExpression cast = Expression.Convert(_Expression, typeof(object));
            var obj = Expression.Lambda<Func<object>>(cast).Compile().Invoke();

            if (obj == null)
            {
                this.AddParameter(obj);
                return;
            }

            var type = obj.GetType();
            //list集合
            if (type.Name != "List`1")
            {
                this.AddParameter(obj);
                return;
            }

            var list = obj as IEnumerable;
            var index = 0;
            foreach (var item in list)
            {
                this.AddParameter(item);
                index = sql.Code_Where.Length;
                sql.Code_Where.Append(",");
            }
            sql.Code_Where.Remove(index, 1);
        }

        /// <summary>
        /// 计算值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public object Eval(Expression expression)
        {
            UnaryExpression cast = Expression.Convert(expression, typeof(object));
            var obj = Expression.Lambda<Func<object>>(cast).Compile().Invoke();
            return obj != null ? GetValueFormat(obj) : obj;
        }

        /// <summary>
        /// 对某些值 特殊处理
        /// </summary>
        /// <param name="obj"></param>
        private object GetValueFormat(object obj)
        {
            var type = obj.GetType();
            if (type.Name == "List`1") //list集合
            {
                var data = new List<string>();
                var list = obj as IEnumerable;
                string sql = string.Empty;
                foreach (var item in list)
                {
                    if (item == null) continue;
                    data.Add(item.ToString());
                }
                sql = string.Join(",", data);
                return sql;
            }
            return obj;
        }

        /// <summary>
        /// 函数集合
        /// </summary>
        public enum MethodName_Enum
        {
            StartsWith,
            Contains,
            EndsWith,
            Equals,
            SqlStr,
            In,
            NotIn
        }

    }
}