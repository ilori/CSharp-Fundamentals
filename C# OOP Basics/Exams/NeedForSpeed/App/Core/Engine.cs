using System;
using System.Linq;

public class Engine
{
    private CarManager carManager;

    public Engine()
    {
        this.carManager = new CarManager();
    }

    public void Run()
    {
        var input = Console.ReadLine();

        while (input != "Cops Are Here")
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = tokens[0];

            tokens = tokens.Skip(1).ToList();

            switch (command.ToLower())
            {
                case "register":
                    carManager.Register(int.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], int.Parse(tokens[4]),
                        int.Parse(tokens[5]), int.Parse(tokens[6]),
                        int.Parse(tokens[7]), int.Parse(tokens[8]));
                    break;
                case "check":
                    Console.WriteLine(carManager.Check(int.Parse(tokens[0])));
                    break;
                case "open":
                    if (tokens.Count == 5)
                    {
                        carManager.Open(int.Parse(tokens[0]), tokens[1], int.Parse(tokens[2]), tokens[3],
                            int.Parse(tokens[4]));
                        break;
                    }
                    carManager.Open(int.Parse(tokens[0]), tokens[1], int.Parse(tokens[2]), tokens[3],
                        int.Parse(tokens[4]), int.Parse(tokens[5]));
                    break;
                case "participate":
                    carManager.Participate(int.Parse(tokens[0]), int.Parse(tokens[1]));
                    break;
                case "start":
                    Console.WriteLine(carManager.Start(int.Parse(tokens[0])));
                    break;
                case "park":
                    carManager.Park(int.Parse(tokens[0]));
                    break;
                case "unpark":
                    carManager.Unpark(int.Parse(tokens[0]));
                    break;
                case "tune":
                    carManager.Tune(int.Parse(tokens[0]), tokens[1]);
                    break;
            }

            input = Console.ReadLine();
        }
    }
}