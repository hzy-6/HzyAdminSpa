using System;
namespace Entitys.Attributes
{
    /// <summary>
    /// 范围验证
    /// </summary>
    public class CRangeAttribute : BaseAttribute
    {
        /// <summary>
        /// 最小值
        /// </summary>
        public object MinLength { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public object MaxLength { get; set; }
        /// <summary>
        /// 验证数据类型
        /// </summary>
        public Type type { get; set; }
        public CRangeAttribute(int minLength, int maxLength)
        {
            this.MinLength = minLength;
            this.MaxLength = MaxLength;
        }

    }




}
