using System;
namespace DbFrame.Core.Interface.Query
{
    //
    using DbFrame.BaseClass;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    //
    public interface IQuery<T> : IBase<T>, IMappingData<T>
    {
        IJoin<T, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
        //
        new IQuery<T> Top(int Top);
        new IQuery<T> Distinct();
        new IQuery<T> TakePage(int PageNumber, int PageSize);
        new IQuery<T> TakePage(int PageNumber, int PageSize, out int TotalCount);
        //
        TReturn Max<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Max);
        TReturn Min<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Min);
        TReturn Sum<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Sum);

        #region Async
        Task<TReturn> MaxAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Max);
        Task<TReturn> MinAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Min);
        Task<TReturn> SumAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Sum);
        #endregion


    }
}
