
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.Abstract.Query
{
    //
    using System.Linq.Expressions;
    using DbFrame.BaseClass;
    using DbFrame.Core.Interface.Query;

    //
    public abstract class AbstractJoin<T1, T2> : AbstractBase, IJoin<T1, T2>
    {

        public abstract IJoin<T1, T2, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2> Where(Expression<Func<HzyTuple<T1, T2>, bool>> Where);

        public abstract IJoin<T1, T2> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2>, bool>> Where);

        public abstract IJoin<T1, T2> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2> Having(Expression<Func<HzyTuple<T1, T2>, bool>> Where);

        public abstract IJoin<T1, T2> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3> : AbstractBase, IJoin<T1, T2, T3>
    {

        public abstract IJoin<T1, T2, T3, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3> Where(Expression<Func<HzyTuple<T1, T2, T3>, bool>> Where);

        public abstract IJoin<T1, T2, T3> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3>, bool>> Where);

        public abstract IJoin<T1, T2, T3> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3> Having(Expression<Func<HzyTuple<T1, T2, T3>, bool>> Where);

        public abstract IJoin<T1, T2, T3> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4> : AbstractBase, IJoin<T1, T2, T3, T4>
    {

        public abstract IJoin<T1, T2, T3, T4, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4> Where(Expression<Func<HzyTuple<T1, T2, T3, T4>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4> Having(Expression<Func<HzyTuple<T1, T2, T3, T4>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5> : AbstractBase, IJoin<T1, T2, T3, T4, T5>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);

        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> SqlString(Action<SQL> _Action);
    }
    public abstract class AbstractJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : AbstractBase, IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {



        public abstract IMappingData<TReturn> Select<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TReturn>> Select);

        public abstract IMappingData<TReturn> Select<TReturn>(string Select = "*");

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Where(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> WhereIF(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> OrderBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> OrderByIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> OrderByDesc<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> OrderByDescIF<TReturn>(bool IF, Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TReturn>> OrderBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Having(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, bool>> Where);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> GroupBy<TReturn>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, TReturn>> GroupBy);

        public abstract IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> SqlString(Action<SQL> _Action);
    }



}

