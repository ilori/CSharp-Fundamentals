using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();

        var people = new Dictionary<string, Person>();

        while (input != "End")
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var personName = tokens[0];

            var info = tokens[1];

            if (!people.ContainsKey(personName))
            {
                var person = new Person()
                {
                    Name = personName
                };

                people[personName] = person;
            }

            switch (info)
            {
                case "company":
                    var companyName = tokens[2];
                    var department = tokens[3];
                    var salary = decimal.Parse(tokens[4]);
                    people[personName].Company = new Company()
                    {
                        Name = companyName,
                        Department = department,
                        Salary = salary
                    };

                    break;
                case "pokemon":
                    var pokemonName = tokens[2];
                    var type = tokens[3];
                    people[personName].Pokemons.Add(new Pokemon()
                    {
                        Name = pokemonName,
                        Type = type
                    });
                    break;
                case "parents":
                    var parentName = tokens[2];
                    var parentBirthday = tokens[3];
                    people[personName].Parents.Add(new Parent()
                    {
                        Name = parentName,
                        Birthday = parentBirthday
                    });
                    break;
                case "children":
                    var childrenName = tokens[2];
                    var childrenBirthday = tokens[3];
                    people[personName].Childrens.Add(new Children()
                    {
                        Name = childrenName,
                        Birthday = childrenBirthday
                    });
                    break;
                case "car":
                    var carModel = tokens[2];
                    var carSpeed = double.Parse(tokens[3]);
                    people[personName].Car = new Car()
                    {
                        Model = carModel,
                        Speed = carSpeed
                    };
                    break;
            }


            input = Console.ReadLine();
        }

        input = Console.ReadLine();


        people.SingleOrDefault(x => x.Value.Name == input).Deconstruct(out var _, out var personToPrint);

        Console.WriteLine(personToPrint.Name);
        Console.WriteLine("Company:");
        if (personToPrint.Company != null)
        {
            Console.WriteLine(personToPrint.Company);
        }

        Console.WriteLine("Car:");
        if (personToPrint.Car != null)
        {
            Console.WriteLine(personToPrint.Car);
        }

        Console.WriteLine("Pokemon:");
        if (personToPrint.Pokemons.Any())
        {
            foreach (var pokemon in personToPrint.Pokemons)
            {
                Console.WriteLine(pokemon);
            }
        }

        Console.WriteLine("Parents:");
        if (personToPrint.Parents.Any())
        {
            foreach (var parent in personToPrint.Parents)
            {
                Console.WriteLine(parent);
            }
        }

        Console.WriteLine("Children:");
        if (personToPrint.Childrens.Any())
        {
            foreach (var children in personToPrint.Childrens)
            {
                Console.WriteLine(children);
            }
        }
    }
}