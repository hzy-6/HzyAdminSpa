using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Interface
{
    using System.Data;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DbFrame.BaseClass;

    public interface IUpdate<T>
    {
        IUpdate<T> Execute(List<SQL> SqlContainer);
        int Execute();
        Task<int> ExecuteAsync();
        IUpdate<T> IgnoreCols(Expression<Func<T, dynamic>> IgnoreColumns);
        IUpdate<T> IgnoreColsIF(bool IF, Expression<Func<T, dynamic>> IgnoreColumns);
        IUpdate<T> Where(Expression<Func<HzyTuple<T>, bool>> Where);
        IUpdate<T> WhereIF(bool IF, Expression<Func<HzyTuple<T>, bool>> Where);
        SQL ToSql();

    }



}
