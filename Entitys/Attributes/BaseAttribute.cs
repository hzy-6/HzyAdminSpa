using System;
namespace Entitys.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class BaseAttribute : Attribute
    {
        public BaseAttribute() { }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

    }
}
