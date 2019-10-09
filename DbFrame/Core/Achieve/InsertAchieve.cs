using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Achieve
{
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using DbFrame.Core.CodeAnalysis;
    using DbFrame.Core.Interface;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class InsertAchieve<T> : AbstractInsert<T>
    {
        protected string LastInsertId { get; set; }
        private FieldDescribe _KeyFieldDescribe { get; set; }
        public InsertAchieve(MemberInitExpression _Set, AbstractAdo _Ado, Analysis _Analysis, string _LastInsertId)
            : base(_Set, _Ado, _Analysis)
        {
            this.LastInsertId = _LastInsertId;
        }

        public override IInsert<T> Execute(List<SQL> SqlContainer, out object Id)
        {
            this.ToSql(out object _KeyId);
            Id = _KeyId;
            SqlContainer.Add(this.Sql);
            return this;
        }

        public override object Execute()
        {
            this.ToSql(out object _KeyId);
            object _ResKeyId = null;

            //如果开启了 Commit 状态
            if (this.Ado.CommitState)
                _ResKeyId = this.ExecuteScalar(Sql.Code.ToString(), Sql.GetDynamicParameters(), this.Ado._DbTransaction);
            else
                _ResKeyId = this.ExecuteScalar(Sql.Code.ToString(), Sql.GetDynamicParameters());

            if (_ResKeyId == null)
                return (this._KeyFieldDescribe == null) ? null : _KeyId;
            return _ResKeyId;
        }

        public override Task<object> ExecuteAsync()
        {
            this.ToSql(out object _KeyId);
            object _ResKeyId = null;

            //如果开启了 Commit 状态
            if (this.Ado.CommitState)
                _ResKeyId = this.ExecuteScalar(Sql.Code.ToString(), Sql.GetDynamicParameters(), this.Ado._DbTransaction);
            else
                _ResKeyId = this.ExecuteScalarAsync(Sql.Code.ToString(), Sql.GetDynamicParameters()).Result;

            if (_ResKeyId == null)
                return (this._KeyFieldDescribe == null) ? null : (_KeyId == null ? null : Task.FromResult(_KeyId));
            return Task.FromResult(_ResKeyId);
        }

        public override IInsert<T> IgnoreCols(Expression<Func<T, dynamic>> IgnoreColumns)
        {
            this.IgnoreColumns.Add(this.IgnoreColsAnalysis(IgnoreColumns));

            return this;
        }

        public override IInsert<T> IgnoreColsIF(bool IF, Expression<Func<T, dynamic>> IgnoreColumns)
        {
            if (IF) this.IgnoreCols(IgnoreColumns);

            return this;
        }

        public override SQL ToSql(out object Id)
        {
            var _Cols = new List<string>();
            var _Values = new List<string>();
            object _KeyId = null;

            var _Table = _TableInfo.Item2;
            var _KeyInfo = _Table.FirstOrDefault(w => w.IsKey);
            this._KeyFieldDescribe = _KeyInfo;
            var _TableName = _TableInfo.Item1;
            var TableName = DbSettings.KeywordHandle(_TableName);
            var _SetStr = new List<string>();

            //加入忽略字段 两个集合合并
            IgnoreColumns = IgnoreColumns.Union(_Table.Where(w => w.IsIgnore).Select(w => w.Name).ToList()).ToList();

            foreach (MemberAssignment item in memberInitExpression.Bindings)
            {
                var _Name = item.Member.Name;

                //检测有无忽略字段
                if (IgnoreColumns.Any(w => w == _Name)) continue;

                var _Val = Parser.Eval(item.Expression);
                if (_KeyInfo != null && _KeyInfo?.Name == _Name)
                {
                    //如果主键自增
                    if (_KeyInfo.IsIdentity)
                    {
                        if (this._Analysis._DbContextType == DbContextType.Oracle)
                            _Val = "MY_SEQ.NEXTVAL";//MY_SEQ.NEXTVAL
                        else if (this._Analysis._DbContextType == DbContextType.PostgreSQL)
                            LastInsertId = LastInsertId.Replace("#ID#", _Name);
                        else
                            continue;
                    }
                    else
                    {
                        _KeyId = this.CheckKey(_KeyInfo, _Val);
                        _Val = _KeyId;
                    }
                }

                var _Count = Sql.Parameter.Count;
                _Cols.Add(_Name);
                _Values.Add("@" + _Name + "_" + _Count);
                Sql.Parameter.Add(new DbParam()
                {
                    ParameterName = "@" + _Name + "_" + _Count,
                    Value = _Val
                });
            }

            //检查是否有key
            if (_KeyInfo != null && !memberInitExpression.Bindings.Any(w => w.Member.Name == _KeyInfo?.Name))
            {
                bool _IsContinue = false;
                object _Val = null;
                //如果主键自增
                if (_KeyInfo.IsIdentity)
                {
                    if (this._Analysis._DbContextType == DbContextType.Oracle)
                        _Val = "MY_SEQ.NEXTVAL";//MY_SEQ.NEXTVAL
                    else if (this._Analysis._DbContextType == DbContextType.PostgreSQL)
                        LastInsertId = LastInsertId.Replace("#ID#", _KeyInfo.Name);
                    else
                        _IsContinue = true;
                }
                else
                {
                    _KeyId = this.CheckKey(_KeyInfo, _Val);
                    _Val = _KeyId;
                }

                if (!_IsContinue)
                {
                    var _Count = Sql.Parameter.Count;
                    _Cols.Add(_KeyInfo.Name);
                    _Values.Add("@" + _KeyInfo.Name + "_" + _Count);
                    Sql.Parameter.Add(new DbParam()
                    {
                        ParameterName = "@" + _KeyInfo.Name + "_" + _Count,
                        Value = _Val
                    });
                }
            }

            this.Sql.Code.Append($"INSERT INTO {TableName} ({string.Join(",", _Cols)}) VALUES ({ string.Join(",", _Values)}) {LastInsertId} ;");

            Id = _KeyId;

            return this.Sql;
        }

        private object CheckKey(FieldDescribe _FieldDescribe, object Value)
        {
            var _Identity = _FieldDescribe.IsIdentity;
            var _FieldType = _FieldDescribe.Type;

            if ((_FieldType == typeof(Guid) || _FieldType == typeof(Guid?)))
            {
                if (Value == null || Guid.Parse(Value.ToString()) == Guid.Empty)
                    return Guid.NewGuid();

                return Value;
            }
            return Value;
        }

    }
}
