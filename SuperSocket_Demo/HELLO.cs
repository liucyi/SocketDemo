﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket_Demo
{
    /// <summary>  
    /// 自定义命令类HELLO，继承CommandBase，并传入自定义连接类MySession  
    /// </summary>  
    public class HELLO : CommandBase<MySession, StringRequestInfo>
    {
        /// <summary>  
        /// 自定义执行命令方法，注意传入的变量session类型为MySession  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="requestInfo"></param>  
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            session.Send("Hello World!");
        }
    }
}
