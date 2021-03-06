﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace MacroLib.Jobs
{
    public class JobSpooler : IDisposable
    {
        Thread thread;
        List<Job> queues = new List<Job>();
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
                queues.Add(job);
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
                if (0 < queues.Count)
                {
                    //時間割込み
                    //順当な実行
                    var result = queues[0];
                    queues.RemoveAt(0);
                    return result;
                }
                return null;
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
