using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.CodeAnalysis
{
    using DbFrame.BaseClass;
    using System.Linq.Expressions;

    public class Max_Min_Sum_Analysis : ExpressionVisitor
    {
        protected readonly SQL _Sql;
        protected string _FunctionName { get; set; }

        public Max_Min_Sum_Analysis(SQL sql, string functionName)
        {
            this._Sql = sql;
            this._FunctionName = functionName;
        }

        public override Expression Visit(Expression node)
        {
            if (node == null) throw new DbFrameException($"函数[{_FunctionName}]该语法无法解析!");
            return base.Visit(node);
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

                this.AddCode($" {_FunctionName}({_TabName + _MemberName}) ");
            }
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var _MethodName = node.Method.Name;

            if (_MethodName == nameof(DbMappingExtension.SqlStr))
            {
                var _Arguments1 = node.Arguments[0];
                var _Arguments2 = node.Arguments[1];

                this.AddCode($" {_FunctionName}({Parser.Eval(_Arguments2)}) ");
            }
            return node;
        }

        private void AddCode(string Codes)
        {
            this._Sql.Code_Column.Clear().Append(Codes);
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
