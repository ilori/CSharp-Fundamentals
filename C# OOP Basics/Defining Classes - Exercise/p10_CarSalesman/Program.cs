using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var engines = new List<Engine>();

        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var model = input[0];

            var power = int.Parse(input[1]);

            if (input.Length == 3)
            {
                if (int.TryParse(input[2], out var displacement))
                {
                    var engine = new Engine()
                    {
                        Model = model,
                        Power = power,
                        Displacement = displacement
                    };

                    engines.Add(engine);
                    continue;
                }
                else
                {
                    var efficiency = input[2];
                    var engine = new Engine()
                    {
                        Model = model,
                        Power = power,
                        Efficiency = efficiency
                    };

                    engines.Add(engine);
                    continue;
                }
            }

            if (input.Length == 4)
            {
                var displacement = int.Parse(input[2]);
                var efficiency = input[3];

                var engine = new Engine()
                {
                    Model = model,
                    Efficiency = efficiency,
                    Power = power,
                    Displacement = displacement
                };

                engines.Add(engine);
                continue;
            }

            engines.Add(new Engine()
            {
                Model = model,
                Power = power
            });
        }

        var a = int.Parse(Console.ReadLine());

        var cars = new List<Car>();

        for (int i = 0; i < a; i++)
        {
            var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var model = tokens[0];

            var engine = engines.SingleOrDefault(x => x.Model == tokens[1]);

            if (tokens.Length == 3)
            {
                if (int.TryParse(tokens[2], out var weight))
                {
                    var car = new Car()
                    {
                        Engine = engine,
                        Model = model,
                        Weight = weight
                    };

                    cars.Add(car);
                    continue;
                }
                else
                {
                    var color = tokens[2];

                    var car = new Car()
                    {
                        Engine = engine,
                        Model = model,
                        Color = color
                    };

                    cars.Add(car);
                    continue;
                }
            }

            if (tokens.Length == 4)
            {
                var weight = int.Parse(tokens[2]);
                var color = tokens[3];
                var car = new Car()
                {
                    Engine = engine,
                    Model = model,
                    Weight = weight,
                    Color = color
                };
                cars.Add(car);
                continue;
            }

            cars.Add(new Car()
            {
                Engine = engine,
                Model = model
            });
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}