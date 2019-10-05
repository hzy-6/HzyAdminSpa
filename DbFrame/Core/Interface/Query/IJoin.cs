using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Interface.Query
{
    //
    using DbFrame.BaseClass;
    using System.Linq.Expressions;

    //
    public interface IJoin<T1, T2> : IBase<T1, T2>
    {
        IJoin<T1, T2, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3> : IBase<T1, T2, T3>
    {
        IJoin<T1, T2, T3, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4> : IBase<T1, T2, T3, T4>
    {
        IJoin<T1, T2, T3, T4, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5> : IBase<T1, T2, T3, T4, T5>
    {
        IJoin<T1, T2, T3, T4, T5, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6> : IBase<T1, T2, T3, T4, T5, T6>
    {
        IJoin<T1, T2, T3, T4, T5, T6, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7> : IBase<T1, T2, T3, T4, T5, T6, T7>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8> : IBase<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TJoin> Join<TJoin>(Expression<Func<HzyTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TJoin>, bool>> ON, EJoinType _EJoinType = EJoinType.LEFT_JOIN);
    }
    public interface IJoin<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : IBase<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
    }





}

