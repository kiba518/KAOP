using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;

namespace KAOP
{
    [AttributeUsage(AttributeTargets.Class)]
    public class KibaAttribute : ContextAttribute
    {
        public KibaAttribute()
            : base("Kiba")
        {
        }

        /// <summary>
        /// IConstructionCallMessage
        /// 当用户创建新的客户端激活对象的实例通过调用new或Activator.CreateInstance和线程返回到用户代码之前IConstructionCallMessage发送到远程应用程序。
        /// 构造消息到达远程应用程序，通过远程处理激活器处理 (一个，或一个中指定的默认Activator属性)，并创建一个新的对象。
        /// 然后，远程处理应用程序返回IConstructionReturnMessage到本地应用程序。
        /// IConstructionReturnMessage包含的一个实例ObjRef，哪些程序包的远程对象有关的信息。 
        /// 远程处理基础结构将转换ObjRef到返回到用户代码的远程对象的代理的实例。
        /// </summary> 
        public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
        {
            ctorMsg.ContextProperties.Add(new KibaContextProperty()); 
        }
    }
}
