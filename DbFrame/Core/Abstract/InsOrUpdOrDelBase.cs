using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Abstract
{
    using Dapper;
    using DbFrame.BaseClass;
    using DbFrame.Core.CodeAnalysis;
    using System.Data;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class InsOrUpdOrDelBase<T>
    {
        protected SQL Sql { get; set; }
        protected List<string> IgnoreColumns { get; set; }
        protected AbstractAdo Ado { get; set; }
        protected Analysis _Analysis { get; set; }
        protected Tuple<string, List<FieldDescribe>> _TableInfo { get; set; }

        public InsOrUpdOrDelBase(AbstractAdo _Ado, Analysis analysis)
        {
            this.Sql = new SQL();
            this.IgnoreColumns = new List<string>();
            this.Sql.IsAlias = false;
            this.Ado = _Ado;
            this._Analysis = analysis;
            this._TableInfo = DbTable.GetTable(typeof(T));
        }

        /// <summary>
        /// 忽略列解析
        /// </summary>
        /// <param name="IgnoreColumns"></param>
        /// <returns></returns>
        protected string IgnoreColsAnalysis(Expression<Func<T, dynamic>> IgnoreColumns)
        {
            var _Body = IgnoreColumns.Body;

            if (_Body is UnaryExpression)
            {
                var _UnaryExpression = _Body as UnaryExpression;
                var _Operand = _UnaryExpression.Operand;
                if (_Operand is MemberExpression)
                {
                    var _MemberExpression = _Operand as MemberExpression;
                    return _MemberExpression.Member.Name;
                }
            }
            else if (_Body is MemberExpression)
            {
                var _MemberExpression = _Body as MemberExpression;
                return _MemberExpression.Member.Name;
            }

            throw new DbFrameException("IgnoreCols 语法无法解析!");
        }


        #region Ado

        protected int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (Ado.CommitState) return Ado._DbConnection.Execute(sql, param, transaction, commandTimeout, commandType);
            using (var conn = Ado.GetDbConnection()) return conn.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        protected object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (Ado.CommitState) return Ado._DbConnection.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
            using (var conn = Ado.GetDbConnection()) return conn.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
        }

        protected TR ExecuteScalar<TR>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (Ado.CommitState) return Ado._DbConnection.ExecuteScalar<TR>(sql, param, transaction, commandTimeout, commandType);
            using (var conn = Ado.GetDbConnection()) return conn.ExecuteScalar<TR>(sql, param, transaction, commandTimeout, commandType);
        }

        #endregion

        #region Ado Async

        protected async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (Ado.CommitState) return await Ado._DbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
            using (var conn = Ado.GetDbConnection()) return await conn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }

        protected async Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (Ado.CommitState) return await Ado._DbConnection.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
            using (var conn = Ado.GetDbConnection()) return await conn.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
        }

        protected async Task<TR> ExecuteScalarAsync<TR>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (Ado.CommitState) return await Ado._DbConnection.ExecuteScalarAsync<TR>(sql, param, transaction, commandTimeout, commandType);
            using (var conn = Ado.GetDbConnection()) return await conn.ExecuteScalarAsync<TR>(sql, param, transaction, commandTimeout, commandType);
        }

        #endregion

    }
}
