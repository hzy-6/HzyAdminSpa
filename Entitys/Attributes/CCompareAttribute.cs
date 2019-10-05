namespace Entitys.Attributes
{
    /// <summary>
    /// 比较两字段是否相等  如果你要使用 DisplayName 请在 ErrorMessage 的文本中加上 {name} 这样的标记即可
    /// </summary>
    public class CCompareAttribute : BaseAttribute
    {
        /// <summary>
        /// 要比较的属性
        /// </summary>
        public string OtherProperty { get; set; }
        public CCompareAttribute(string otherProperty)
        {
            this.OtherProperty = otherProperty;
        }
    }
}
