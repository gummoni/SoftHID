﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication11
{
    /// <summary>
    /// ログ読込み
    /// </summary>
    public class LogReader : IDisposable
    {
        FileStream fileStream;
        StreamReader streamReader;
        Task task;
        bool isPower = true;

        public event EventHandler<string> ReadLineRecieved;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="encoding"></param>
        public LogReader(string filename, Encoding encoding)
        {
            fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fileStream.Seek(0, SeekOrigin.End);
            streamReader = new StreamReader(fileStream, encoding);
            task = Task.Run((Action)TaskMain);
        }

        /// <summary>
        /// タスクメイン
        /// </summary>
        void TaskMain()
        {
            while (isPower)
            {
                while (!streamReader.EndOfStream && isPower)
                {
                    var line = streamReader.ReadLine();
                    ReadLineRecieved?.Invoke(this, line);
                }
                Task.Delay(100).Wait();
            }
        }

        /// <summary>
        /// 開放処理
        /// </summary>
        public void Dispose()
        {
            isPower = false;
            task.Wait();
            streamReader.Dispose();
            fileStream.Dispose();
        }
    }
}