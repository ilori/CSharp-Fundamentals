using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ConsoleApp1.Models.Nations;

public class NationsBuilder
{
    private List<Nation> nations;
    private StringBuilder builder;
    private List<double> nationsTotalPower;
    private Nation nation;
    private int warCount = 1;


    public NationsBuilder()
    {
        this.nations = new List<Nation>();
        this.builder = new StringBuilder();
        this.nationsTotalPower = new List<double>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var bender = BenderFactory.CreateBender(benderArgs);

        switch (bender.GetType().Name)
        {
            case "AirBender":
                if (!nations.Any(x => x.Name == "Air"))
                {
                    nation = new AirNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Air");
                nation.AssignBenders(bender);

                break;
            case "WaterBender":
                if (!nations.Any(x => x.Name == "Water"))
                {
                    nation = new WaterNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Water");

                nation.AssignBenders(bender);

                break;
            case "EarthBender":
                if (!nations.Any(x => x.Name == "Earth"))
                {
                    nation = new EarthNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Earth");

                nation.AssignBenders(bender);

                break;
            case "FireBender":
                if (!nations.Any(x => x.Name == "Fire"))
                {
                    nation = new FireNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Fire");
                nation.AssignBenders(bender);
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var monument = MonumentFactory.CreateMonument(monumentArgs);


        switch (monument.GetType().Name)
        {
            case "AirMonument":
                if (!nations.Any(x => x.Name == "Air"))
                {
                    nation = new AirNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Air");
                nation.AssignMonuments(monument);

                break;
            case "WaterMonument":
                if (!nations.Any(x => x.Name == "Water"))
                {
                    nation = new WaterNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Water");
                nation.AssignMonuments(monument);


                break;
            case "EarthMonument":
                if (!nations.Any(x => x.Name == "Earth"))
                {
                    nation = new EarthNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Earth");

                nation.AssignMonuments(monument);

                break;
            case "FireMonument":
                if (!nations.Any(x => x.Name == "Fire"))
                {
                    nation = new FireNation();
                    nations.Add(nation);
                }

                nation = nations.SingleOrDefault(x => x.Name == "Fire");
                nation.AssignMonuments(monument);
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        var nationToReturn = nations.SingleOrDefault(x => x.Name == nationsType);

        return nationToReturn.ToString();
    }

    public void IssueWar(string nationsType)
    {
        builder.AppendLine($"War {warCount} issued by {nationsType}");
        warCount++;

        foreach (var nation in nations)
        {
            nationsTotalPower.Add(nation.TotalPower);
        }

        if (nationsTotalPower.Count > 0)
        {
            var maxTotalPower = nationsTotalPower.Max();

            var winnerNation = nations.SingleOrDefault(x => x.TotalPower == maxTotalPower);

            foreach (var nation in nations)
            {
                if (nation != winnerNation)
                {
                    nation.RemoveBinders();
                    nation.RemoveMonuments();
                }
            }
        }
    }

    public string GetWarsRecord()
    {
        return builder.ToString();
    }
}