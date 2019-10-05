using System;

namespace DbFrame.DbContext.SqlServer
{
    using DbFrame.BaseClass;
    using DbFrame.Core.Achieve;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.DbContext.SqlServer.Achieve;

    /// <summary>
    /// SqlServer 实现
    /// </summary>
    public class DbContextSqlServer : BaseDb
    {
        public DbContextSqlServer(PagingMode pagingMode = PagingMode.OFFSET)
        {
            _PagingMode = pagingMode;
            DbSettings.KeywordHandle = (Keyword) => "[" + Keyword + "]";
            this.LastInsertId = "SELECT @@IDENTITY;";
            this.Ado = new SqlServerAdoAchieve(this.ConnectionString);
            this.analysis = new Analysis(this.Ado, DbContextType.SqlServer);
        }

        public DbContextSqlServer(string _ConnectionString, PagingMode pagingMode = PagingMode.OFFSET) : base(_ConnectionString)
        {
            _PagingMode = pagingMode;
            DbSettings.KeywordHandle = (Keyword) => "[" + Keyword + "]";
            this.LastInsertId = "SELECT @@IDENTITY;";
            this.Ado = new SqlServerAdoAchieve(this.ConnectionString);
            this.analysis = new Analysis(this.Ado, DbContextType.SqlServer);
        }

        /// <summary>
        /// 分页方式
        /// </summary>
        public static PagingMode _PagingMode { get; set; }

        /// <summary>
        /// 注册数据访问对象
        /// </summary>
        /// <param name="_ConnectionString"></param>
        /// <param name="TableInit"></param>
        public static void Register(string _ConnectionString, Action<DbTable> TableInit)
        {
            DbSettings.DefaultConnectionString = _ConnectionString;
            TableInit?.Invoke(new DbTable());
        }

    }

    /// <summary>
    /// 分页模式
    /// </summary>
    public enum PagingMode
    {
        /// <summary>
        /// sqlserver 常规分页
        /// </summary>
        ROW_NUMBER,
        /// <summary>
        /// sqlserver 2012 以上支持
        /// </summary>
        OFFSET

    }




}
