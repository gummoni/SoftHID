using System;

namespace MacroLib.Jobs
{
    public class Job
    {
        Action lazy;

        public Job(Action lazy)
        {
            this.lazy = lazy;
        }

        public void Execute()
        {
            lazy();
        }
    }

}
