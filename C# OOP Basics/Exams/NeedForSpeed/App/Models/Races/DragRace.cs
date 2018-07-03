using System.Linq;
using System.Text;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override string Winner()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");

        this.Participants = this.Participants.OrderByDescending(x => x.EnginePerformance).Take(3).ToList();

        for (var i = 0; i < this.Participants.Count; i++)
        {
            var car = this.Participants[i];

            if (i == 0)
            {
                sb.AppendLine(
                    $"{i + 1}. {car.Brand} {car.Model} {car.EnginePerformance}PP - ${this.PrizePool * this.FirstPlacePrize}");
            }
            else if (i == 1)
            {
                sb.AppendLine(
                    $"{i + 1}. {car.Brand} {car.Model} {car.EnginePerformance}PP - ${this.PrizePool * this.SecondPlacePrize}");
            }
            else
            {
                sb.AppendLine(
                    $"{i + 1}. {car.Brand} {car.Model} {car.EnginePerformance}PP - ${this.PrizePool * this.ThirdPlacePrize}");
            }
        }

        return sb.ToString().Trim();
    }
}