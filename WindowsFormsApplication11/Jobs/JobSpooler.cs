using System;
using System.Collections.Generic;
using System.Threading;

namespace MacroLib.Jobs
{
    public class JobSpooler : IDisposable
    {
        Thread thread;
        Queue<Job> queues = new Queue<Job>();
        bool isPower;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        public JobSpooler()
        {
            thread = new Thread(ThreadMain);
            thread.Start();
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="job"></param>
        public void Add(Job job)
        {
            lock (queues)
            {
                queues.Enqueue(job);
            }
        }

        /// <summary>
        /// 取得
        /// </summary>
        /// <returns></returns>
        Job Get()
        {
            lock (queues)
            {
                return (0 < queues.Count) ? queues.Dequeue() : null;
            }
        }

        /// <summary>
        /// クリア
        /// </summary>
        public void Clear()
        {
            lock (queues)
            {
                queues.Clear();
            }
        }

        /// <summary>
        /// 開放
        /// </summary>
        public void Dispose()
        {
            isPower = false;
        }

        /// <summary>
        /// スレッドメイン
        /// </summary>
        void ThreadMain()
        {
            for (isPower = true; isPower; Thread.Sleep(10))
            {
                Get()?.Execute();
            }
        }
    }
}
