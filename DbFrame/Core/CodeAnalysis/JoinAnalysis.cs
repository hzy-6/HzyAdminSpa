namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class JoinAnalysis
    {


        public void Create(SQL _Sql, LambdaExpression _LambdaExpression, EJoinType _EJoinType, Analysis analysis)
        {
            PropertyInfo propertyInfo = null;
            foreach (var item in _LambdaExpression.Parameters)
            {
                var _TypeInfo = item.Type as TypeInfo;
                propertyInfo = _TypeInfo.GetProperties().OrderByDescending(w => w.Name).ToList()[0];
            }

            var _Alias = DbSettings.KeywordHandle(propertyInfo.Name);
            var _TabName = DbSettings.KeywordHandle(propertyInfo.PropertyType.Name);

            _Sql.Code_Join.AppendFormat(" {0} {1} AS {2} ON ", _EJoinType.ToString().Replace("_", " "), _TabName, _Alias);
            var _New_Sql = new SQL();
            _New_Sql.Parameter = _Sql.Parameter;

            analysis.CreateWhere(_LambdaExpression, _New_Sql);

            _Sql.Code_Join.Append(_New_Sql.Code_Where);

            _Sql.Parameter = _New_Sql.Parameter;

            _Sql.Alias[_Alias] = _TabName;

            if (!_Sql.TableNames.Contains(propertyInfo.PropertyType.Name)) _Sql.TableNames.Add(propertyInfo.PropertyType.Name);

        }





    }
}
