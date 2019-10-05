using System.Collections.Generic;
using System.Linq;

namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;
    using System.Linq.Expressions;

    /// <summary>
    /// Orderby 语法解析
    /// </summary>
    public class OrderByAnalysis : ExpressionVisitor
    {
        protected readonly SQL _Sql;

        public OrderByAnalysis(SQL sql)
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
                if (item is MemberExpression & _CharCount == 2)
                {
                    var _MemberExpression = (MemberExpression)item;
                    var _Expression = _MemberExpression.Expression;
                    var _Tab = (MemberExpression)_Expression;
                    var _MemberName = DbSettings.KeywordHandle(_MemberExpression.Member.Name);
                    //别名
                    var _Name = DbSettings.KeywordHandle(_Members[_Arguments.IndexOf(item)].Name);
                    var _TabName = this.AddAlias(_Tab.Member.Name);
                    var _SortStr = string.Empty;
                    if (_Name.ToLower().Contains("asc"))
                        _SortStr = " ASC";
                    else if (_Name.ToLower().Contains("desc"))
                        _SortStr = " DESC";
                    this.AddCode($"{_TabName}{_MemberName}{_SortStr}");
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
            if (node.Expression is MemberExpression & _CharCount == 2)
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
            this.AddCode(Parser.Eval(node).ToString());
            return node;
        }

        public void CreateDESC(LambdaExpression _LambdaExpression)
        {
            var _Body = _LambdaExpression.Body;
            if (_Body is MemberExpression)
            {
                var node = _Body as MemberExpression;

                var _CharCount = node.ToString().Count(w => w == '.');
                if (_CharCount == 2)
                {
                    var _Expression = node.Expression;
                    var _Tab = (MemberExpression)_Expression;
                    var _MemberName = DbSettings.KeywordHandle(node.Member.Name);
                    var _TabName = this.AddAlias(_Tab.Member.Name);
                    this.AddCode($"{_TabName}{_MemberName} DESC");
                }
            }
            else
            {
                throw new DbFrameException(" ORDER BY DESC 无法解析的表达式，更多语法请使用 ORDER BY。");
            }
        }

        private void AddCode(object Codes)
        {
            if (Codes == null) throw new DbFrameException(" ORDER BY 参数不能为空字符串或者Null ");
            //记录 Order By
            if (string.IsNullOrEmpty(_Sql.Code_OrderBy.ToString()))
            {
                _Sql.Code_OrderBy.Append(Codes);
            }
            else
            {
                _Sql.Code_OrderBy.Append($",{Codes}");
            }
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


    }
}
