using System;
using System.IO;

namespace WSPInstaller
{
    class LogWriter
    {
        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "WSP";
            Console.WriteLine(logFilePath);
            logFilePath = logFilePath + "\\" + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") + ":" + " " + strLog);
            log.Close();
        }
    }
}
