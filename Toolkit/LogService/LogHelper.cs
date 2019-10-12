using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolkit.LogService
{
    using NLog;

    /// <summary>
    /// 参考地址：  
    ///             https://www.cnblogs.com/muyeh/p/9788311.html 
    ///             https://www.cnblogs.com/qulianqing/p/7222177.html
    /// </summary>
    public class LogHelper
    {
        public static Logger _Logger { get; set; }

        public static void Set(Logger logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="Text"></param>
        public void Write(string Text)
        {
            _Logger.Info(Text);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="_Exception"></param>
        public void Write(string Text, Exception _Exception)
        {
            if (_Logger.IsErrorEnabled)
            {
                _Logger.Error(_Exception, Text);
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="_Exception"></param>
        /// <param name="UserHostAddress"></param>
        /// <param name="CallBack"></param>
        public void Write(Exception _Exception, string UserHostAddress, Action<StringBuilder> CallBack = null)
        {
            var sb = new StringBuilder();
            var _Message = "异常信息: " + _Exception.Message;
            var _Source = "错误源:" + _Exception.Source;
            var _StackTrace = "堆栈信息:" + _Exception.StackTrace;

            sb.Append("\r\n" + UserHostAddress + "\r\n" + _Message + "\r\n" + _Source + "\r\n" + _StackTrace + "\r\n");

            CallBack?.Invoke(sb);

            this.Write(sb.ToString(), _Exception);
        }

    }
}
