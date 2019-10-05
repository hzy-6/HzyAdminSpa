using System.Collections.Generic;
namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// groupby 解析
    /// </summary>
    public class GroupByAnalysis : ExpressionVisitor
    {
        protected readonly SQL _Sql;

        public GroupByAnalysis(SQL sql)
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
                    var _TabName = this.AddAlias(_Tab.Member.Name);
                    this.AddCode($"{_TabName}{_MemberName}");
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
            this.AddCode(Parser.Eval(node));
            return node;
        }

        private void AddCode(object Codes)
        {
            if (Codes == null)
                throw new DbFrameException(" GROUP BY 参数不能为空字符串或者Null ");
            //记录 Order By
            if (string.IsNullOrEmpty(_Sql.Code_GroupBy.ToString()))
            {
                _Sql.Code_GroupBy.Append(Codes);
            }
            else
            {
                _Sql.Code_GroupBy.Append($",{Codes}");
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
