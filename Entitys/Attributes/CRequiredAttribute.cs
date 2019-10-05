namespace Entitys.Attributes
{
    /// <summary>
    /// 非空验证 标记  如果你要使用 DisplayName 请在 ErrorMessage 的文本中加上 {name} 这样的标记即可
    /// </summary>
    public class CRequiredAttribute : BaseAttribute
    {
        public CRequiredAttribute()
        {
        }

    }
}
