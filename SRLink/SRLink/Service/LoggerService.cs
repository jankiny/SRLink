﻿using System;
using System.IO;

// 引用了Forms; Application需要

namespace SRLink.Service
{
    public class LoggerService
    {
        private static readonly string LogDirectory = Path.Combine(Global.StartupPath, "Logs");
        public static void SaveLog(string strContent)
        {
            try
            {
                var path = Path.Combine(LogDirectory, DateTime.Now.ToString("yyyyMM") + ".txt");
                //string path = Path.Combine(Environment.CurrentDirectory, "Logs");
                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }
                if (!File.Exists(path))
                {
                    FileStream FsCreate = new FileStream(path, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                using (StreamWriter sWrite = new StreamWriter(fileStream))
                {
                    sWrite.WriteLine(
                        $"{"----------------------"}{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{"----------------------"}");
                    sWrite.Write(strContent);
                    sWrite.WriteLine(Environment.NewLine);
                    sWrite.Flush();
                    sWrite.Close();
                }
            }
            catch { }
        }
        public static void SaveLog(string strTitle, Exception exc)
        {
            try
            {
                //string path = Path.Combine(Environment.CurrentDirectory, "Logs");
                string path = Path.Combine(LogDirectory, DateTime.Now.ToString("@yyyyMMdd-Exception") + ".txt");
                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }
                if (!File.Exists(path))
                {
                    FileStream FsCreate = new FileStream(path, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                using (StreamWriter sWrite = new StreamWriter(fileStream))
                {
                    string strContent = exc.ToString();

                    sWrite.WriteLine(string.Format("{0}{1}[{2}]{3}", "----------------------", strTitle, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "----------------------"));
                    sWrite.Write(strContent);
                    sWrite.WriteLine(Environment.NewLine);
                    sWrite.WriteLine(" ");
                    sWrite.Flush();
                    sWrite.Close();
                }
            }
            catch { }
        }
    }
}