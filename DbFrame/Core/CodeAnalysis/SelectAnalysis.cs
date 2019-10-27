using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// select解析
    /// </summary>
    public class SelectAnalysis : ExpressionVisitor
    {
        protected readonly SQL _Sql;

        public SelectAnalysis(SQL sql)
        {
            this._Sql = sql;
        }

        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            var _Arguments = node.Arguments;
            var _Members = node.Members;

            foreach (var item in _Arguments)
            {
                var _CharCount = item.ToString().Count(w => w == '.');
                //别名
                var _Name = DbSettings.KeywordHandle(_Members[_Arguments.IndexOf(item)].Name);

                if (item is MemberExpression & _CharCount == 2)
                {
                    var _MemberExpression = (MemberExpression)item;
                    var _Expression = _MemberExpression.Expression;
                    var _Tab = (MemberExpression)_Expression;
                    var _MemberName = DbSettings.KeywordHandle(_MemberExpression.Member.Name);
                    var _TabName = this.AddAlias(_Tab.Member.Name);
                    var _AS = (_Name == _MemberName) ? string.Empty : $" AS {_Name}";
                    this.AddCode($"{_TabName}{_MemberName}{_AS}");
                }
                else if (item is ConstantExpression & !_Name.ToLower().Contains(nameof(DbMappingExtension.SqlStr).ToLower()))
                {
                    var _ConstantExpression = (ConstantExpression)item;
                    var _Value = _ConstantExpression.Value;
                    this.AddCode($"{(string.IsNullOrWhiteSpace(_Value.ToString()) ? "NULL" : _Value)} {_Name}");
                }
                else if (item is MethodCallExpression & !_Name.ToLower().Contains(nameof(DbMappingExtension.SqlStr).ToLower()))
                {
                    var _node = item as MethodCallExpression;
                    var _Value = Parser.Eval(_node);
                    this.AddCode(_Value + $" AS {((_Value.ToString() != _Name) ? _Name : "")}");
                }
                else
                {
                    this.Visit(item);
                }
            }

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            var _CharCount = node.ToString().Count(w => w == '.');
            if (node is MemberExpression & _CharCount == 1)
            {
                var _Column = new List<string>();
                var _Member = node.Member as PropertyInfo;
                this.AnalysisParameterExpression(_Member.PropertyType, _Column);
                this.AddCode(string.Join(",", _Column));
            }
            else if (node.Expression is MemberExpression & _CharCount == 2)
            {
                var _Expression = node.Expression;
                var _Tab = (MemberExpression)_Expression;
                var _MemberName = DbSettings.KeywordHandle(node.Member.Name);
                var _TabName = this.AddAlias(_Tab.Member.Name);
                this.AddCode($"{_TabName}{_MemberName}");
            }
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            this.AddCode(node.Value);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var _MethodName = node.Method.Name;

            if (_MethodName == nameof(DbMappingExtension.SqlStr))
            {
                var _Arguments1 = node.Arguments[0];
                var _Arguments2 = node.Arguments[1];

                this.AddCode(Parser.Eval(_Arguments2));
            }
            else
            {
                this.AddCode(Parser.Eval(node));
            }
            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            this.AddCode(Parser.Eval(node));
            return node;
        }



        /// <summary>
        /// 替换 列
        /// </summary>
        /// <param name="_Sql"></param>
        /// <param name="Codes"></param>
        private void AddCode(object Codes)
        {
            if (Codes == null) return;

            if (string.IsNullOrEmpty(Codes.ToString()) || Codes.ToString() == ("*")) return;
            var _Code_Column = _Sql.Code_Column.ToString().Trim();
            if (string.IsNullOrEmpty(_Code_Column))
            {
                _Sql.Code_Column.Append(Codes);
            }
            else if (_Code_Column == "*")
            {
                _Sql.Code_Column.Clear().Append(Codes);
            }
            else
            {
                _Sql.Code_Column.Append($",{Codes}");
            }
            //_Sql.Code_Column.Clear().Append(Codes);//记录列
        }

        /// <summary>
        /// 追加别名
        /// </summary>
        private string AddAlias(string Alias)
        {
            if (_Sql.IsAlias)
                return $"{DbSettings.KeywordHandle(Alias)}.";
            return string.Empty;
        }

        private void AnalysisParameterExpression(Type _Type, List<string> _Column)
        {
            var _TableInfo = DbTable.GetTable(_Type);
            var _Table = _TableInfo.Item2;

            var _TabName = _Sql.Alias.FirstOrDefault(w => w.Value.ToString() == DbSettings.KeywordHandle(_TableInfo.Item1));

            foreach (var item in _Table)
            {
                //检测有无忽略字段
                if (_Table.FirstOrDefault(w => !w.IsColumn && w.Name == item.Name) != null)
                    continue;

                if (_Sql.IsAlias)
                    _Column.Add(_TabName.Key + "." + DbSettings.KeywordHandle(item.TableFieldName));
                else
                    _Column.Add(DbSettings.KeywordHandle(item.TableFieldName));
            }

        }



    }
}