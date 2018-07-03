using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private const double CircuitFirstPlacePrize = 0.4;
    private const double CircuitSecondPlacePrize = 0.3;
    private const double CircuitThirdPlacePrize = 0.2;
    private const double CircuitForthPlacePrize = 0.1;

    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; private set; }


    private void DecreaseDurability()
    {
        for (int i = 0; i < Laps; i++)
        {
            foreach (var participant in this.Participants)
            {
                participant.Durability -= Length * Length;
            }
        }
    }

    public override string Winner()
    {
        var sb = new StringBuilder();

        this.DecreaseDurability();

        sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");

        this.Participants = this.Participants.OrderByDescending(x => x.OverallPerformance).Take(4).ToList();

        for (var i = 0; i < this.Participants.Count; i++)
        {
            var car = this.Participants[i];

            if (i == 0)
            {
                sb.AppendLine(
                    $"{i + 1}. {car.Brand} {car.Model} {car.OverallPerformance}PP - ${this.PrizePool * CircuitFirstPlacePrize}");
            }
            else if (i == 1)
            {
                sb.AppendLine(
                    $"{i + 1}. {car.Brand} {car.Model} {car.OverallPerformance}PP - ${this.PrizePool * CircuitSecondPlacePrize}");
            }
            else if (i == 2)
            {
                sb.AppendLine(
                    $"{i + 1}. {car.Brand} {car.Model} {car.OverallPerformance}PP - ${this.PrizePool * CircuitThirdPlacePrize}");
            }
            else
            {
                sb.AppendLine(
                    $"{i + 1}. {car.Brand} {car.Model} {car.OverallPerformance}PP - ${this.PrizePool * CircuitForthPlacePrize}");
            }
        }

        return sb.ToString().Trim();
    }
}