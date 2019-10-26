using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Achieve
{
    using Dapper;
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using System.Data;
    using System.Threading.Tasks;

    public class AdoAchieve : AbstractAdo
    {

        public AdoAchieve(string ConnectionString)
            : base(ConnectionString)
        {

        }

        /// <summary>
        /// 数据库 连接对象
        /// </summary>
        /// <returns></returns>
        public override IDbConnection GetDbConnection()
        {
            throw new DbFrameException(" public override IDbConnection GetDbConnection() 数据库 连接对象 NULL ！");
        }

        #region Ado

        public override bool Commit(Action _Action) => this.CommitTransaction(_IDbTransaction => { _Action?.Invoke(); });

        public override bool CommitTransaction(Action<IDbTransaction> _Action)
        {
            using (this._DbConnection = this.GetDbConnection())
            {
                if (this._DbConnection.State == ConnectionState.Closed) this._DbConnection.Open();
                using (this._DbTransaction = this._DbConnection.BeginTransaction())
                {
                    try
                    {
                        //事务 状态设置 开
                        this.CommitState = true;
                        _Action?.Invoke(this._DbTransaction);
                        if (this._DbTransaction != null) this._DbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        if (this._DbTransaction != null) this._DbTransaction.Rollback();
                        this._DbConnection.Close();
                        //事务 状态设置 关
                        this.CommitState = false;
                        throw;
                    }
                    finally
                    {
                        this._DbConnection.Close();
                        //事务 状态设置 关
                        this.CommitState = false;
                    }
                }
            }
        }

        public override bool Commit(Action<List<SQL>> _Action)
        {
            using (var dbConnection = this.GetDbConnection())
            {
                if (dbConnection.State == ConnectionState.Closed) dbConnection.Open();
                using (var _dbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var _SqlList = new List<SQL>();
                        _Action?.Invoke(_SqlList);

                        foreach (var item in _SqlList) dbConnection.Execute(item.Code.ToString(), item.GetDynamicParameters(), _dbTransaction);

                        _dbTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        _dbTransaction.Rollback();
                        dbConnection.Close();
                        throw;
                    }
                    finally
                    {
                        dbConnection.Close();
                    }
                }
            }
        }

        public override int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        public override object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
        }

        public override T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public override IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (typeof(T) == typeof(Dictionary<string, object>) | typeof(T) == typeof(IDictionary<string, object>))
            {
                var res = new List<Dictionary<string, object>>();
                this.ExecuteReader(sql, param, transaction, commandTimeout, commandType, (_IDataReader) =>
                {
                    res = _IDataReader.ToList();
                });

                return (IEnumerable<T>)res;
            }

            using (var conn = this.GetDbConnection()) return conn.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        public override IDataReader ExecuteReader(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, Action<IDataReader> Success = null)
        {
            using (var conn = this.GetDbConnection())
            {
                var _IDataReader = conn.ExecuteReader(sql, param, transaction, commandTimeout, commandType);
                Success?.Invoke(_IDataReader);
                return _IDataReader;
            }
        }

        public override DataTable QueryDataTable(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.ExecuteReader(sql, param, transaction, commandTimeout, commandType).ToDataTable();
        }

        public override T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public override T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }

        #endregion


        #region Async

        public override Task<bool> CommitAsync(Action _Action) => Task.FromResult(this.Commit(_Action));

        public override Task<bool> CommitTransactionAsync(Action<IDbTransaction> _Action) => Task.FromResult(this.CommitTransaction(_Action));

        public override Task<bool> CommitAsync(Action<List<SQL>> _Action) => Task.FromResult(this.Commit(_Action));

        public override Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }

        public override Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
        }

        public override Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return conn.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public override async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (typeof(T) == typeof(Dictionary<string, object>) | typeof(T) == typeof(IDictionary<string, object>))
            {
                var res = new List<Dictionary<string, object>>();
                await this.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType, (_IDataReader) =>
                {
                    res = _IDataReader.ToList();
                });

                return (IEnumerable<T>)res;
            }
            using (var conn = this.GetDbConnection()) return await conn.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public override async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, Action<IDataReader> Success = null)
        {
            using (var conn = this.GetDbConnection())
            {
                var _IDataReader = await conn.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType);
                Success?.Invoke(_IDataReader);
                return _IDataReader;
            }
        }

        public override async Task<DataTable> QueryDataTableAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return (await conn.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType)).ToDataTable();
        }

        public override async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return await conn.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public override async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var conn = this.GetDbConnection()) return await conn.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        #endregion


    }
}
