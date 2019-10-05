using System.Collections.Generic;
using System.Text;

namespace DbFrame.BaseClass
{
    using Dapper;

    public class SQL
    {
        /// <summary>
        /// Sql 代码
        /// </summary>
        public StringBuilder Code { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public List<DbParam> Parameter { get; set; }

        /// <summary>
        /// 是否 有别名
        /// </summary>
        public bool IsAlias { get; set; }

        /// <summary>
        /// 别名 集合
        /// </summary>
        public Dictionary<string, object> Alias { get; set; }

        /// <summary>
        /// 表名容器
        /// </summary>
        public List<string> TableNames { get; set; }

        #region 语句记录容器
        public StringBuilder Code_Column { get; set; }

        public StringBuilder Code_FromTab { get; set; }

        public StringBuilder Code_Join { get; set; }

        public StringBuilder Code_Where { get; set; }

        public StringBuilder Code_OrderBy { get; set; }

        public StringBuilder Code_GroupBy { get; set; }

        public StringBuilder Code_Having { get; set; }

        public StringBuilder Code_TakePage { get; set; }
        #endregion

        public SQL(StringBuilder _StringBuilder, List<DbParam> _Parameter)
        {
            this.IsAlias = true;
            this.Alias = new Dictionary<string, object>();
            this.Parameter = new List<DbParam>();
            this.TableNames = new List<string>();

            this.Code = new StringBuilder();
            this.Code_Column = new StringBuilder();
            this.Code_FromTab = new StringBuilder();
            this.Code_Join = new StringBuilder();
            this.Code_Where = new StringBuilder();
            this.Code_OrderBy = new StringBuilder();
            this.Code_GroupBy = new StringBuilder();
            this.Code_Having = new StringBuilder();
            this.Code_TakePage = new StringBuilder();

            this.Parameter = _Parameter;
            this.Code = _StringBuilder;
        }

        public SQL()
        {
            this.IsAlias = true;
            this.Alias = new Dictionary<string, object>();
            this.Parameter = new List<DbParam>();
            this.TableNames = new List<string>();

            this.Code = new StringBuilder();
            this.Code_Column = new StringBuilder();
            this.Code_FromTab = new StringBuilder();
            this.Code_Join = new StringBuilder();
            this.Code_Where = new StringBuilder();
            this.Code_OrderBy = new StringBuilder();
            this.Code_GroupBy = new StringBuilder();
            this.Code_Having = new StringBuilder();
            this.Code_TakePage = new StringBuilder();
        }

        /// <summary>
        /// 将参数转换为 DynamicParameters 对象
        /// </summary>
        /// <returns></returns>
        public DynamicParameters GetDynamicParameters()
        {
            var _DynamicParameters = new DynamicParameters();
            foreach (var item in this.Parameter)
            {
                _DynamicParameters.Add(item.ParameterName, item.Value);
            }
            return _DynamicParameters;
        }

    }
}
