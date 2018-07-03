using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();

        var animals = new List<Animal>();

        while (input != "Beast!")
        {
            var tokens = Console.ReadLine().Split().ToArray();

            try
            {
                if (tokens.Length < 3)
                {
                    throw new ArgumentException("Invalid input!");
                }

                var name = tokens[0];
                if (!int.TryParse(tokens[1], out var age))
                {
                    throw new ArgumentException("Invalid input!");
                }

                var gender = tokens[2];

                switch (input.ToLower())
                {
                    case "dog":
                        animals.Add(new Dog(name, age, gender));
                        break;
                    case "cat":
                        animals.Add(new Cat(name, age, gender));
                        break;
                    case "frog":
                        animals.Add(new Frog(name, age, gender));
                        break;
                    case "kitten":
                        animals.Add(new Kitten(name, age));
                        break;
                    case "tomcat":
                        animals.Add(new Tomcat(name, age));
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            input = Console.ReadLine();
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}