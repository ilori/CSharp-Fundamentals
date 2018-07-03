using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        var input = Console.ReadLine();

        while (input != "Shutdown")
        {
            var tokens = input.Split().ToList();

            var command = tokens[0];

            tokens = tokens.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(tokens));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(tokens));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(tokens));
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(tokens));
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(draftManager.ShutDown());
    }
}