using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.CodeAnalysis
{
    //
    using System.Linq.Expressions;
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using DbFrame.Core.Interface;

    /// <summary>
    /// 解析
    /// </summary>
    public class Analysis : IAnalysis
    {
        protected AbstractAdo Ado { get; }

        public DbContextType _DbContextType { get; set; }

        public Analysis(AbstractAdo abstractAdo, DbContextType dbContextType)
        {
            this.Ado = abstractAdo;
            this._DbContextType = dbContextType;
        }

        /// <summary>
        /// 获取 Count 
        /// </summary>
        /// <param name="Ado"></param>
        /// <param name="_Sql"></param>
        public int Count(SQL _Sql)
        {
            var _New_Sql = new CountAnalysis().Create(_Sql);
            Analysis.ToSql(_New_Sql, Ado.CommitState);
            return Ado.ExecuteScalar<int>(_New_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }

        /// <summary>
        /// 获取 Count 
        /// </summary>
        /// <param name="Ado"></param>
        /// <param name="_Sql"></param>
        public async Task<int> CountAsync(SQL _Sql)
        {
            var _New_Sql = new CountAnalysis().Create(_Sql);
            Analysis.ToSql(_New_Sql, Ado.CommitState);
            return await Ado.ExecuteScalarAsync<int>(_New_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="Ado"></param>
        /// <param name="_Sql"></param>
        /// <returns></returns>
        public T Max<T>(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new Max_Min_Sum_Analysis(_Sql, "MAX").Visit(_LambdaExpression);
            Analysis.ToSql(_Sql, Ado.CommitState);
            return Ado.ExecuteScalar<T>(_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        /// <returns></returns>
        public async Task<T> MaxAsync<T>(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new Max_Min_Sum_Analysis(_Sql, "MAX").Visit(_LambdaExpression);
            Analysis.ToSql(_Sql, Ado.CommitState);
            return await this.Ado.ExecuteScalarAsync<T>(_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="Ado"></param>
        /// <param name="_Sql"></param>
        /// <returns></returns>
        public T Min<T>(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new Max_Min_Sum_Analysis(_Sql, "MIN").Visit(_LambdaExpression);
            Analysis.ToSql(_Sql, Ado.CommitState);
            return Ado.ExecuteScalar<T>(_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        /// <returns></returns>
        public async Task<T> MinAsync<T>(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new Max_Min_Sum_Analysis(_Sql, "MIN").Visit(_LambdaExpression);
            Analysis.ToSql(_Sql, Ado.CommitState);
            return await this.Ado.ExecuteScalarAsync<T>(_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="Ado"></param>
        /// <param name="_Sql"></param>
        /// <returns></returns>
        public T Sum<T>(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new Max_Min_Sum_Analysis(_Sql, "SUM").Visit(_LambdaExpression);
            Analysis.ToSql(_Sql, Ado.CommitState);
            return Ado.ExecuteScalar<T>(_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        /// <returns></returns>
        public async Task<T> SumAsync<T>(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new Max_Min_Sum_Analysis(_Sql, "SUM").Visit(_LambdaExpression);
            Analysis.ToSql(_Sql, Ado.CommitState);
            return await this.Ado.ExecuteScalarAsync<T>(_Sql.Code.ToString(), _Sql.GetDynamicParameters());
        }



        #region Create Sql



        /// <summary>
        /// 创建 Query 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        public void CreateQuery<T>(SQL _Sql)
        {
            new QueryAnalysis<T>().Create(_Sql);
        }

        /// <summary>
        /// 创建 GroupBy 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        public void CreateGroupBy(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new GroupByAnalysis(_Sql).Visit(_LambdaExpression);
        }

        /// <summary>
        /// 创建 GroupBy 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        public void CreateHaving(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            var _New_Sql = new SQL();
            _New_Sql.Parameter = _Sql.Parameter;
            _New_Sql.Alias = _Sql.Alias;
            _New_Sql.IsAlias = _Sql.IsAlias;

            this.CreateWhere(_LambdaExpression, _New_Sql);
            _Sql.Code_Having.Append(_New_Sql.Code_Where);
            _Sql.Parameter = _New_Sql.Parameter;
        }

        /// <summary>
        /// 创建 OrderBy 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        public void CreateOrderBy(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new OrderByAnalysis(_Sql).Visit(_LambdaExpression);
        }

        /// <summary>
        /// 创建 OrderBy  desc 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        public void CreateOrderByDESC(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new OrderByAnalysis(_Sql).CreateDESC(_LambdaExpression);
        }

        /// <summary>
        /// 创建 Select 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        public void CreateSelect(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new SelectAnalysis(_Sql).Visit(_LambdaExpression);
        }

        /// <summary>
        /// 创建 Where 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        public void CreateWhere(LambdaExpression _LambdaExpression, SQL _Sql)
        {
            new WhereAnalysis(_Sql).Visit(_LambdaExpression);
        }

        /// <summary>
        /// 创建 Join 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        /// <param name="_EJoinType"></param>
        public void CreateJoin(LambdaExpression _LambdaExpression, SQL _Sql, EJoinType _EJoinType)
        {
            new JoinAnalysis().Create(_Sql, _LambdaExpression, _EJoinType, this);
        }

        /// <summary>
        /// 创建 TOP 对象
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="_Sql"></param>
        public void CreateTop(int Top, SQL _Sql)
        {
            new TopAnalysis().Create(_Sql, Top, this);
        }

        /// <summary>
        /// 创建 Distinct 对象
        /// </summary>
        /// <param name="_Sql"></param>
        public void CreateDistinct(SQL _Sql)
        {
            new DistinctAnalysis().Create(_Sql);
        }

        /// <summary>
        /// 创建 分页 对象
        /// </summary>
        /// <param name="_Sql"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        public void CreateTakePage(SQL _Sql, int PageNumber, int PageSize)
        {
            new TakePageAnalysis().Create(_Sql, PageNumber, PageSize, this);
        }

        /// <summary>
        /// SQL 对象中 sql 语句 转换为String
        /// </summary>
        /// <param name="_Sql"></param>
        /// <returns></returns>
        public static string SqlToString(SQL _Sql)
        {
            if (string.IsNullOrEmpty(_Sql.Code.ToString()))
            {
                ToSql(_Sql, false);
            }

            var _SqlCode = _Sql.Code.ToString();

            if (string.IsNullOrEmpty(_SqlCode)) return null;

            if (_Sql.Parameter == null) return _SqlCode;

            foreach (var item in _Sql.Parameter)
            {
                _SqlCode = _SqlCode.Replace("@" + item.ParameterName, item.Value == null ? null : "'" + item.Value.ToString() + "' ");
            }

            return _SqlCode;
        }

        /// <summary>
        /// 将 SQL 对象 中的 代码 组装
        /// </summary>
        /// <param name="_Sql"></param>
        public static void ToSql(SQL _Sql, bool _WithNolock)
        {
            //组装Sql
            _Sql.Code.Clear();

            //ROWS FETCH 分页
            var _Code_TakePage_String = _Sql.Code_TakePage.ToString();

            if (!string.IsNullOrEmpty(_Code_TakePage_String) && !_Code_TakePage_String.Contains("#SqlString#"))
            {
                _Sql.Code_OrderBy.Append(_Code_TakePage_String);
            }

            //组装
            _Sql.Code.AppendFormat(" SELECT {0} FROM {1}", _Sql.Code_Column, _Sql.Code_FromTab);

            if (!string.IsNullOrEmpty(_Sql.Code_Join.ToString()))
            {
                _Sql.Code.AppendFormat(" {0}", _Sql.Code_Join);
            }

            if (!string.IsNullOrEmpty(_Sql.Code_Where.ToString()))
            {
                _Sql.Code.AppendFormat(" WHERE 1=1 {0}", _Sql.Code_Where);
            }

            if (!string.IsNullOrEmpty(_Sql.Code_GroupBy.ToString()))
            {
                _Sql.Code.AppendFormat(" GROUP BY {0}", _Sql.Code_GroupBy);
            }

            if (!string.IsNullOrEmpty(_Sql.Code_Having.ToString()))
            {
                _Sql.Code.AppendFormat(" HAVING {0}", _Sql.Code_Having);
            }

            if (!string.IsNullOrEmpty(_Sql.Code_OrderBy.ToString()))
            {
                _Sql.Code.AppendFormat(" ORDER BY {0}", _Sql.Code_OrderBy);
            }

            //ROW_NUMBER 分页

            if (!string.IsNullOrEmpty(_Code_TakePage_String) && _Code_TakePage_String.Contains("#SqlString#"))
            {
                _Code_TakePage_String = _Code_TakePage_String.Replace("#SqlString#", _Sql.Code.ToString());

                _Sql.Code.Clear().Append(_Code_TakePage_String);
            }

            //如果开启事务 则禁止 查询锁表
            //if (_WithNolock)
            //{
            //    _Sql.Code.Replace("(# WITH(NOLOCK) #)", " WITH(NOLOCK) ");
            //}
            //else
            //{
            //    _Sql.Code.Replace("(# WITH(NOLOCK) #)", "");
            //}

        }

        #endregion








    }


}
