using System;

namespace MacroLib.Jobs
{
    public class Job
    {
        Action lazy;
        DateTime startTime = new DateTime();

        public Job(Action lazy)
        {
            this.lazy = lazy;
        }

        public Job(Action lazy, TimeSpan startTime)
        {
            this.lazy = lazy;
            this.startTime = DateTime.Now.Add(startTime);
        }

        public bool IsTimeout
        {
            get
            {
                if (0 == startTime.Ticks)
                {
                    return false;
                }
                var result = (int)startTime.Subtract(DateTime.Now).Ticks;
                return 0 >= result;
            }
        }

        public void Execute()
        {
            lazy();
        }
    }

}
