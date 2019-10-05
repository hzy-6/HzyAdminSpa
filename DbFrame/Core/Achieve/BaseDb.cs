/*
 * *******************************************************
 * 
 * 作者：hzy
 * 
 * 开源地址：https://gitee.com/hao-zhi-ying/DbFrame
 * 
 * *******************************************************
 */
using System;
using System.Collections.Generic;
namespace DbFrame.Core.Achieve
{
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.Core.Interface;
    using DbFrame.Core.Interface.Query;
    using DbFrame.Core.Achieve.Query;
    using System.Data;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseDb : AbstractDb
    {
        protected Analysis analysis { get; set; }

        /// <summary>
        /// 最后一次 插入 ID 这里一般设置 字符串即可
        /// </summary>
        protected string LastInsertId { get; set; }

        protected AbstractAdo Ado { get; set; }

        public BaseDb() { }

        public BaseDb(string _ConnectionString) : base(_ConnectionString) { }

        #region Insert

        /// <summary>
        /// Insert 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitys"></param>
        /// <returns></returns>
        public override IEnumerable<object> InsertBatch<T>(IEnumerable<T> Entitys)
        {
            var Keys = new List<object>();
            foreach (var item in Entitys) Keys.Add(this.Insert(item));
            return Keys;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override object Insert<T>(T Entity)
        {
            var _Insert = this.InsertObject(Entity);
            return _Insert.Execute();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override object Insert<T>(Expression<Func<T>> Entity)
        {
            var _Insert = this.InsertObject(Entity);
            return _Insert.Execute();
        }

        /// <summary>
        /// Insert 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitys"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<object>> InsertBatchAsync<T>(IEnumerable<T> Entitys)
        {
            var Keys = new List<object>();
            foreach (var item in Entitys) Keys.Add(await this.InsertAsync(item));
            return Keys;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override async Task<object> InsertAsync<T>(T Entity)
        {
            var _Insert = this.InsertObject(Entity);
            return await _Insert.ExecuteAsync();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override async Task<object> InsertAsync<T>(Expression<Func<T>> Entity)
        {
            var _Insert = this.InsertObject(Entity);
            return await _Insert.ExecuteAsync();
        }

        /// <summary>
        /// Insert 对象 可设置忽略 字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override IInsert<T> InsertObject<T>(T Entity)
        {
            var _Insert = new InsertAchieve<T>(Parser.ModelToMemberInitExpression(Entity), this.Ado, this.analysis, this.LastInsertId);
            return _Insert;
        }

        /// <summary>
        /// Insert 对象 可设置忽略 字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override IInsert<T> InsertObject<T>(Expression<Func<T>> Entity)
        {
            var _Insert = new InsertAchieve<T>((Entity.Body as MemberInitExpression), this.Ado, this.analysis, this.LastInsertId);
            return _Insert;
        }

        #endregion

        #region Update

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override int Update<T>(T Entity, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _IUpdate = this.UpdateObject(Entity).Where(Where);
            return _IUpdate.Execute();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override int Update<T>(Expression<Func<T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _IUpdate = this.UpdateObject(Entity).Where(Where);
            return _IUpdate.Execute();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override int Update<T>(Expression<Func<T, T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _IUpdate = this.UpdateObject(Entity).Where(Where);
            return _IUpdate.Execute();
        }

        /// <summary>
        /// UpdateById
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override int UpdateById<T>(T Entity)
        {
            var _IUpdate = this.UpdateObjectById(Entity);
            return _IUpdate.Execute();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override async Task<int> UpdateAsync<T>(T Entity, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _IUpdate = this.UpdateObject(Entity).Where(Where);
            return (await _IUpdate.ExecuteAsync());
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override async Task<int> UpdateAsync<T>(Expression<Func<T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _IUpdate = this.UpdateObject(Entity).Where(Where);
            return (await _IUpdate.ExecuteAsync());
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override async Task<int> UpdateAsync<T>(Expression<Func<T, T>> Entity, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _IUpdate = this.UpdateObject(Entity).Where(Where);
            return (await _IUpdate.ExecuteAsync());
        }

        /// <summary>
        /// UpdateById
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override async Task<int> UpdateByIdAsync<T>(T Entity)
        {
            var _IUpdate = this.UpdateObjectById(Entity);
            return (await _IUpdate.ExecuteAsync());
        }

        /// <summary>
        /// Update 对象 可设置忽略 字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override IUpdate<T> UpdateObject<T>(T Entity)
        {
            var _IUpdate = new UpdateAchieve<T>(Parser.ModelToMemberInitExpression(Entity), this.Ado, this.analysis);
            return _IUpdate;
        }

        /// <summary>
        /// Update 对象 可设置忽略 字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override IUpdate<T> UpdateObject<T>(Expression<Func<T>> Entity)
        {
            var _IUpdate = new UpdateAchieve<T>((Entity.Body as MemberInitExpression), this.Ado, this.analysis);
            return _IUpdate;
        }

        /// <summary>
        /// Update 对象 可设置忽略 字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override IUpdate<T> UpdateObject<T>(Expression<Func<T, T>> Entity)
        {
            var _IUpdate = new UpdateAchieve<T>((Entity.Body as MemberInitExpression), this.Ado, this.analysis);
            return _IUpdate;
        }

        /// <summary>
        /// Update 对象 可设置忽略 字段 根据 实体ID 做为条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public override IUpdate<T> UpdateObjectById<T>(T Entity)
        {
            var _TableInfo = DbTable.GetTable<T>(Entity);
            var _Table = _TableInfo.Item2;
            var _TableName = _TableInfo.Item1;
            var _KeyInfo = _Table.Find(w => w.IsKey);
            if (_KeyInfo == null) throw new DbFrameException("检测到该模型没有主键!");
            var Where = Parser.WhereById<T>(_KeyInfo.Name, _KeyInfo.Value, _TableName);

            var _IUpdate = new UpdateAchieve<T>(Parser.ModelToMemberInitExpression(Entity), this.Ado, this.analysis)
                .Where(Where);

            return _IUpdate;
        }


        #endregion

        #region Delete

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override int Delete<T>(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _Delete = this.DeleteObject<T>().Where(Where);
            return _Delete.Execute();
        }

        /// <summary>
        /// DeleteById
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override int DeleteById<T>(object Id)
        {
            var _Delete = this.DeleteByIdObject<T>(Id);
            return _Delete.Execute();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Where"></param>
        /// <returns></returns>
        public override async Task<int> DeleteAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            var _Delete = this.DeleteObject<T>().Where(Where);
            return (await _Delete.ExecuteAsync());
        }

        /// <summary>
        /// DeleteById
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override async Task<int> DeleteByIdAsync<T>(object Id)
        {
            var _Delete = this.DeleteByIdObject<T>(Id);
            return (await _Delete.ExecuteAsync());
        }

        /// <summary>
        /// Delete 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IDelete<T> DeleteObject<T>()
        {
            return new DeleteAchieve<T>(this.Ado, this.analysis);
        }

        /// <summary>
        /// Delete 对象 根据 实体ID 做为条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IDelete<T> DeleteByIdObject<T>(object Id)
        {
            var _TableInfo = DbTable.GetTable(typeof(T));
            var _Table = _TableInfo.Item2;
            var _TableName = _TableInfo.Item1;
            var _KeyInfo = _Table.Find(w => w.IsKey);
            if (_KeyInfo == null) throw new DbFrameException("检测到该模型没有主键!");
            var Where = Parser.WhereById<T>(_KeyInfo.Name, Id, _TableName);

            var _Delete = new DeleteAchieve<T>(this.Ado, this.analysis)
                .Where(Where);

            return _Delete;
        }

        #endregion

        #region Find Or Query Or Async

        public override IQuery<T> Query<T>()
        {
            var _Sql = new SQL();
            return new QueryAchieve<T>(_Sql, this.Ado, this.analysis);
        }
        public override IQuery<T> Query<T>(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            return this.Query<T>().Where(Where);
        }

        public override T Find<T>(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            return this.Query<T>(Where).First<T>();
        }

        public override T FindById<T>(object Id)
        {
            var _TableInfo = DbTable.GetTable(typeof(T));
            var _Table = _TableInfo.Item2;
            var _TableName = _TableInfo.Item1;
            var _KeyInfo = _Table.Find(w => w.IsKey);
            if (_KeyInfo == null) throw new DbFrameException("检测到该模型没有主键!");
            var _ParName = typeof(T).Name.ToLower();
            var _KeyName = _KeyInfo.Name;

            return this.Query<T>(Parser.WhereById<T>(_KeyName, Id, _ParName)).First<T>();
        }

        public override List<T> FindList<T>(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            return this.Query<T>(Where).ToList<T>();
        }

        #endregion

        #region FindAsync

        public override async Task<T> FindAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            return await this.Query<T>(Where).FirstAsync<T>();
        }

        public override async Task<T> FindByIdAsync<T>(object Id)
        {
            var _TableInfo = DbTable.GetTable(typeof(T));
            var _Table = _TableInfo.Item2;
            var _TableName = _TableInfo.Item1;
            var _KeyInfo = _Table.Find(w => w.IsKey);
            if (_KeyInfo == null) throw new DbFrameException("检测到该模型没有主键!");
            var _ParName = typeof(T).Name.ToLower();
            var _KeyName = _KeyInfo.Name;

            return await this.Query<T>(Parser.WhereById<T>(_KeyName, Id, _ParName)).FirstAsync<T>();
        }

        public override async Task<List<T>> FindListAsync<T>(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            return await this.Query<T>(Where).ToListAsync<T>();
        }

        #endregion

        #region Ado

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="_Action"></param>
        /// <returns></returns>
        public override bool Commit(Action _Action)
        {
            return this.Ado.Commit(_Action);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="_Action"></param>
        /// <returns></returns>
        public override bool Commit(Action<List<SQL>> _Action)
        {
            return this.Ado.Commit(_Action);
        }
        public override int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Ado.Execute(sql, param, transaction, commandTimeout, commandType);
        }
        public override object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Ado.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
        }
        public override T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Ado.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
        }
        public override IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Ado.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
        public override IDataReader ExecuteReader(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, Action<IDataReader> Success = null)
        {
            return this.Ado.ExecuteReader(sql, param, transaction, commandTimeout, commandType, Success);
        }
        public override DataTable QueryDataTable(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Ado.QueryDataTable(sql, param, transaction, commandTimeout, commandType);
        }
        public override T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Ado.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }
        public override T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Ado.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }

        #endregion

        #region Ado Async

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="_Action"></param>
        /// <returns></returns>
        public override async Task<bool> CommitAsync(Action _Action)
        {
            return await this.Ado.CommitAsync(_Action);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="_Action"></param>
        /// <returns></returns>
        public override async Task<bool> CommitAsync(Action<List<SQL>> _Action)
        {
            return await this.Ado.CommitAsync(_Action);
        }
        public override async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await this.Ado.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }
        public override async Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await this.Ado.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
        }
        public override async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await this.Ado.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
        public override async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await this.Ado.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
        public override async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, Action<IDataReader> Success = null)
        {
            return await this.Ado.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType, Success);
        }
        public override async Task<DataTable> QueryDataTableAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await this.Ado.QueryDataTableAsync(sql, param, transaction, commandTimeout, commandType);
        }
        public override async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await this.Ado.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
        public override async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await this.Ado.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        #endregion



    }
}
