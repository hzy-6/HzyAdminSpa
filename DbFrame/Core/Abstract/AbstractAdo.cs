using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.Abstract
{
    using System.Data;
    using System.Data.Common;
    using DbFrame.BaseClass;
    using Interface;

    public abstract class AbstractAdo : IAdo
    {
        public AbstractAdo(string ConnectionString)
        {
            this.CommitState = false;
            this._ConnectionString = ConnectionString;
        }

        /// <summary>
        /// 记录是否开启提交事务
        /// </summary>
        public bool CommitState { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string _ConnectionString { get; set; }
        /// <summary>
        /// 连接对象
        /// </summary>
        public IDbConnection _DbConnection { get; set; }
        /// <summary>
        /// 事务对象
        /// </summary>
        public IDbTransaction _DbTransaction { get; set; }
        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <returns></returns>
        public abstract IDbConnection GetDbConnection();
        /// <summary>
        /// 异步锁 AsyncLock
        /// </summary>
        protected readonly AsyncLock _AsyncLock = new AsyncLock();

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

        #region Async
        
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
