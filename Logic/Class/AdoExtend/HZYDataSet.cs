namespace AdoExtend
{
    using System.Data;

    public class HZYDataSet : DataSet
    {

        public override void Load(IDataReader _IDataReader, LoadOption _LoadOption, FillErrorEventHandler _FillErrorEventHandler, params DataTable[] Tables)
        {
            HZYDataAdapter _HZYDataAdapter = new HZYDataAdapter
            {
                FillLoadOption = _LoadOption,
                MissingSchemaAction = MissingSchemaAction.AddWithKey
            };
            if (_FillErrorEventHandler != null) _HZYDataAdapter.FillError += _FillErrorEventHandler;
            _HZYDataAdapter.FillFromReader(this, _IDataReader, 0, 0);
            if (!_IDataReader.IsClosed && !_IDataReader.NextResult()) _IDataReader.Close();
        }


    }
}
