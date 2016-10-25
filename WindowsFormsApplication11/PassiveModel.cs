using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication11
{
    public class PassiveModel : INotifyPropertyChanged
    {
        Regex filter;
        int onTime;
        DateTime activeTime;
        bool oldActive = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public string State { get; }
        public bool IsActive => 0 < RestTime;
        public int RestTime
        {
            get
            {
                var seconds = (int)activeTime.Subtract(DateTime.Now).TotalSeconds;
                return (0 < seconds) ? seconds : 0;
            }
        }
        public bool IsSetFlag { get; }

        public PassiveModel(string regex, string ontime, string state)
        {
            filter = new Regex(regex);
            onTime = int.Parse(ontime);
            if (0 > state.IndexOf('!'))
            {
                State = state;
                IsSetFlag = true;
            }
            else
            {
                State = state.Substring(1);
                IsSetFlag = false;
            }
        }

        public bool Check(string message)
        {
            if (filter.IsMatch(message))
            {
                activeTime = DateTime.Now.AddSeconds((IsSetFlag) ? onTime : 0);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
            }

            //Active状態に変化があったらTrueを返す
            var newactive = IsActive;
            if (oldActive != newactive)
            {
                oldActive = newactive;
                return true;
            }
            return false;
        }
    }
}
