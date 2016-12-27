using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket_Demo
{
    public class LIST : CommandBase<MySession, StringRequestInfo>
    {
        /// <summary>  
        /// 获取客户端列表  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="requestInfo"></param>  
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            var tmp = "";
            //判断clentList中是否有值  
            if (MySessionManager.SessionList.Count < 1)
            {
                tmp = "NoBody.";
            }
            else
            {
                for (int i = 0; i < MySessionManager.SessionList.Count; i++)
                {
                    //SessionID为Session的唯一标示  
                    tmp += "Id:" + (i + 1) + ",SessionID:" + MySessionManager.SessionList[i].SessionID;
                }
            }
            session.Send(tmp);
        }
    }
}
