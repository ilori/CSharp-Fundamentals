using System.Collections.Generic;

public abstract class Race
{
    protected double FirstPlacePrize => 0.5;
    protected double SecondPlacePrize => 0.3;
    protected double ThirdPlacePrize => 0.2;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public int Length { get; set; }

    public string Route { get; set; }

    public int PrizePool { get; set; }

    public List<Car> Participants { get; set; }

    public abstract string Winner();
}