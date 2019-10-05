using System;
using System.Collections.Generic;
using System.Text;

namespace Entitys.SysClass
{
    using System.Data;
    using System.Text.Json.Serialization;

    public class TableViewModel
    {
        public int status { get; set; } = 1;

        public List<TableViewCol> Cols { get; set; } = new List<TableViewCol>();

        [JsonIgnore]
        public DataTable DataTable { get; set; } = new DataTable();

        public List<Dictionary<string, object>> DataList { get; set; } = new List<Dictionary<string, object>>();

        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 一页显示多少条
        /// </summary>
        public int Rows { get; set; }

    }

    /// <summary>
    /// 列头信息
    /// </summary>
    public class TableViewCol
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColName { get; set; }

        /// <summary>
        /// 列别名
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 列宽度
        /// </summary>
        public string Width { get; set; } = "200";

        /// <summary>
        /// 固定列需要使用fixed属性，它接受 Boolean 值或者leftright，表示左边固定还是右边固定。
        /// </summary>
        public object Fixed { get; set; } = null;

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show { get; set; } = true;

        /// <summary>
        /// 是否排序
        /// </summary>
        public bool Sortable { get; set; } = false;


    }

}
