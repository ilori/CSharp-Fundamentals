using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var cars = new List<Car>();

        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split().ToArray();

            var model = tokens[0];
            var fuelAmount = decimal.Parse(tokens[1]);
            var fuelConsuption = decimal.Parse(tokens[2]);

            var car = new Car()
            {
                FuelAmount = fuelAmount,
                Model = model,
                FuelConsumption = fuelConsuption
            };

            if (!cars.Any(x => x.Model == model))
            {
                cars.Add(car);
            }
        }

        var input = Console.ReadLine();

        while (input != "End")
        {
            var tokens = input.Split().ToArray();

            var model = tokens[1];
            var kmAmount = int.Parse(tokens[2]);

            var car = cars.SingleOrDefault(x => x.Model == model);
            var fuelLeft = car.FuelAmount - kmAmount * car.FuelConsumption;

            if (fuelLeft >= 0)
            {
                car.FuelAmount = fuelLeft;
                car.DistanceTraveled += kmAmount;
                input = Console.ReadLine();
                continue;
            }

            Console.WriteLine("Insufficient fuel for the drive");

            input = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}