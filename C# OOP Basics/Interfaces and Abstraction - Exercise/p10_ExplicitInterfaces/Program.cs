using System;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();

        while (input != "End")
        {
            var tokens = input.Split();

            var name = tokens[0];
            var country = tokens[1];
            var age = int.Parse(tokens[2]);
            var citizen = new Citizen(name, country, age);
            var resident = (IResident) citizen;
            var person = (IPerson) citizen;

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());

            input = Console.ReadLine();
        }
    }
}