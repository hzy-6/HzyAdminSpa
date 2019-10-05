namespace AdoExtend
{
    using System.Data;
    using System.Data.Common;
    public class HZYDataAdapter : DataAdapter
    {
        public HZYDataAdapter() { }

        public int FillFromReader(DataSet _DataSet, IDataReader _IDataReader, int StartRecord, int MaxRecords)
        {
            var TableName = _IDataReader.GetSchemaTable().Rows[0]["BaseTableName"].ToString();

            TableName = string.IsNullOrEmpty(TableName) ? _IDataReader.GetSchemaTable().TableName : TableName;

            return this.Fill(_DataSet, TableName, _IDataReader, StartRecord, MaxRecords);
        }


    }
}
