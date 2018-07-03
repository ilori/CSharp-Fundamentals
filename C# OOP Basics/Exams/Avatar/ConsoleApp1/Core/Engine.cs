using System;
using System.Linq;
using System.Text;

public class Engine
{
    private NationsBuilder builder;
    private StringBuilder sb;

    public Engine()
    {
        this.builder = new NationsBuilder();
        this.sb = new StringBuilder();
    }


    public void Run()
    {
        var input = Console.ReadLine();

        while (input != "Quit")
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = tokens[0];

            tokens = tokens.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    builder.AssignBender(tokens);
                    break;
                case "Monument":
                    builder.AssignMonument(tokens);
                    break;
                case "Status":
                    sb.AppendLine(builder.GetStatus(tokens[0]));
                    break;
                case "War":
                    builder.IssueWar(tokens[0]);
                    break;
            }

            input = Console.ReadLine();
        }

        sb.AppendLine(builder.GetWarsRecord());

        Console.WriteLine(sb.ToString().Trim());
    }
}