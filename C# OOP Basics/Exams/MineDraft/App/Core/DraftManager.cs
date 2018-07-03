using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
    }


    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        var dayEnergyProduced = providers.Sum(x => x.EnergyOutput);
        totalEnergyStored += dayEnergyProduced;
        var dayEnergyRequired = default(double);
        var dayOreMined = default(double);
        switch (mode)
        {
            case "Full":
                dayEnergyRequired = harvesters.Sum(x => x.EnergyRequirement);
                dayOreMined += totalEnergyStored >= dayEnergyRequired ? harvesters.Sum(x => x.OreOutput) : 0;
                break;
            case "Half":
                dayEnergyRequired = harvesters.Sum(x => x.EnergyRequirement) * 0.6;
                dayOreMined += totalEnergyStored >= dayEnergyRequired ? harvesters.Sum(x => x.OreOutput) * 0.5 : 0;
                break;
            case "Energy":
                dayEnergyRequired = 0;
                dayOreMined = 0;
                break;
        }

        if (totalEnergyStored >= dayEnergyRequired)
        {
            totalEnergyStored -= dayEnergyRequired;
            totalMinedOre += dayOreMined;
        }

        var sb = new StringBuilder();

        sb.AppendLine($"A day has passed.").AppendLine($"Energy Provided: {dayEnergyProduced}")
            .AppendLine($"Plumbus Ore Mined: {dayOreMined}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var modeName = arguments[0];

        if (modeName == "Full" || modeName == "Half" || modeName == "Energy")
        {
            this.mode = modeName;
            return $"Successfully changed working mode to {mode} Mode";
        }

        throw new InvalidOperationException();
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        var harvester = harvesters.SingleOrDefault(x => x.Id == id);

        if (harvester != null)
        {
            return harvester.ToString();
        }

        var provider = providers.SingleOrDefault(x => x.Id == id);

        if (provider != null)
        {
            return provider.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"System Shutdown").AppendLine($"Total Energy Stored: {this.totalEnergyStored}")
            .AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }
}