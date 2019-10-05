namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryAnalysis<T>
    {

        public void Create(SQL _Sql)
        {
            _Sql.IsAlias = true;
            var _TableInfo = DbTable.GetTable(typeof(T));
            var _TableName = DbSettings.KeywordHandle(_TableInfo.Item1);

            var _Type = typeof(HzyTuple<T>);
            var _Propertie = _Type.GetProperties()[0];

            _Sql.Code_Column.Clear().Append("*");//记录列

            var _Alias = DbSettings.KeywordHandle(_Propertie.Name);
            _Sql.Alias[_Alias] = _TableName;
            if (!_Sql.TableNames.Contains(_TableInfo.Item1)) _Sql.TableNames.Add(_TableInfo.Item1);

            _Sql.Code_FromTab.AppendFormat(_TableName + " AS " + _Propertie.Name);//select * from Member with(nolock)


        }

    }
}
