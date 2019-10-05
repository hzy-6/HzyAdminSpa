using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Abstract
{
    using DbFrame.BaseClass;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.Core.Interface;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public abstract class AbstractUpdate<T> : InsOrUpdOrDelBase<T>, IUpdate<T>
    {
        protected MemberInitExpression memberInitExpression { get; set; }
        public AbstractUpdate(MemberInitExpression _MemberInitExpression, AbstractAdo _Ado, Analysis _Analysis)
            : base(_Ado, _Analysis)
        {
            this.memberInitExpression = _MemberInitExpression;
        }

        public abstract IUpdate<T> Execute(List<SQL> SqlContainer);
        public abstract int Execute();
        public abstract Task<int> ExecuteAsync();
        public abstract IUpdate<T> IgnoreCols(Expression<Func<T, dynamic>> IgnoreColumns);
        public abstract IUpdate<T> IgnoreColsIF(bool IF, Expression<Func<T, dynamic>> IgnoreColumns);
        public abstract IUpdate<T> Where(Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract IUpdate<T> WhereIF(bool IF, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract SQL ToSql();
    }


}
