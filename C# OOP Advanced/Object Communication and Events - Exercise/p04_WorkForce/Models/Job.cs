namespace p04_WorkForce.Models
{
    using System;
    using Contracts;

    public delegate void JobCompletedEventHandler(Job job);

    public class Job
    {
        public event JobCompletedEventHandler JobCompleted;

        private readonly IEmployee employee;

        private int hoursOfWorkRequired;

        public Job(string name, int hoursOfWorkRequired, IEmployee employee)
        {
            this.Name = name;
            this.hoursOfWorkRequired = hoursOfWorkRequired;
            this.employee = employee;
        }

        public string Name { get; }

        public void Update()
        {
            this.hoursOfWorkRequired -= employee.WorkHoursPerWeek;

            if (hoursOfWorkRequired <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.OnJobCompleted(this);
            }
        }

        protected virtual void OnJobCompleted(Job job)
        {
            JobCompleted?.Invoke(job);
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.hoursOfWorkRequired}";
        }
    }
}