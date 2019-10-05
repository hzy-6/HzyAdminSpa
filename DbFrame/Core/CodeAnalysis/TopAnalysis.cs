namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;

    public class TopAnalysis
    {
        public void Create(SQL _Sql, int Top, Analysis analysis)
        {
            if (analysis._DbContextType == DbContextType.SqlServer)
            {
                var _TOP = "TOP";
                var _DISTINCT = "DISTINCT";

                var _Codes = _Sql.Code_Column.ToString().ToLower();
                if (!_Codes.Contains(_TOP.ToLower()))
                {
                    if (_Codes.TrimStart().StartsWith(_DISTINCT.ToLower()))
                    {
                        _Sql.Code_Column.Replace(_DISTINCT, $" {_DISTINCT} TOP ({Top}) ");
                    }
                    else
                    {
                        _Sql.Code_Column.Insert(0, $" TOP ({Top}) ");
                    }
                }
            }
            else if (analysis._DbContextType == DbContextType.MySql)
            {
                var _Codes = _Sql.Code_Column.ToString().ToLower();
                _Sql.Code_TakePage.Insert(0, $" LIMIT {Top}");
            }

        }



    }
}
