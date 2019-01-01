using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangLogSysV1d0
{
    public class SimpleLoger 
    {
        /// <summary>
        /// Single Instance
        /// </summary>
        private static SimpleLoger instance;
        public static SimpleLoger Instance
        {
            get
            {
                if (instance == null)
                    instance = new SimpleLoger();
                return instance;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private SimpleLoger()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new LogerTraceListener());
        }

        public void Debug(object msg)
        {
            Trace.WriteLine(msg, "Debug");
        }

        public void Warn(object msg)
        {
            Trace.WriteLine(msg, "Warn");
        }

        public void Info(object msg)
        {
            Trace.WriteLine(msg, "Info");
        }

        public void Error(object msg)
        {
            Trace.WriteLine(msg, "Error");
        }
        public void PrintRecord(object msg)
        {
            Trace.WriteLine(msg.ToString());
        }
    }
    public class LogerTraceListener : TraceListener
    {
        /// <summary>
        /// FileName
        /// </summary>
        private string m_fileName;
        /// <summary>
        /// 操作信息日志文件名
        /// </summary>
        private string m_PrintRecordFileName;

        /// <summary>
        /// Constructor
        /// </summary>
        public LogerTraceListener()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
            this.m_fileName = basePath +
                string.Format("Log-{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
            this.m_PrintRecordFileName = basePath +
                string.Format("PrintErrorLog-{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
        }

        /// <summary>
        /// Write
        /// </summary>
        public override void Write(string message)
        {
            message = Format(message, "");
            File.AppendAllText(m_fileName, message);
        }

        /// <summary>
        /// Write
        /// </summary>
        public override void Write(object obj)
        {
            string message = Format(obj, "");
            File.AppendAllText(m_fileName, message);
        }

        /// <summary>
        /// WriteLine
        /// </summary>
        public override void WriteLine(object obj)
        {
            string message = Format(obj, "");
            File.AppendAllText(m_fileName, message);
        }

        /// <summary>
        /// WriteLine 用于写打印记录日志
        /// </summary>
        public override void WriteLine(string message)
        {
            message = Format(message, "");
            //File.AppendAllText(m_fileName, message);
            File.AppendAllText(m_PrintRecordFileName, message);
        }

        /// <summary>
        /// WriteLine
        /// </summary>
        public override void WriteLine(object obj, string category)
        {
            string message = Format(obj, category);
            File.AppendAllText(m_fileName, message);
        }

        /// <summary>
        /// WriteLine
        /// </summary>
        public override void WriteLine(string message, string category)
        {
            message = Format(message, category);
            File.AppendAllText(m_fileName, message);
        }

        /// <summary>
        /// Format
        /// </summary>
        private string Format(object obj, string category)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (!string.IsNullOrEmpty(category))
                builder.AppendFormat("[{0}] ", category);
            if (obj is Exception)
            {
                var ex = (Exception)obj;
                builder.Append(ex.Message + "\r\n");
                builder.Append(ex.StackTrace + "\r\n");
            }
            else
            {
                builder.Append(obj.ToString() + "\r\n");
            }

            return builder.ToString();
        }
    }
}
