using System.Text;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }

    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{Color} {this.GetType().Name} {Model} with {Battery} Batteries").AppendLine(Start())
            .AppendLine(Stop());

        return sb.ToString().TrimEnd();
    }
}