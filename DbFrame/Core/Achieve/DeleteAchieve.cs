using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Achieve
{
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.Core.Interface;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class DeleteAchieve<T> : AbstractDelete<T>
    {
        public DeleteAchieve(AbstractAdo _Ado, Analysis _Analysis)
            : base(_Ado, _Analysis)
        {

        }

        public override IDelete<T> Execute(List<SQL> SqlContainer)
        {
            this.ToSql();
            SqlContainer.Add(this.Sql);
            return this;
        }

        public override int Execute()
        {
            this.ToSql();
            //如果开启了 Commit 状态
            if (Ado.CommitState)
                return this.Execute(this.Sql.Code.ToString(), this.Sql.GetDynamicParameters(), this.Ado._DbTransaction);
            return this.Execute(this.Sql.Code.ToString(), this.Sql.GetDynamicParameters());
        }

        public override Task<int> ExecuteAsync()
        {
            this.ToSql();
            //如果开启了 Commit 状态
            if (Ado.CommitState)
                return Task.FromResult(this.Execute(this.Sql.Code.ToString(), this.Sql.GetDynamicParameters(), this.Ado._DbTransaction));
            return this.ExecuteAsync(this.Sql.Code.ToString(), this.Sql.GetDynamicParameters());
        }

        public override IDelete<T> Where(Expression<Func<HzyTuple<T>, bool>> Where)
        {
            if (Where == null) throw new DbFrameException("Where 条件不能为NULL!");

            this.Sql.Code_Where.Append(" AND ");

            this._Analysis.CreateWhere(Where, this.Sql);

            return this;
        }

        public override IDelete<T> WhereIF(bool IF, Expression<Func<HzyTuple<T>, bool>> Where)
        {
            if (IF) this.Where(Where);

            return this;
        }

        public override SQL ToSql()
        {
            var _TableInfo = DbTable.GetTable(typeof(T));
            var _Table = _TableInfo.Item2;
            var _TableName = _TableInfo.Item1;

            _TableName = DbSettings.KeywordHandle(_TableName);

            this.Sql.Code.Append($"DELETE FROM {_TableName} WHERE 1=1 {this.Sql.Code_Where} ;");

            return this.Sql;
        }
    }
}
