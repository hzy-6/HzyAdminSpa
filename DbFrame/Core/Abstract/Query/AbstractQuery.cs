using System;
namespace DbFrame.Core.Abstract.Query
{
    using DbFrame.BaseClass;
    using DbFrame.Core.Interface.Query;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public abstract class AbstractQuery<T> : AbstractMappingData<T>, IQuery<T>
    {

        public abstract IJoin<T, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Select);
        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IQuery<T> Where(Expression<Func<HzyTuple<T>, bool>> Where);

        public abstract IQuery<T> WhereIF(bool IsWhere, Expression<Func<HzyTuple<T>, bool>> Where);

        public abstract IQuery<T> OrderBy<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> OrderBy);

        public abstract IQuery<T> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T>, TReturn>> OrderBy);

        public abstract IQuery<T> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> OrderBy);

        public abstract IQuery<T> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T>, TReturn>> OrderBy);

        public abstract IQuery<T> GroupBy<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> GroupBy);

        public abstract IQuery<T> Having(Expression<Func<HzyTuple<T>, bool>> Where);

        public abstract IQuery<T> SqlString(Action<SQL> _Action);
        //
        IQuery<T> IQuery<T>.Top(int Top)
        {
            this.Top(Top);
            return this;
        }

        IQuery<T> IQuery<T>.Distinct()
        {
            this.Distinct();
            return this;
        }

        IQuery<T> IQuery<T>.TakePage(int PageNumber, int PageSize)
        {
            this.TakePage(PageNumber, PageSize);
            return this;
        }

        IQuery<T> IQuery<T>.TakePage(int PageNumber, int PageSize, out int TotalCount)
        {
            this.TakePage(PageNumber, PageSize, out TotalCount);
            return this;
        }
        //
        public abstract TReturn Max<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Max);
        public abstract TReturn Min<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Min);
        public abstract TReturn Sum<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Sum);

        #region Async
        public abstract Task<TReturn> MaxAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Max);
        public abstract Task<TReturn> MinAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Min);
        public abstract Task<TReturn> SumAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Sum);
        #endregion

    }
}
