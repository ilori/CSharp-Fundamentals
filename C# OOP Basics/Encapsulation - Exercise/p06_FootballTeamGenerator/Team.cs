using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    public Team(string name)
    {
        this.Name = name;
    }

    private string name;
    private List<Player> players = new List<Player>();
    public int TeamStats => CalculateTeamStats();

    private int CalculateTeamStats()
    {
        if (players.Count > 0)
        {
            return (int) Math.Round(players.Sum(x => x.OverallPlayerStats) / players.Count);
        }

        return default(int);
    }


    public string Name
    {
        get { return name; }
        private set
        {
            if (!Validator.IsNameValid(value))
            {
                throw new ArgumentException(Validator.InvalidNameMessage);
            }

            name = value;
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var player = players.SingleOrDefault(x => x.Name == playerName);

        if (player == null)
        {
            throw new ArgumentException(string.Format(Validator.MissingPlayerMessage, playerName, this.Name));
        }

        players.Remove(player);
    }
}