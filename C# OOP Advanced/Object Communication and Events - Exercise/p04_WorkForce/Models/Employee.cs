namespace p04_WorkForce.Models
{
    using Contracts;

    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; set; }

        public int WorkHoursPerWeek { get; set; }
    }
}