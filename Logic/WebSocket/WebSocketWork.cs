using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebSocket
{

    using HzySocket.WebSocket;
    using HzySocket.WebSocket.Class;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Entitys.SysClass;
    using System.Threading.Tasks;
    using System.Linq;

    public class WebSocketWork : SocketService<WebSocketMsgModel>
    {

        public WebSocketWork(RequestDelegate _Next) : base(_Next) { }

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
            WebSocketMsgModel msg = JsonConvert.DeserializeObject<WebSocketMsgModel>(Content);

            if (msg.Action == WebSocketActionEnum.Register)
            {
                //appSession.UserID = msg.Account.UserID.ToString();
                //appSession.Account = msg.Account;

                await appSession.SendAsync(JsonConvert.SerializeObject(new { status = 1, msg = "WebSocket注册成功!" }));
            }
        }

        /// <summary>
        /// 根据条件筛选 Session 对象
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<WebSocketMsgModel> GetAppSessions(Func<WebSocketMsgModel, bool> predicate)
        {
            return WebSocketSend<WebSocketMsgModel>.AppSessions.Where(predicate);
        }

        /// <summary>
        /// 获取 所有 session 对象
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<WebSocketMsgModel> GetAllAppSessions()
        {
            return WebSocketSend<WebSocketMsgModel>.AppSessions;
        }

        /// <summary>
        /// 插入Session 对象
        /// </summary>
        /// <param name="appSession"></param>
        public static void AddAppSession(WebSocketMsgModel appSession)
        {
            WebSocketSend<WebSocketMsgModel>.AppSessions.Enqueue(appSession);
        }

        /// <summary>
        /// 移除Session 对象
        /// </summary>
        /// <param name="predicate"></param>
        public static void RemoveSession(Func<WebSocketMsgModel, bool> predicate)
        {
            var _AppSessions = GetAppSessions(predicate);
            if (_AppSessions == null) return;

            foreach (var item in _AppSessions)
            {
                var _AppSession = item;
                WebSocketSend<WebSocketMsgModel>.AppSessions.TryDequeue(out _AppSession);
            }
        }

        /// <summary>
        /// 获取 session 连接数
        /// </summary>
        /// <returns></returns>
        public static int GetAppSessionCount()
        {
            return WebSocketSend<WebSocketMsgModel>.AppSessions.Count;
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
        SendToUser,
        Notice
    }


}
