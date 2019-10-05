namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;

    public class DistinctAnalysis
    {

        public void Create(SQL _Sql)
        {
            if (!_Sql.Code_Column.ToString().ToLower().Contains("DISTINCT".ToLower()))
            {
                _Sql.Code_Column.Insert(0, " DISTINCT ");
            }

        }

    }
}
