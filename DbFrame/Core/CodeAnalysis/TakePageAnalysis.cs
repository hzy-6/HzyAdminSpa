using System.Text;
namespace DbFrame.Core.CodeAnalysis
{
    //
    using DbFrame.BaseClass;
    using DbFrame.DbContext.SqlServer;

    /// <summary>
    /// 
    /// </summary>
    public class TakePageAnalysis
    {

        public void Create(SQL _Sql, int PageNumber, int PageSize, Analysis analysis)
        {
            //OFFSET  ( @pageSize * ( @pageIndex - 1 )) ROWS FETCH NEXT @pageSize ROWS ONLY;
            if (string.IsNullOrEmpty(_Sql.Code_OrderBy.ToString())) throw new DbFrameException("如果使用分页请 先排序！");

            if (analysis._DbContextType == DbContextType.SqlServer)
            {
                if (DbContextSqlServer._PagingMode == PagingMode.OFFSET)
                {
                    var _OFFSET = (PageSize * (PageNumber - 1));

                    _Sql.Code_TakePage.Clear().AppendFormat(" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY ", _OFFSET, PageSize);
                }
                else
                {
                    var _Column = _Sql.Code_Column.ToString();

                    var _RowId = @"ROW_NUMBER () OVER (  ORDER BY " + _Sql.Code_OrderBy + " ) AS ROWID,";

                    _Sql.Code_Column.Clear().Append(_RowId + _Column);

                    StringBuilder builder = new StringBuilder();

                    builder.AppendFormat("SELECT * FROM (#SqlString#) TAB_ROW_NUMBER WHERE ROWID BETWEEN {0} AND {1} ", (PageSize * (PageNumber - 1)) + 1, PageNumber * PageSize);

                    //清空 Orderby
                    _Sql.Code_OrderBy.Clear();
                    _Sql.Code_TakePage.Clear().Append(builder);
                }
            }
            else if (analysis._DbContextType == DbContextType.MySql)
            {
                var _OFFSET = (PageSize * (PageNumber - 1));
                _Sql.Code_TakePage.Clear().AppendFormat(" LIMIT {0},{1} ", _OFFSET, PageSize);
            }
            else if (analysis._DbContextType == DbContextType.Oracle)
            {
                var _Column = _Sql.Code_Column.ToString();

                var _RowId = @"ROW_NUMBER () OVER (  ORDER BY " + _Sql.Code_OrderBy + " ) AS ROWID,";

                _Sql.Code_Column.Clear().Append(_RowId + _Column);

                StringBuilder builder = new StringBuilder();

                builder.AppendFormat("SELECT * FROM (#SqlString#) TAB_ROW_NUMBER WHERE ROWID BETWEEN {0} AND {1} ", (PageSize * (PageNumber - 1)) + 1, PageNumber * PageSize);

                //清空 Orderby
                _Sql.Code_OrderBy.Clear();
                _Sql.Code_TakePage.Clear().Append(builder);
            }
            else if (analysis._DbContextType == DbContextType.PostgreSQL)
            {
                var _OFFSET = (PageSize * (PageNumber - 1));
                _Sql.Code_TakePage.Clear().AppendFormat(" LIMIT {0} OFFSET {1} ", PageSize, _OFFSET);
            }
        }

        /*
        SELECT * FROM
        (
            SELECT
                ROW_NUMBER () OVER (

                    ORDER BY
                        Designer_UserInfo.CreatTime DESC
                ) AS ROWID,
                Designer_UserInfo.ID,
                Designer_UserInfo.CreatTime,
                Designer_UserInfo.TrueName,
                Student_UserInfo.Age
            FROM
                Designer_UserInfo
            LEFT JOIN Student_UserInfo ON Designer_UserInfo.ID = Student_UserInfo.ID
        ) AS a
        WHERE ROWID BETWEEN 1 AND 3

        若把ROWID BETWEEN 1 AND 3改为 ROWID BETWEEN 3 AND 4则会返回最后两条，实际开发中变为 ROWID BETWEEN (pageindex-1)*pagesize+ 1 AND pageindex*pagesize即可 
    
         */


    }
}
