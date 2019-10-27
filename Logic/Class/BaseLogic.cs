using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
    using System.Data;
    using System.Data.Common;
    using Entitys.SysClass;
    using Toolkit;
    using DbFrame;
    using DbFrame.BaseClass;
    using Dapper;
    using DbFrame.Core.Interface.Query;

    public class BaseLogic : AppBase
    {
        /// <summary>
        /// 登录 信息 对象
        /// </summary>
        public Account _Account { get; set; }

        public BaseLogic() { }


        /// <summary>
        /// 分页查询 通过 存储过程 PROC_SPLITPAGE
        /// </summary>
        /// <param name="SqlStr"></param>
        /// <param name="Page"></param>
        /// <param name="Rows"></param>
        /// <param name="Param"></param>
        /// <param name="TableNames">如果使用后端生成表头，则将查询所用到的表对应的Model传入进来</param>
        /// <param name="CallBack">数据完成后回调</param>
        /// <returns></returns>
        public async Task<TableViewModel> GetTableViewModel(string SqlStr, int Page, int Rows, DbParameter[] Param, List<string> TableNames, Action<TableViewModel> CallBack = null)
        {
            var _TableViewModel = new TableViewModel();

            if (Param != null)
            {
                //解析参数
                foreach (var item in Param)
                {
                    SqlStr = SqlStr.Replace("@" + item.ParameterName, item.Value == null ? null : "'" + item.Value + "' ");
                }
            }

            var _DynamicParameters = new DynamicParameters();
            _DynamicParameters.Add("@SQL", SqlStr, DbType.String, ParameterDirection.Input);
            _DynamicParameters.Add("@PAGE", Page, DbType.Int32, ParameterDirection.Input);
            _DynamicParameters.Add("@PAGESIZE", Rows, DbType.Int32, ParameterDirection.Input);
            _DynamicParameters.Add("@PAGECOUNT", 0, DbType.Int32, ParameterDirection.Output);
            _DynamicParameters.Add("@RECORDCOUNT", 0, DbType.Int32, ParameterDirection.Output);

            //将 IDataReader 对象转换为 DataSet 
            DataSet _DataSet = new AdoExtend.HZYDataSet();
            await db.ExecuteReaderAsync("PROC_SPLITPAGE", _DynamicParameters, null, 30, CommandType.StoredProcedure, (_IDataReader) =>
            {
                _DataSet.Load(_IDataReader, LoadOption.OverwriteChanges, null, new DataTable[] { });
            });

            if (_DataSet.Tables.Count == 2)
            {
                var _Table = _DataSet.Tables[1];
                var _Total = _DynamicParameters.Get<int>("@RECORDCOUNT");
                _TableViewModel.DataTable = _Table;
                _TableViewModel.TotalCount = _Total;
                _TableViewModel.TotalPage = (_Total / Rows);
                _TableViewModel.Rows = Rows;
                _TableViewModel.DataList = _Table.ToList();

                this.SetTableViewModel(_TableViewModel, TableNames.ToList());
            }

            CallBack?.Invoke(_TableViewModel);

            return _TableViewModel;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="Iquery">查询对象</param>
        /// <param name="_TotalCount">总数</param>
        /// <param name="Rows">每页显示条数</param>
        /// <param name="CustomHeader">是否采用后端生成表头</param>
        /// <param name="CallBack">数据完成后回调</param>
        /// <returns></returns>
        public async Task<TableViewModel> GetTableViewModel(IMappingData Iquery, int _TotalCount, int Rows, bool CustomHeader = true, Action<TableViewModel> CallBack = null, string DateTimeFormat = "yyyy-MM-dd HH:mm")
        {
            var _TableViewModel = new TableViewModel();

            var _Table = await Iquery.ToTableAsync();

            if (_Table.Columns.Contains("ROWID")) _Table.Columns.RemoveAt(0);

            _TableViewModel.DataTable = _Table;
            _TableViewModel.TotalCount = _TotalCount;
            _TableViewModel.TotalPage = (_TotalCount / Rows);
            _TableViewModel.Rows = Rows;
            _TableViewModel.DataList = _Table.ToList(DateTimeFormat);

            if (CustomHeader)
            {
                var _Sql = Iquery.ToSql();
                this.SetTableViewModel(_TableViewModel, _Sql.TableNames);
            }

            CallBack?.Invoke(_TableViewModel);

            return _TableViewModel;
        }

        private void SetTableViewModel(TableViewModel _TableViewModel, List<string> TableNames)
        {
            if (TableNames == null) return;
            if (TableNames.Count == 0) return;

            var _FieldDescribeList = new List<FieldDescribe>();
            foreach (var item in TableNames)
            {
                var Tuple = DbTable.GetTable(item);
                foreach (var Field in Tuple.Item2)
                {
                    _FieldDescribeList.Add(Field);
                }
            }

            var _TableColumns = _TableViewModel.DataTable.Columns;
            foreach (DataColumn dc in _TableColumns)
            {
                var _TableViewCol = new TableViewCol();
                var _FieldDescribe = _FieldDescribeList.Find(item => item.Name.Equals(dc.ColumnName));
                if (_FieldDescribe == null)
                    _TableViewCol.Title = dc.ColumnName == "_ukid" ? "ID" : dc.ColumnName;
                else
                    _TableViewCol.Title = string.IsNullOrWhiteSpace(_FieldDescribe.DisplayName) ? _TableViewCol.Title : _FieldDescribe.DisplayName;

                _TableViewCol.ColName = dc.ColumnName;
                _TableViewCol.Show = dc.ColumnName != "_ukid";
                _TableViewCol.Width = $"{(100 / _TableColumns.Count)}%";
                _TableViewModel.Cols.Add(_TableViewCol);
            }
        }


    }
}
