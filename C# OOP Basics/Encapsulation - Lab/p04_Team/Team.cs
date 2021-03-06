﻿using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public List<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }


    public List<Person> FirstTeam

    {
        get { return firstTeam; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First team has {this.firstTeam.Count} players.");
        sb.AppendLine($"Reserve team has {this.reserveTeam.Count} players.");

        return sb.ToString().Trim();
    }
}