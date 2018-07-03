using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<Team> teams = new List<Team>();

    public static void Main()
    {
        var input = Console.ReadLine();

        while (input != "END")
        {
            var tokens = input.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = tokens[0];

            switch (command)
            {
                case"Team":
                    try
                    {
                        CreateTeam(tokens[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case"Add":
                    try
                    {
                        AddPlayer(tokens.Skip(1).ToArray());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case"Remove":
                    try
                    {
                        RemovePlayer(tokens.Skip(1).ToArray());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case"Rating":
                    try
                    {
                        PrintRating(tokens[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
            }

            input = Console.ReadLine();
        }
    }


    private static void PrintRating(string teamName)
    {
        var team = teams.SingleOrDefault(x => x.Name == teamName);
        if (team == null)
        {
            throw new ArgumentException(string.Format(Validator.MissingTeamMessage, teamName));
        }

        Console.WriteLine($"{team.Name} - {team.TeamStats}");
    }

    private static void RemovePlayer(string[] tokens)
    {
        var teamName = tokens[0];

        var team = teams.SingleOrDefault(x => x.Name == teamName);
        if (team == null)
        {
            throw new ArgumentException(string.Format(Validator.MissingTeamMessage, teamName));
        }

        var playerName = tokens[1];
        team.RemovePlayer(playerName);
    }

    private static void AddPlayer(string[] tokens)
    {
        var teamName = tokens[0];

        var team = teams.SingleOrDefault(x => x.Name == teamName);

        if (team == null)
        {
            throw new ArgumentException(string.Format(Validator.MissingTeamMessage, teamName));
        }

        var playerName = tokens[1];
        var endurance = int.Parse(tokens[2]);
        var sprint = int.Parse(tokens[3]);
        var dribble = int.Parse(tokens[4]);
        var passing = int.Parse(tokens[5]);
        var shooting = int.Parse(tokens[6]);

        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

        team.AddPlayer(player);
    }

    private static void CreateTeam(string teamName)
    {
        var team = new Team(teamName);
        teams.Add(team);
    }
}