namespace Entitys.Attributes
{
    /// <summary>
    /// 不能重复 标记
    /// </summary>
    public class CRepeatAttribute : BaseAttribute
    {
        /// <summary>
        /// 要追加的 Where 条件 例如： and 1=1  and filed1='{filed1}'
        /// </summary>
        public string Where { get; set; }
        public CRepeatAttribute()
        {

        }


    }
}
