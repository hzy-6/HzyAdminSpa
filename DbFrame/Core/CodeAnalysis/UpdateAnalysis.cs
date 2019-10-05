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

    public class UpdateAnalysis : ExpressionVisitor
    {
        protected readonly SQL sql;
        public StringBuilder _StringBuilder { get; set; }
        public UpdateAnalysis(SQL sql)
        {
            this.sql = sql;
            _StringBuilder = new StringBuilder();
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            this.Visit(node.Left);
            this._StringBuilder.Append(this.GetOperatorStr(node.NodeType));
            this.Visit(node.Right);
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            this._StringBuilder.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            this._StringBuilder.Append(node.Value);
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            return base.Visit(node.Operand);
        }

        private string GetOperatorStr(ExpressionType _ExpressionType)
        {
            switch (_ExpressionType)
            {
                case ExpressionType.Equal: return " = ";
                case ExpressionType.Add: return " + ";
                case ExpressionType.Subtract: return " - ";
                case ExpressionType.Multiply: return " * ";
                case ExpressionType.Divide: return " / ";
                case ExpressionType.Modulo: return " % ";
                default: throw new DbFrameException("无法解析的表达式！");
            }
        }

    }
}
