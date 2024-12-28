using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace VocabManager
{
    public class Logger
    {
        private static Logger _instance;
        private static string _path;
        private FileInfo _file;

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger(Constants.PATH_LOG_FILE);
                return _instance;
            }
            return _instance;
        }

        private Logger(string path)
        {
            _path = path;
            _file = new FileInfo(_path);

            // If the log directory or file doesn't exist, create it
            Directory.CreateDirectory(Constants.PATH_LOG_DIR);
            if (!_file.Exists)
            {
                _file.Create();
            }
        }

        public void Write(string log)
        {
            try
            {
                FileStream fileStream = new FileStream(_path, FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(log);
                streamWriter.Close();
            }
            catch (Exception)
            {
            }
        }

        public String GetDateTime()
        {
            DateTime now = DateTime.Now;
            string dateTime = now.ToString("dd-MM-yyyy HH-mm-ss.ms");
            return dateTime;
        }

        public void Info(string log)
        {
            string fullLog = String.Format("[{0}] [{1}] [{2}] [INFO] {3}", GetDateTime(), Process.GetCurrentProcess().Id, Thread.CurrentThread.ManagedThreadId, log);
            Write(fullLog);
        }

        public void Error(string log)
        {
            string fullLog = String.Format("[{0}] [{1}] [{2}] [ERROR] {3}", GetDateTime(), Process.GetCurrentProcess().Id, Thread.CurrentThread.ManagedThreadId, log);
            Write(fullLog);
        }
    }
}