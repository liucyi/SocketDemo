using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket_Demo
{
    /// <summary>  
    /// 自定义连接类MySession，继承AppSession，并传入到AppSession  
    /// </summary>  
    public class MySession : AppSession<MySession>
    {
        public bool isLogin { get; set; }
        /// <summary>  
        /// 新连接  
        /// </summary>  
        protected override void OnSessionStarted()
        {
            MySessionManager.SessionList.Add(this);
            Console.WriteLine(this.LocalEndPoint.Address.ToString());
            this.Send("\n\r你好 User");
        }

        /// <summary>  
        /// 未知的Command  
        /// </summary>  
        /// <param name="requestInfo"></param>  
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("\n\rerror");
        }

        /// <summary>  
        /// 捕捉异常并输出  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void HandleException(Exception e)
        {
            this.Send("\n\r异常: {0}", e.Message);
        }

        /// <summary>  
        /// 连接关闭  
        /// </summary>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(CloseReason reason)
        {
            MySessionManager.SessionList.Remove(this);
            base.OnSessionClosed(reason);
        }
    }
}
