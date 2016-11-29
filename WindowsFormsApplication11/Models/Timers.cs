using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MacroLib.Models
{
    public class Timers : List<Timer>
    {
        object _lock = new object();
        public event EventHandler OnTimeOut;

        public void DoEvents()
        {
            lock (_lock)
            {
                for (var idx = Count - 1; 0 <= idx; idx--)
                {
                    var timer = this[idx];
                    if (timer.IsTimeout)
                    {
                        //スクリプト実行
                        OnTimeOut?.Invoke(timer, new TimeoutEventHandler(timer.DoScript));
                        RemoveAt(idx);
                    }
                }
            }
        }

        public void Add(string alarmName, string doScript, int timerCount)
        {
            lock (_lock)
            {
                Add(new Timer(alarmName, doScript, timerCount));
            }
        }
    }

    public class Timer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [DisplayName("タイマー名")]
        public string AlarmName { get; set; }

        [Browsable(false)]
        public string DoScript { get; set; }

        [Browsable(false)]
        public int TimerCount { get; set; }

        DateTime startTime;

        [Browsable(false)]
        public bool IsTimeout
        {
            get
            {
                var count = RestSeconds;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RestSeconds)));
                return 0 >= DateTime.Now.Subtract(startTime).TotalSeconds - TimerCount;
            }
        }

        [DisplayName("残り時間")]
        public int RestSeconds
        {
            get
            {
                var count = (int)DateTime.Now.Subtract(startTime).TotalSeconds - TimerCount;
                if (0 > count) count = 0;
                return count;
            }
        }

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="alarmName"></param>
        /// <param name="doScript"></param>
        /// <param name="timerCount"></param>
        public Timer(string alarmName, string doScript, int timerCount)
        {
            startTime = DateTime.Now;
            AlarmName = alarmName;
            DoScript = doScript;
            TimerCount = timerCount;
        }
    }

    public class TimeoutEventHandler : EventArgs
    {
        public string ScriptName { get; }

        public TimeoutEventHandler(string scriptName)
        {
            ScriptName = scriptName;
        }
    }

}
