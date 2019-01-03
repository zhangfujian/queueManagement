using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZhangLogSysV1d0;

namespace QueueHelperV1d0.Service
{
    class HotchPotchV1d0
    {
        /// <summary>
        /// 将数据类保存为xml文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="printtTempletInfoSet"></param>
        /// <param name="fileName"></param>
        public static void SaveToXmFile<T>(T printtTempletInfoSet, string fileName)
        {
            try
            {
                XmlSerializer xSerializer = new XmlSerializer(typeof(T));
                StreamWriter sW = new StreamWriter(fileName);
                try
                {
                    xSerializer.Serialize(sW, printtTempletInfoSet);
                }
                finally
                {
                    sW.Close();
                }
            }
            catch (Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }
        }
        /// <summary>
        /// 读取xml文件,生成对应的数据类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T ReadFromXmlFile<T>(string fileName)
        {
            T result = default(T);
            try
            {
                if (File.Exists(fileName))
                {
                    StreamReader sR = new StreamReader(fileName);
                    XmlSerializer xSerializer = new XmlSerializer(typeof(T));
                    result = (T)xSerializer.Deserialize(sR);
                    sR.Close();
                }
            }
            catch (Exception ex)
            {
                SimpleLoger.Instance.Error(ex);
            }
            return result;
        }
    }
}
