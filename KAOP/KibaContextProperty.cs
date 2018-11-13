using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace KAOP
{
    public class KibaContextProperty : IContextProperty, IContributeObjectSink
    {
        public KibaContextProperty()
        {
        }
        /// <summary>
        /// 将所提供的服务器对象的消息接收器连接到给定的接收器链前面。
        /// </summary>
        /// <param name="obj">提供要连接到给定的接收器链前面的消息接收器的服务器对象。 </param>
        /// <param name="next">到目前为止组成的接收链。</param>
        /// <returns>复合接收器链。</returns>
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        { 
            return new KibaMessageSink(next);
        } 
        public bool IsNewContextOK(Context newCtx)
        {
            return true;
        }  
        public void Freeze(Context newCtx)
        {
        }  
        public string Name
        {
            get { return "Kiba"; }
        }
    }
}
