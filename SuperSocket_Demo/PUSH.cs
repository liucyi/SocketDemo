using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket_Demo
{
    /// <summary>  
    /// 向客户端推送信息  
    /// </summary>  
    public class PUSH : CommandBase<MySession, StringRequestInfo>
    {
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            /*  
             * 内置命令行协议： 
             *      命令行协议定义了每个请求必须以回车换行结尾 "\r\n"。 
             *      用空格来分割请求的Key和参数 
             *      requestInfo.Body 参数 
             *      requestInfo.Parameters 用空格分隔参数，返回数组 
             */
            foreach (MySession tmp in MySessionManager.SessionList)
            {
                tmp.Send(requestInfo.Body);
            }
        }
    }
}
