using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<Person> people = new List<Person>();
    private static List<Product> products = new List<Product>();

    public static void Main()
    {
        try
        {
            var peopleInformation = Console.ReadLine().Split(new[] {";", "="}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var productInformation = Console.ReadLine().Split(new[] {";", "="}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            AddPeople(peopleInformation);

            AddProducts(productInformation);

            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split().ToList();

                var personName = tokens[0];
                var productName = tokens[1];

                var person = people.SingleOrDefault(x => x.Name == personName);
                var product = products.SingleOrDefault(x => x.Name == productName);

                AddProductToPerson(person, product);

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.Products.Count > 0)
                {
                    Console.WriteLine(person);
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void AddProductToPerson(Person person, Product product)
    {
        Console.WriteLine(person.AddProduct(product));
    }

    private static void AddProducts(string[] productInformation)
    {
        for (var i = 0; i < productInformation.Length; i += 2)
        {
            var name = productInformation[i];
            var cost = decimal.Parse(productInformation[i + 1]);

            products.Add(new Product(name, cost));
        }
    }

    private static void AddPeople(string[] peopleInformation)
    {
        for (var i = 0; i < peopleInformation.Length; i += 2)
        {
            var name = peopleInformation[i];
            var money = decimal.Parse(peopleInformation[i + 1]);
            people.Add(new Person(name, money));
        }
    }
}