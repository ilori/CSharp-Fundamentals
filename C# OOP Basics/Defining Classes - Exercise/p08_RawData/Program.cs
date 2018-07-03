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
            var input = Console.ReadLine().Split().ToArray();

            var model = input[0];

            var engineSpeed = int.Parse(input[1]);
            var enginePower = int.Parse(input[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(input[3]);
            var cargoType = input[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tireTokens = input.Skip(5).ToList();

            var tires = new List<Tire>();

            for (var j = 0; j < tireTokens.Count; j += 2)
            {
                var tireAge = int.Parse(tireTokens[j + 1]);
                var tirePressure = double.Parse(tireTokens[j]);

                tires.Add(new Tire(tireAge, tirePressure));
            }

            var car = new Car(model, engine, cargo, tires);

            cars.Add(car);
        }

        var command = Console.ReadLine();

        switch (command)
        {
            case "fragile":
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(x => x.Tires.Any(p => p.Pressure < 1))));
                break;

            case "flamable":
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(x => x.Engine.Power > 250)));
                break;
        }
    }
}