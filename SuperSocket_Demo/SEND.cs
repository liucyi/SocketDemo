using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket_Demo
{
    [MyCommandFilterAttribute]
    /// <summary>  
    /// 向客户端推送信息  
    /// </summary>  
    public class SEND : CommandBase<MySession, StringRequestInfo>
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
            //通过参数的个数判断命令类型  
            if (requestInfo.Parameters.Length < 2)
            {
                session.Send("命令格式：send id 信息");
                //send 信息  
                //for (int i = 0; i < Client.clientList.Count; i++)  
                //{  
                //    //取SessionId对应的Session并发送信息  
                //    Client.TestServer.GetAppSessionByID(Client.clientList[i]).Send(requestInfo.Body);  
                //}  
            }
            else
            {
                //send id 信息  
                //判断id是否合法  
                if (int.Parse(requestInfo.Parameters[0]) < 1 || int.Parse(requestInfo.Parameters[0]) > MySessionManager.SessionList.Count)
                {
                    session.Send("id错误。");
                }
                else
                {
                    int i = int.Parse(requestInfo.Parameters[0]);
                    //取Session并发送信息  
                    MySessionManager.SessionList[i - 1].Send(requestInfo.Parameters[1]);
                }
            }
        }
    }
}
