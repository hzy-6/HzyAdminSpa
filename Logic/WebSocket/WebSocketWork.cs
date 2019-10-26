using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.SysClass.WebSocket
{

    using HzySocket.WebSocket;
    using HzySocket.WebSocket.Class;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public class WebSocketWork : SocketService<WebSocketMsgModel>
    {
        public WebSocketWork(RequestDelegate _Next) : base(_Next)
        {

            //监听非活跃用户 清除回调
            InactiveCloseCallBack = (_WebSocketMsgModel) =>
            {

            };
            //连接关闭回调事件
            ConnectCloseCallBack = (_WebSocketMsgModel) =>
            {

            };

            //发送异常
            SendExceptionCall = (ex) =>
            {

            };
        }

        public static void Register(IApplicationBuilder _IApplicationBuilder)
        {
            //webScoket
            _IApplicationBuilder.UseWebSockets(new WebSocketOptions()
            {
                ReceiveBufferSize = 1024 * 10,
                KeepAliveInterval = TimeSpan.FromSeconds(60 * 60 * 2)//2小时
            });
            _IApplicationBuilder.UseMiddleware<WebSocketWork>();
        }

        public override async Task ExecuteCommand(WebSocketMsgModel appSession, string Content)
        {
            try
            {
                WebSocketMsgModel msg = JsonConvert.DeserializeObject<WebSocketMsgModel>(Content);

                if (msg.Action == WebSocketActionEnum.Register)
                {
                    appSession.UserID = msg.UserID;

                    await appSession.SendAsync(new { status = 1, msg = $"{msg.UserID},恭喜您已经注册上线!" });
                }
                else if (msg.Action == WebSocketActionEnum.SendToUser)//给别人发消息
                {
                    if (msg.ToUserID == null)
                        await SendAllAsync(msg.Message);
                    else
                        await SendAsync(w => w.UserID == msg.ToUserID, msg.Message);
                }
            }
            catch (Exception ex)
            {
                //接收到 非 json 字符串
                await appSession.SendAsync(new { status = 1, msg = $"程序异常:{ex.Message}，接收到您的字符串:{Content} 请尽量使用 Json 字符串 与服务器交互!" });
            }
        }

        /// <summary>
        /// 根据条件筛选 Session 对象
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<WebSocketMsgModel> GetAppSessions(Func<WebSocketMsgModel, bool> predicate)
        {
            return WebSocketSend<WebSocketMsgModel>.GetAppSessions(predicate);
        }

        /// <summary>
        /// 获取 所有 session 对象
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<WebSocketMsgModel> GetAllAppSessions()
        {
            return WebSocketSend<WebSocketMsgModel>.GetAllAppSessions();
        }

        /// <summary>
        /// 插入Session 对象
        /// </summary>
        /// <param name="appSession"></param>
        public static void AddAppSession(WebSocketMsgModel appSession)
        {
            WebSocketSend<WebSocketMsgModel>.AddAppSession(appSession);
        }

        /// <summary>
        /// 移除Session 对象
        /// </summary>
        /// <param name="predicate"></param>
        public static void RemoveSession(Func<WebSocketMsgModel, bool> predicate)
        {
            WebSocketSend<WebSocketMsgModel>.RemoveSession(predicate);
        }

        /// <summary>
        /// 获取 session 连接数
        /// </summary>
        /// <returns></returns>
        public static int GetAppSessionCount()
        {
            return WebSocketSend<WebSocketMsgModel>.GetAppSessionCount();
        }

        /// <summary>
        /// 检查 session 是否存在
        /// </summary>
        /// <returns></returns>
        public static bool Any(Func<WebSocketMsgModel, bool> predicate)
        {
            return WebSocketSend<WebSocketMsgModel>.Any(predicate);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="Data"></param>
        public static async Task SendAsync<T>(Func<WebSocketMsgModel, bool> predicate, T Data)
        {
            await WebSocketSend<WebSocketMsgModel>.SendAsync(predicate, Data);
        }

        /// <summary>
        /// 所有连接用户发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Data"></param>
        public static async Task SendAllAsync<T>(T Data)
        {
            await WebSocketSend<WebSocketMsgModel>.SendAllAsync(Data);
        }

    }


    /// <summary>
    /// WebSocket 消息 模型
    /// </summary>
    public class WebSocketMsgModel : WebSocketAppSession
    {
        public string UserID { get; set; }

        public string ToUserID { get; set; }

        public WebSocketActionEnum Action { get; set; }

        public string Message { get; set; }

    }

    public enum WebSocketActionEnum
    {
        Register,
        SendToUser
    }


}
