using System;
using System.Collections.Generic;

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

    public class Timer
    {
        public string AlarmName { get; set; }
        public string DoScript { get; set; }
        public int TimerCount { get; set; }
        DateTime startTime;

        public Timer(string alarmName, string doScript, int timerCount)
        {
            startTime = DateTime.Now;
            AlarmName = alarmName;
            DoScript = doScript;
            TimerCount = timerCount;
        }

        public bool IsTimeout => 0 >= DateTime.Now.Subtract(startTime).TotalSeconds - TimerCount;
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
