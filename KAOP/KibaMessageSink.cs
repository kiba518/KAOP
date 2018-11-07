using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace KAOP
{
    /// <summary>
    /// 定义消息接收器。
    /// </summary>
    public class KibaMessageSink : IMessageSink
    {
        private KAspec kaspec = new KAspec(); 
        private IMessageSink nextSink; 
        public KibaMessageSink(IMessageSink next)
        {
            nextSink = next;
        } 
        public IMessageSink NextSink
        {
            get
            {
                return nextSink;
            }
        } 
        public IMessage SyncProcessMessage(IMessage msg)
        { 
            IMethodCallMessage call = msg as IMethodCallMessage;
            if (call != null)
            {
                //拦截消息，做前处理
                kaspec.PreExcute(call.MethodName, call.InArgs);
            }
            //传递消息给下一个接收器 
            IMessage retMsg = nextSink.SyncProcessMessage(msg);   
            IMethodReturnMessage dispose = retMsg as IMethodReturnMessage;
            if (dispose != null)
            { 
                //调用返回时进行拦截，并进行后处理
                kaspec.EndExcute(dispose.MethodName, dispose.OutArgs, dispose.ReturnValue, dispose.Exception);
            } 
            return retMsg;
        } 
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

      
    }
     
}
