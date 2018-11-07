using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging; 
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace KAOP
{
    /// <summary>
    /// 切面
    /// </summary>
    public class KAspec
    { 
        #region 处理
        /// <summary>
        /// 前处理
        /// </summary> 
        public void PreExcute(string MethodName, object[] InParams)
        {

            Logger.Info("==================== " + MethodName + ":" + " Start====================");
            Logger.Info(string.Format("参数数量：{0}", InParams.Count()));

            for (int i = 0; i < InParams.Count(); i++)
            {
                Logger.Info(string.Format("参数序号[{0}] ============    参数类型：{1}    执行类：{1}", i + 1, InParams[i])); 
                Logger.Info("传入参数：");
                string paramXMLstr = XMLSerializerToString(InParams[i], Encoding.UTF8);
                Logger.Info(paramXMLstr);
            }
        }

        /// <summary>
        /// 后处理
        /// </summary> 
        public void EndExcute(string MethodName, object[] OutParams, object ReturnValue, Exception ex)
        {
            Logger.Info(string.Format("返回值类型：{0}", ReturnValue));
            Logger.Info("返回值：");
            string resXMLstr = DataContractSerializerToString(ReturnValue, Encoding.UTF8); 
            Logger.Info(resXMLstr);

            if (OutParams.Count() > 0)//out 返回参数
            {
                Logger.Info(string.Format("out返回参数数量：{0}", OutParams.Count())); 
                for (int i = 0; i < OutParams.Count(); i++)
                {
                    Logger.Info(string.Format("参数序号[{0}] == 参数值：{1}", i + 1, OutParams[i]));
                }
            }

            if (ex != null)
            {
                Logger.Error(ex);
            }
            Logger.Info("==================== " + MethodName + ":" + " End====================");
        }
        #endregion

        public string XMLSerializerToString(object obj, Encoding encoding)
        {
            try
            {
                if (obj != null)
                {
                    XmlSerializer ser = new XmlSerializer(obj.GetType());
                    MemoryStream mem = new MemoryStream();
                    ser.Serialize(mem, obj);
                    string resXMLstr = encoding.GetString(mem.ToArray());
                    return resXMLstr;
                }
                else
                {
                    return "序列化对象为空";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return "序列化异常";
            }
        }
        public static string DataContractSerializerToString(object obj, Encoding encoding)
        {
            try
            {
                if (obj != null)
                {
                    DataContractSerializer ser = new DataContractSerializer(obj.GetType());
                    MemoryStream mem = new MemoryStream();
                    ser.WriteObject(mem, obj);
                    string resXMLstr = encoding.GetString(mem.ToArray());
                    return resXMLstr;
                }
                else
                {
                    return "序列化对象为空";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return "序列化异常";
            }
        }
    }
}
