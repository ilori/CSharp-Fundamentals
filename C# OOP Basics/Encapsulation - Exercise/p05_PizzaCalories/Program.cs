using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<Topping> toppings = new List<Topping>();

    public static void Main()
    {
        try
        {
            var pizzaInformation = Console.ReadLine().Split().ToList();
            var pizzaName = pizzaInformation[1];
            var pizza = new Pizza(pizzaName);

            var doughInformation = Console.ReadLine().Split().ToList();
            var flourType = doughInformation[1];
            var bakingTechniuque = doughInformation[2];
            var doughWeight = double.Parse(doughInformation[3]);
            var dough = new Dough(flourType, bakingTechniuque, doughWeight);

            var toppingInformation = Console.ReadLine();
            while (toppingInformation != "END")
            {
                var tokens = toppingInformation.Split().ToList();
                var type = tokens[1];
                var toppingWeight = double.Parse(tokens[2]);

                var topping = new Topping(type, toppingWeight);
                toppings.Add(topping);

                toppingInformation = Console.ReadLine();
            }

            pizza.Dough = dough;
            pizza.Toppings = toppings;

            Console.WriteLine(pizza);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}