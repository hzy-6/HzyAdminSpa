
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.Achieve.Query
{
    using System.Data;
    using System.Linq.Expressions;
    using System.Reflection;
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using DbFrame.Core.Abstract.Query;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.Core.Interface.Query;
    using DbFrame.Core.Achieve.Query;

    public class QueryAchieve<T> : AbstractQuery<T>
    {
        protected MappingDataAchieve<T> _MappingDataAchieve = null;

        public QueryAchieve(SQL _Sql, AbstractAdo _Ado, Analysis _Analysis)
        {
            this.Ado = _Ado;
            this.SqlCode = _Sql;
            this.analysis = _Analysis;
            this.SqlCode.IsAlias = true;
            this.analysis.CreateQuery<T>(this.SqlCode);
            this._MappingDataAchieve = new MappingDataAchieve<T>(_Sql, _Ado, _Analysis);
        }

        public override IJoin<T, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN)
        {
            if (ON == null) throw new DbFrameException(" Join 连接对象不能为 NULL ！");
            this.analysis.CreateJoin(ON, this.SqlCode, _EJoinType);
            return new JoinAchieve<T, TJoin>(this.SqlCode, this.Ado, this.analysis);
        }

        public override IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Select)
        {
            //解析 列
            this.analysis.CreateSelect(Select, this.SqlCode);
            return new MappingDataAchieve<TReturn>(this.SqlCode, this.Ado, this.analysis);
        }

        public override IMappingData<TReturn> Select<TReturn>(string Select = "*")
        {
            this.SqlCode.Code_Column.Clear().Append(Select);
            return new MappingDataAchieve<TReturn>(this.SqlCode, this.Ado, this.analysis);
        }

        public override IQuery<T> Where(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            if (Where == null) return this;
            this.SqlCode.Code_Where.Append(" AND ");
            this.analysis.CreateWhere(Where, this.SqlCode);
            return this;
        }

        public override IQuery<T> WhereIF(bool IsWhere, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            if (IsWhere) return this.Where(Where);
            return this;
        }

        public override IQuery<T> GroupBy<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> GroupBy)
        {
            this.analysis.CreateGroupBy(GroupBy, this.SqlCode);
            return this;
        }

        public override IQuery<T> Having(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            this.analysis.CreateHaving(Where, this.SqlCode);
            return this;
        }

        public override IQuery<T> OrderBy<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> OrderBy)
        {
            this.analysis.CreateOrderBy(OrderBy, this.SqlCode);
            return this;
        }

        public override IQuery<T> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T>, TReturn>> OrderBy)
        {
            if (IF) return this.OrderBy(OrderBy);
            return this;
        }

        public override IQuery<T> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> OrderBy)
        {
            this.analysis.CreateOrderByDESC(OrderBy, this.SqlCode);
            return this;
        }

        public override IQuery<T> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T>, TReturn>> OrderBy)
        {
            if (IF) return this.OrderByDesc(OrderBy);
            return this;
        }

        public override IQuery<T> SqlString(Action<SQL> _Action)
        {
            _Action?.Invoke(this.SqlCode);
            return this;
        }


        //
        public override int Count()
        {
            return this._MappingDataAchieve.Count();
        }
        public override T First()
        {
            return this._MappingDataAchieve.First();
        }

        public override TReturn First<TReturn>()
        {
            return this._MappingDataAchieve.First<TReturn>();
        }

        public override TReturn Max<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Max)
        {
            return this.analysis.Max<TReturn>(Max, this.SqlCode);
        }

        public override TReturn Min<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Min)
        {
            return this.analysis.Min<TReturn>(Min, this.SqlCode);
        }

        public override TReturn Sum<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Sum)
        {
            return this.analysis.Sum<TReturn>(Sum, this.SqlCode);
        }

        public override List<T> ToList()
        {
            return this._MappingDataAchieve.ToList();
        }

        public override List<TReturn> ToList<TReturn>()
        {
            return this._MappingDataAchieve.ToList<TReturn>();
        }

        public override DataTable ToTable()
        {
            return this._MappingDataAchieve.ToTable();
        }



        //
        public override List<DbParam> GetDbParam()
        {
            return this._MappingDataAchieve.GetDbParam();
        }

        public override IMappingData Distinct()
        {
            return this._MappingDataAchieve.Distinct();
        }

        public override IMappingData TakePage(int PageNumber, int PageSize)
        {
            return this._MappingDataAchieve.TakePage(PageNumber, PageSize);
        }

        public override IMappingData TakePage(int PageNumber, int PageSize, out int TotalCount)
        {
            return this._MappingDataAchieve.TakePage(PageNumber, PageSize, out TotalCount);
        }

        public override IMappingData Top(int Top)
        {
            return this._MappingDataAchieve.Top(Top);
        }

        public override IMappingData ToSql(out SQL _SQL)
        {
            return this._MappingDataAchieve.ToSql(out _SQL);
        }

        public override SQL ToSql()
        {
            return this._MappingDataAchieve.ToSql();
        }


        #region Async


        public override async Task<int> CountAsync()
        {
            return await this._MappingDataAchieve.CountAsync();
        }
        public override async Task<T> FirstAsync()
        {
            return await this._MappingDataAchieve.FirstAsync();
        }

        public override async Task<TReturn> FirstAsync<TReturn>()
        {
            return await this._MappingDataAchieve.FirstAsync<TReturn>();
        }

        public override async Task<TReturn> MaxAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Max)
        {
            return await this.analysis.MaxAsync<TReturn>(Max, this.SqlCode);
        }

        public override async Task<TReturn> MinAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Min)
        {
            return await this.analysis.MinAsync<TReturn>(Min, this.SqlCode);
        }

        public override async Task<TReturn> SumAsync<TReturn>(Expression<Func<HzyTuple<T>, TReturn>> Sum)
        {
            return await this.analysis.SumAsync<TReturn>(Sum, this.SqlCode);
        }

        public override async Task<List<T>> ToListAsync()
        {
            return await this._MappingDataAchieve.ToListAsync();
        }

        public override async Task<List<TReturn>> ToListAsync<TReturn>()
        {
            return await this._MappingDataAchieve.ToListAsync<TReturn>();
        }

        public override async Task<DataTable> ToTableAsync()
        {
            return await this._MappingDataAchieve.ToTableAsync();
        }


        #endregion Async


    }





}


