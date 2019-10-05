namespace DbFrame.DbContext.SqlServer.Achieve
{
    //
    using System.Data;
    using System.Data.SqlClient;
    using DbFrame.Core.Achieve;

    public class SqlServerAdoAchieve : AdoAchieve
    {

        public SqlServerAdoAchieve(string ConnectionString)
            : base(ConnectionString)
        {

        }

        /// <summary>
        /// 数据库 连接对象
        /// </summary>
        /// <returns></returns>
        public override IDbConnection GetDbConnection()
        {
            return new SqlConnection(this._ConnectionString);
        }


    }
}
