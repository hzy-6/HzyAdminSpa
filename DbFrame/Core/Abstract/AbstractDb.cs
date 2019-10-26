using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.Abstract
{
    using System.Data;
    using DbFrame.BaseClass;
    using DbFrame.Core.Interface;
    using DbFrame.Core.Interface.Query;

    public abstract class AbstractDb : IDb//, IDisposable
    {
        protected string ConnectionString { get; set; }

        public AbstractDb()
        {
            if (string.IsNullOrEmpty(DbSettings.DefaultConnectionString))
                throw new DbFrameException("请在您的程序启动时 调用 SetDefaultConnectionString(string _ConnectionString) 函数 设置默认连接字符串！");

            this.ConnectionString = DbSettings.DefaultConnectionString;
        }
        public AbstractDb(string _ConnectionString)
        {
            if (string.IsNullOrEmpty(_ConnectionString))
                throw new DbFrameException("传入参数 _ConnectionString 不能为空！");

            this.ConnectionString = _ConnectionString;
        }

        #region Insert

        public abstract IEnumerable<object> InsertBatch<T>(IEnumerable<T> Entitys);
        public abstract object Insert<T>(T Entity);
        public abstract object Insert<T>(Expression<Func<T>> Entity);
        public abstract Task<IEnumerable<object>> InsertBatchAsync<T>(IEnumerable<T> Entitys);
        public abstract Task<object> InsertAsync<T>(T Entity);
        public abstract Task<object> InsertAsync<T>(Expression<Func<T>> Entity);
        public abstract IInsert<T> InsertObject<T>(T Entity);
        public abstract IInsert<T> InsertObject<T>(Expression<Func<T>> Entity);
        #endregion

        #region Update
        public abstract int Update<T>(T Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract int Update<T>(Expression<Func<T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract int Update<T>(Expression<Func<T, T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract int UpdateById<T>(T Entity);
        public abstract Task<int> UpdateAsync<T>(T Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract Task<int> UpdateAsync<T>(Expression<Func<T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract Task<int> UpdateAsync<T>(Expression<Func<T, T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract Task<int> UpdateByIdAsync<T>(T Entity);
        public abstract IUpdate<T> UpdateObject<T>(T Entity);
        public abstract IUpdate<T> UpdateObject<T>(Expression<Func<T>> Entity);
        public abstract IUpdate<T> UpdateObject<T>(Expression<Func<T, T>> Entity);
        public abstract IUpdate<T> UpdateObjectById<T>(T Entity);
        #endregion

        #region Delete
        public abstract int Delete<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract int DeleteById<T>(object Id);
        public abstract Task<int> DeleteAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract Task<int> DeleteByIdAsync<T>(object Id);
        public abstract IDelete<T> DeleteObject<T>();
        public abstract IDelete<T> DeleteByIdObject<T>(object Id);
        #endregion 

        #region Find Or Query Or Async

        public abstract IQuery<T> Query<T>();
        public abstract IQuery<T> Query<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract T Find<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract T FindById<T>(object Id);
        public abstract List<T> FindList<T>(Expression<Func<HzyTuple<T>, bool>> Where);

        #endregion

        #region FindAsync

        public abstract Task<T> FindAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where);
        public abstract Task<T> FindByIdAsync<T>(object Id);
        public abstract Task<List<T>> FindListAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where);

        #endregion

        #region Ado

        public abstract bool Commit(Action _Action);
        public abstract bool CommitTransaction(Action<IDbTransaction> _Action);
        public abstract bool Commit(Action<List<SQL>> _Action);
        public abstract int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        public abstract IDataReader ExecuteReader(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, Action<IDataReader> Success = null);
        public abstract DataTable QueryDataTable(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        #endregion

        #region Ado Async

        public abstract Task<bool> CommitAsync(Action _Action);
        public abstract Task<bool> CommitTransactionAsync(Action<IDbTransaction> _Action);
        public abstract Task<bool> CommitAsync(Action<List<SQL>> _Action);
        public abstract Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, Action<IDataReader> Success = null);
        public abstract Task<DataTable> QueryDataTableAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public abstract Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        #endregion

    }

}
