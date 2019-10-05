using System;

namespace DbFrame.BaseClass
{
    /// <summary>
    ///  DbFrameException 自定义异常
    /// </summary>
    public class DbFrameException : Exception
    {

        public DbFrameException(string Message)
            : base(Message)
        {

        }

        public DbFrameException(string Message, Exception InnerException)
            : base(Message, InnerException)
        {

        }




    }
}
