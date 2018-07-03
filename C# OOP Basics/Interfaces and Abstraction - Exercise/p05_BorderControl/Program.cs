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

        var id = Console.ReadLine();

        PrintDetainedSubjects(id);
    }

    private static void PrintDetainedSubjects(string id)
    {
        Residents.RemoveAll(x => !x.Id.EndsWith(id));

        foreach (var subject in Residents)
        {
            Console.WriteLine(subject.Id);
        }
    }
}