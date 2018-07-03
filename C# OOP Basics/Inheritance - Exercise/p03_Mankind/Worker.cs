using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;
    public decimal SalaryPerHour => CalculateSalary();

    private decimal CalculateSalary()
    {
        return this.WeekSalary / this.WorkHoursPerDay / 5;
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName,
        lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }


    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }


    public decimal WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursPerDay = value;
        }
    }


    public override string ToString()
    {
        return
            $"First Name: {this.FirstName}\nLast Name: {this.LastName}\nWeek Salary: {this.WeekSalary:f2}\nHours per day: {this.WorkHoursPerDay:f2}\nSalary per hour: {this.SalaryPerHour:f2}";
    }
}