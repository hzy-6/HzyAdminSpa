using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Abstract
{
    using DbFrame.BaseClass;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.Core.Interface;
    using System.Data;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public abstract class AbstractDelete<T> : InsOrUpdOrDelBase<T>, IDelete<T>
    {
        public AbstractDelete(AbstractAdo _Ado, Analysis _Analysis)
            : base(_Ado, _Analysis)
        {

        }

        public abstract IDelete<T> Execute(List<SQL> SqlContainer);
        public abstract int Execute();
        public abstract Task<int> ExecuteAsync();
        public abstract IDelete<T> Where(Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract IDelete<T> WhereIF(bool IF, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract SQL ToSql();
    }
}
