namespace Entitys.Attributes
{
    /// <summary>
    /// 验证字符串长度
    /// </summary>
    public class CStringLengthAttribute : BaseAttribute
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public CStringLengthAttribute(int minLength)
        {
            this.MinLength = minLength;
        }

    }
}
