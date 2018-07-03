using System;
using System.Linq;

public class Engine
{
    private PawManager paw;

    public Engine()
    {
        this.paw = new PawManager();
    }

    public void Run()
    {
        var input = Console.ReadLine();

        while (input != "Paw Paw Pawah")
        {
            var tokens = input.Split(new[] {" | "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = tokens[0];

            tokens = tokens.Skip(1).ToList();

            switch (command)
            {
                case "RegisterCleansingCenter":
                    paw.RegisterCleansingCenter(tokens);
                    break;
                case "RegisterAdoptionCenter":
                    paw.RegisterAdoptionCenter(tokens);
                    break;
                case "RegisterDog":
                    paw.RegisterDog(tokens);
                    break;
                case "RegisterCat":
                    paw.RegisterCat(tokens);
                    break;
                case"SendForCleansing":
                    paw.SendForCleansing(tokens);
                    break;
                case "Cleanse":
                    paw.Cleanse(tokens);
                    break;
                case "Adopt":
                    paw.Adopt(tokens);
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(paw.Paw());
    }
}