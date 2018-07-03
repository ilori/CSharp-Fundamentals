namespace p04_WorkForce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Program
    {
        public static void Main()
        {
            Jobs jobs = new Jobs();

            List<Employee> employees = new List<Employee>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "StandardEmployee":
                        employees.Add(new StandardEmployee(tokens[1]));

                        break;

                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(tokens[1]));

                        break;

                    case "Job":
                        Employee employee = employees.First(e => e.Name == tokens[3]);

                        jobs.AddJob(new Job(tokens[1], int.Parse(tokens[2]), employee));

                        break;

                    case "Pass":
                        jobs.ToList().ForEach(j => j.Update());

                        break;

                    case "Status":
                        jobs.ForEach(Console.WriteLine);

                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}