using System;
using System.Collections.Generic;

using System.Text;

namespace DbFrame.Core.Interface.Query
{
    using DbFrame.BaseClass;
    using System.Data;
    using System.Threading.Tasks;

    public interface IMappingData
    {
        TReturn First<TReturn>();
        List<TReturn> ToList<TReturn>();
        DataTable ToTable();
        int Count();

        #region Async
        Task<TReturn> FirstAsync<TReturn>();
        Task<List<TReturn>> ToListAsync<TReturn>();
        Task<DataTable> ToTableAsync();
        Task<int> CountAsync();
        #endregion

        List<DbParam> GetDbParam();
        SQL ToSql();
        //
        IMappingData Top(int Top);
        IMappingData Distinct();
        IMappingData TakePage(int PageNumber, int PageSize);
        IMappingData TakePage(int PageNumber, int PageSize, out int TotalCount);
        IMappingData ToSql(out SQL _SQL);
    }

    public interface IMappingData<T> : IMappingData
    {
        T First();
        List<T> ToList();

        #region Async
        Task<T> FirstAsync();
        Task<List<T>> ToListAsync();
        #endregion

    }

}
