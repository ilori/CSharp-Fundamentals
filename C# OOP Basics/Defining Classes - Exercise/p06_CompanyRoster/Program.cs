using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var data = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().ToArray();

            var name = input[0];
            var salary = decimal.Parse(input[1]);
            var position = input[2];
            var department = input[3];

            var employee = new Employee(name, salary, position, department);

            if (input.Length == 5)
            {
                if (input[4].Contains("@"))
                {
                    var email = input[4];
                    employee.Email = email;
                }
                else
                {
                    var age = int.Parse(input[4]);
                    employee.Age = age;
                }
            }
            else if (input.Length == 6)
            {
                var email = input[4];
                var age = int.Parse(input[5]);
                employee.Email = email;
                employee.Age = age;
            }

            data.Add(employee);
        }

        var highest = data.GroupBy(x => x.Department)
            .Select(x => new
            {
                Deparments = x.Key,
                AverageSalary = x.Average(emp => emp.Salary),
                Employees = x.OrderByDescending(e => e.Salary)
            })
            .OrderByDescending(x => x.AverageSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {highest.Deparments}");

        foreach (var employee in highest.Employees)
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}