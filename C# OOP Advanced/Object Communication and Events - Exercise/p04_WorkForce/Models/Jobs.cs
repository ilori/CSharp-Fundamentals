namespace p04_WorkForce.Models
{
    using System;
    using System.Collections.Generic;

    public class Jobs : List<Job>
    {
        public void AddJob(Job job)
        {
            this.Add(job);

            job.JobCompleted += this.OnJobComplete;
        }

        public void OnJobComplete(Job job)
        {
            this.Remove(job);
        }

        public void Status()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this));
        }
    }
}