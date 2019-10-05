using System.Collections.Generic;

namespace DbFrame.Core.Achieve.Query
{
    using System.Linq;
    using System.Data;
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using DbFrame.Core.Abstract.Query;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.Core.Interface.Query;
    using System.Threading.Tasks;
    using System;

    public class MappingDataAchieve<T> : AbstractMappingData<T>
    {
        public MappingDataAchieve(SQL _Sql, AbstractAdo _Ado, Analysis _Analysis)
        {
            this.Ado = _Ado;
            this.SqlCode = _Sql;
            this.analysis = _Analysis;
        }


        public override int Count()
        {
            return this.analysis.Count(this.SqlCode);
        }

        public override T First()
        {
            return this.First<T>();
        }

        public override TReturn First<TReturn>()
        {
            this.Top(1);

            this.ToSql();
            var _T = this.Ado.QueryFirstOrDefault<TReturn>(this.SqlCode.Code.ToString(), this.SqlCode.GetDynamicParameters());
            if (_T == null)
                return Parser.CreateInstance<TReturn>();
            return _T;
        }

        public override List<T> ToList()
        {
            return this.ToList<T>();
        }

        public override List<TReturn> ToList<TReturn>()
        {
            this.ToSql();

            var _List = this.Ado.Query<TReturn>(this.SqlCode.Code.ToString(), this.SqlCode.GetDynamicParameters()).ToList();
            if (_List == null)
                return new List<TReturn>();
            return _List;
        }

        public override DataTable ToTable()
        {
            this.ToSql();

            return this.Ado.QueryDataTable(this.SqlCode.Code.ToString(), this.SqlCode.GetDynamicParameters());
        }

        #region Async

        public override async Task<int> CountAsync()
        {
            return await this.analysis.CountAsync(this.SqlCode);
        }

        public override async Task<T> FirstAsync()
        {
            return await this.FirstAsync<T>();
        }

        public override async Task<TReturn> FirstAsync<TReturn>()
        {
            this.Top(1);

            this.ToSql();
            var _T = await this.Ado.QueryFirstOrDefaultAsync<TReturn>(this.SqlCode.Code.ToString(), this.SqlCode.GetDynamicParameters());
            if (_T == null)
                return Parser.CreateInstance<TReturn>();
            return _T;
        }

        public override async Task<List<T>> ToListAsync()
        {
            return await this.ToListAsync<T>();
        }

        public override async Task<List<TReturn>> ToListAsync<TReturn>()
        {
            this.ToSql();

            var _List = await this.Ado.QueryAsync<TReturn>(this.SqlCode.Code.ToString(), this.SqlCode.GetDynamicParameters());
            if (_List == null)
                return new List<TReturn>();
            return _List.ToList();
        }

        public override async Task<DataTable> ToTableAsync()
        {
            this.ToSql();

            return await this.Ado.QueryDataTableAsync(this.SqlCode.Code.ToString(), this.SqlCode.GetDynamicParameters());
        }

        #endregion

        //
        public override IMappingData Distinct()
        {
            this.analysis.CreateDistinct(this.SqlCode);
            return this;
        }

        public override List<DbParam> GetDbParam()
        {
            return this.SqlCode.Parameter;
        }

        public override IMappingData TakePage(int PageNumber, int PageSize)
        {
            this.analysis.CreateTakePage(this.SqlCode, PageNumber, PageSize);
            return this;
        }

        public override IMappingData TakePage(int PageNumber, int PageSize, out int TotalCount)
        {
            TotalCount = this.Count();
            this.analysis.CreateTakePage(this.SqlCode, PageNumber, PageSize);
            return this;
        }


        public override IMappingData Top(int Top)
        {
            this.analysis.CreateTop(Top, this.SqlCode);
            return this;
        }

        public override IMappingData ToSql(out SQL _SQL)
        {
            _SQL = this.ToSql();
            return this;
        }

        public override SQL ToSql()
        {
            Analysis.ToSql(this.SqlCode, this.Ado.CommitState);

            return this.SqlCode;
        }



    }
}
