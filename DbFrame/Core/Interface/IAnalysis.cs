using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFrame.Core.Interface
{
    using DbFrame.BaseClass;
    using System.Linq.Expressions;

    public interface IAnalysis
    {
        /// <summary>
        /// 获取 Count 
        /// </summary>
        int Count(SQL _Sql);

        /// <summary>
        /// Max
        /// </summary>
        T Max<T>(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// Min
        /// </summary>
        T Min<T>(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// Sum
        /// </summary>
        T Sum<T>(LambdaExpression _LambdaExpression, SQL _Sql);






        /*****************Create*********************/


        /// <summary>
        /// 创建 Query 对象
        /// </summary>
        void CreateQuery<T>(SQL _Sql);

        /// <summary>
        /// 创建 GroupBy 对象
        /// </summary>
        void CreateGroupBy(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// 创建 Having 对象
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        /// <param name="_Sql"></param>
        void CreateHaving(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// 创建 OrderBy 对象
        /// </summary>
        void CreateOrderBy(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// 创建 OrderBy  desc 对象
        /// </summary>
        void CreateOrderByDESC(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// 创建 Select 对象
        /// </summary>
        void CreateSelect(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// 创建 Where 对象
        /// </summary>
        void CreateWhere(LambdaExpression _LambdaExpression, SQL _Sql);

        /// <summary>
        /// 创建 Join 对象
        /// </summary>
        void CreateJoin(LambdaExpression _LambdaExpression, SQL _Sql, EJoinType _EJoinType);

        /// <summary>
        /// 创建 TOP 对象
        /// </summary>
        void CreateTop(int Top, SQL _Sql);

        /// <summary>
        /// 创建 Distinct 对象
        /// </summary>
        void CreateDistinct(SQL _Sql);

        /// <summary>
        /// 创建 分页 对象
        /// </summary>
        void CreateTakePage(SQL _Sql, int PageNumber, int PageSize);



    }
}
