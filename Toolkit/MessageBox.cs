using System;

namespace Toolkit
{
    /// <summary>
    /// MVC 异常拦截 该对象 返回客户端
    /// </summary>
    [Serializable]
    public class MessageBox : Exception
    {
        /// <summary>
        /// 异常模型
        /// </summary>
        public MessageBoxModel Model { set; get; }

        /// <summary>
        /// 成功消息
        /// </summary>
        public MessageBox()
            : base("操作成功!")
        {
            this.Model = new MessageBoxModel(this.Message, EMessageBoxStatus.成功);
        }

        /// <summary>
        /// 失败并返回 消息 | 客户端接收对象 例如: {status=1,data="这是消息!"}
        /// </summary>
        /// <param name="Messager"></param>
        public MessageBox(string Message)
            : base(Message)
        {
            this.Model = new MessageBoxModel(Message, EMessageBoxStatus.失败);
        }

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="Data">客户端接收对象 例如: {status=1,data="这是消息!"}</param>
        public MessageBox(object Message)
            : base($"自定义异常 请忽略!{EMessageBoxStatus.自定义.ToString()}")
        {
            this.Model = new MessageBoxModel(Message, EMessageBoxStatus.自定义);
        }

    }

    public class MessageBoxModel
    {
        /// <summary>
        /// 自定义
        /// </summary>
        /// <param name="data">数据对象 例如:{status=500,action="6666"}</param>
        /// <param name="msgStatus"></param>
        public MessageBoxModel(object Data, EMessageBoxStatus _EMessageBoxStatus)
        {
            this.status = (int)_EMessageBoxStatus;
            this.msg = Data;
        }

        /// <summary>
        /// 错误状态码
        /// </summary>
        public int status { set; get; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public object msg { set; get; }

    }

    /// <summary>
    /// 消息状态
    /// </summary>
    public enum EMessageBoxStatus
    {
        接口授权码无效 = -3,
        服务端异常 = -2,
        自定义 = -1,
        失败 = 0,
        成功 = 1,
    }


}
