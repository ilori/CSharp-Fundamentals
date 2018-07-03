using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> args)
    {
        var type = args[0];
        var id = args[1];
        var oreOutput = double.Parse(args[2]);
        var energyRequirement = double.Parse(args[3]);

        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(args[4]));
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            default:
                throw new ArgumentException($"Invalid harvester");
        }
    }
}