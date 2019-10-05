using System;
using System.Collections.Generic;

namespace DbFrame.Core.Interface
{
    //
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DbFrame.BaseClass;
    using DbFrame.Core.Interface.Query;

    public interface IDb : IAdo
    {
        /*Insert*/
        #region Insert

        IEnumerable<object> InsertBatch<T>(IEnumerable<T> Entitys);
        object Insert<T>(T Entity);
        object Insert<T>(Expression<Func<T>> Entity);
        Task<IEnumerable<object>> InsertBatchAsync<T>(IEnumerable<T> Entitys);
        Task<object> InsertAsync<T>(T Entity);
        Task<object> InsertAsync<T>(Expression<Func<T>> Entity);
        IInsert<T> InsertObject<T>(T Entity);
        IInsert<T> InsertObject<T>(Expression<Func<T>> Entity);

        #endregion

        /*Update*/
        #region Update

        int Update<T>(T Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        int Update<T>(Expression<Func<T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        int Update<T>(Expression<Func<T, T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        int UpdateById<T>(T Entity);
        Task<int> UpdateAsync<T>(T Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        Task<int> UpdateAsync<T>(Expression<Func<T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        Task<int> UpdateAsync<T>(Expression<Func<T, T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        Task<int> UpdateByIdAsync<T>(T Entity);
        IUpdate<T> UpdateObject<T>(T Entity);
        IUpdate<T> UpdateObject<T>(Expression<Func<T>> Entity);
        IUpdate<T> UpdateObject<T>(Expression<Func<T, T>> Entity);
        IUpdate<T> UpdateObjectById<T>(T Entity);

        #endregion

        /*Delete*/
        #region Delete

        int Delete<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        int DeleteById<T>(object Id);
        Task<int> DeleteAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        Task<int> DeleteByIdAsync<T>(object Id);
        IDelete<T> DeleteObject<T>();
        IDelete<T> DeleteByIdObject<T>(object Id);

        #endregion

        /*Select*/
        #region Query Or Find

        IQuery<T> Query<T>();
        IQuery<T> Query<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        T Find<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        T FindById<T>(object Id);
        List<T> FindList<T>(Expression<Func<HzyTuple<T>, bool>> Where);

        #endregion

        #region Async

        Task<T> FindAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        Task<T> FindByIdAsync<T>(object Id);
        Task<List<T>> FindListAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where);

        #endregion

    }
}
