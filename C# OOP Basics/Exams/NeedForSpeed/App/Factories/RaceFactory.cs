using System;

public static class RaceFactory
{
    public static Race CreateRace(params object[] args)
    {
        var type = args[0].ToString();
        var lenght = (int) args[1];
        var route = args[2].ToString();
        var prizePool = (int) args[3];

        switch (type)
        {
            case "Casual":
                return new CasualRace(lenght, route, prizePool);
            case "Drag":
                return new DragRace(lenght, route, prizePool);
            case "Drift":
                return new DriftRace(lenght, route, prizePool);
            case "Circuit":
                return new CircuitRace(lenght, route, prizePool, (int) args[4]);
            case "TimeLimit":
                return new TimeLimitRace(lenght, route, prizePool, (int) args[4]);
            default:
                throw new InvalidOperationException("Invalid Type of Race");
        }
    }
}