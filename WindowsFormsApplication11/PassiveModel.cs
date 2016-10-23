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

        public PassiveModel(string regex, string ontime, string state)
        {
            filter = new Regex(regex);
            onTime = int.Parse(ontime);
            State = state;
        }

        public void Check(string message)
        {
            if (filter.IsMatch(message))
            {
                activeTime = DateTime.Now.AddSeconds(onTime);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
            }
        }
    }
}
