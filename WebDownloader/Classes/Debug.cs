using System;
using System.IO;

namespace MyDebug
{
    class Debug
    {
        #region 常用输入输出函数

        //--------------------------------------------------------------------------------------
        //                                      常用输入输出函数
        //--------------------------------------------------------------------------------------
        static bool EnableDebug = true;

        static StreamWriter swTotalLog;
        static StreamWriter swWarningLog;
        static StreamWriter swErrorLog;

        static bool CONSOLE_LogToFile = false;       //是否打开输出日志文件功能
        static bool CONSOLE_PRINT_WARNING = true;  //是否向运行时的控制台输出警告

        static Action<string> g_cbLogString = null;

        public static string GetCurrentDirectory()
        {
            return Environment.CurrentDirectory + "\\";
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public static int ReadInt()
        {
            string str = System.Console.ReadLine();
            int num;
            int.TryParse(str, out num);
            return num;
        }

        /// <summary>
        /// 向日志写入的消息类型
        /// </summary>
        public enum LogType
        {
            /// <summary>
            /// 无需写入日志文件的消息
            /// </summary>
            NoLog,

            Info,
            Error,
            Warning,
        };

        /// <summary>
        /// 设置log时的回调
        /// </summary>
        public static void SetCallbackLogStr(Action<string> logAction)
        {
            g_cbLogString = logAction;
        }

        /// <summary>
        /// 向控制台输出消息
        /// </summary>
        public static void Log(string str)
        {
            PrintLine(str);
        }

        /// <summary>
        /// 向用户端回调输出：
        /// </summary>
        /// <param name="str"></param>
        public static void LogToUser(string str)
        {

            if (g_cbLogString != null)
                g_cbLogString(str);
        }

        /// <summary>
        /// 输出消息，可选择是否写入日志文件
        /// </summary>
        public static void PrintLine(string str = null, LogType msgType = LogType.NoLog, bool appendMsgType = true)
        {
            if (EnableDebug == false)
                return;

            if (msgType != LogType.NoLog
                && CONSOLE_LogToFile)
            {
                InitLogFile();

                if (appendMsgType)
                    str = "\t[" + msgType + "] " + str;
                else
                    str = "\t" + str;

                swTotalLog.WriteLine(str);

                if (msgType == LogType.Warning)
                    swWarningLog.WriteLine(str);
                else if (msgType == LogType.Error)
                    swErrorLog.WriteLine(str);
            }

            //可屏蔽输出warnning信息
            if (msgType != LogType.Warning || CONSOLE_PRINT_WARNING)
                System.Console.WriteLine(str);

        }


        public static void Print(string str = null, LogType msgType = LogType.NoLog, bool appendMsgType = true)
        {
            if (EnableDebug == false)
                return;

            //可屏蔽输出warning
            if (msgType != LogType.Warning || CONSOLE_PRINT_WARNING)
                System.Console.Write(str);


            if (msgType != LogType.NoLog
                && CONSOLE_LogToFile)
            {
                InitLogFile();

                if (appendMsgType)
                    str = "\t[" + msgType + "] " + str;
                else
                    str = "\t" + str;

                swTotalLog.Write(str);

                if (msgType == LogType.Warning)
                    swWarningLog.Write(str);
                else if (msgType == LogType.Error)
                    swErrorLog.Write(str);
            }
        }

        private static void InitLogFile()
        {
            if (swTotalLog == null)
            {
                //append:
                swTotalLog = new StreamWriter(GetCurrentDirectory() + "log.txt",
                                                true, System.Text.Encoding.Unicode);
                swTotalLog.WriteLine("#Log at " + DateTime.Now);
            }

            if (swErrorLog == null)
            {
                swErrorLog = new StreamWriter(GetCurrentDirectory() + "logError.txt",
                                                true, System.Text.Encoding.Unicode);

                swErrorLog.WriteLine("#Log at " + DateTime.Now);
            }

            if (swWarningLog == null)
            {
                swWarningLog = new StreamWriter(GetCurrentDirectory() + "logWarning.txt",
                                                true, System.Text.Encoding.Unicode);
                swWarningLog.WriteLine("#Log at " + DateTime.Now);
            }
        }

        /// <summary>
        /// 关闭日志文件，否则写入的日志不可见。
        /// </summary>
        public static void CloseLogFile()
        {
            if (swTotalLog != null)
            {
                swTotalLog.WriteLine();

                swTotalLog.Flush();
                swTotalLog.Dispose();
                swTotalLog.Close();
            }

            if (swErrorLog != null)
            {
                swErrorLog.WriteLine();

                swErrorLog.Flush();
                swErrorLog.Dispose();
                swErrorLog.Close();
            }

            if (swWarningLog != null)
            {
                swWarningLog.WriteLine();

                swWarningLog.Flush();
                swWarningLog.Dispose();
                swWarningLog.Close();
            }
        }

        public static int ReadChar()
        {
            return System.Console.Read();
        }

        public static void ClearScreen()
        {
            System.Console.Clear();
        }

        public static void Pause()
        {
            PrintLine("Press ENTER to continue");
            ReadLine();
        }

        /// <summary>
        /// 暂停线程，毫秒为单位
        /// </summary>
        public static void PauseThread(int milSecs)
        {
            System.Threading.Thread.Sleep(milSecs);
        }

        #endregion
    }
}
