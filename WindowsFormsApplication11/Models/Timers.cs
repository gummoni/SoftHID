using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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

        public override string ToString()
        {
            return string.Join("\r\n", this.Select(_ => _.ToString()));
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
                return 0 >= count;
            }
        }

        [DisplayName("残り時間")]
        public int RestSeconds
        {
            get
            {
                var count = TimerCount - (int)DateTime.Now.Subtract(startTime).TotalSeconds;
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

        public override string ToString()
        {
            return $"・{AlarmName} 残り時間{RestSeconds}";
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
