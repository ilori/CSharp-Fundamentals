using System;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }


    public int GoldTime { get; set; }


    public override string Winner()
    {
        var car = Participants.SingleOrDefault();

        if (car != null)
        {
            var moneyWon = default(int);
            var prizeTime = string.Empty;

            var timePerformance = this.Length * ((car.Horsepower / 100) * car.Acceleration);

            if (timePerformance <= GoldTime)
            {
                moneyWon = this.PrizePool;
                prizeTime = "Gold";
            }
            else if (timePerformance <= GoldTime + 15)
            {
                moneyWon = (int) (this.PrizePool * 0.5);
                prizeTime = "Silver";
            }
            else if (timePerformance > GoldTime + 15)
            {
                prizeTime = "Bronze";
                moneyWon = (int) (this.PrizePool * 0.3);
            }

            var sb = new StringBuilder();

            sb.AppendLine($"{this.Route} - {this.Length}").AppendLine($"{car.Brand} {car.Model} - {timePerformance} s.")
                .AppendLine($"{prizeTime} Time, ${moneyWon}.");

            return sb.ToString().Trim();
        }

        throw new ArgumentException();
    }
}