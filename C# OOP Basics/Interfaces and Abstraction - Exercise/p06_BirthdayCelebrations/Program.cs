using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static readonly List<IResidence> Residents = new List<IResidence>();

    public static void Main()
    {
        var input = Console.ReadLine();

        while (input != "End")
        {
            var tokens = input.Split().ToArray();

            var subject = InputReader.Read(tokens);

            Residents.Add(subject);

            input = Console.ReadLine();
        }

        var birthDate = Console.ReadLine();
        PrintDetainedSubjects(birthDate);
    }

    private static void PrintDetainedSubjects(string birthDate)
    {
        Residents.RemoveAll(x => x.Birthdate == null || !x.Birthdate.EndsWith(birthDate));
        foreach (var subject in Residents)
        {
            Console.WriteLine(subject.Birthdate);
        }
    }
}