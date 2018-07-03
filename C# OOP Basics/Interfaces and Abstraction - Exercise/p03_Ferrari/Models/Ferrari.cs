using System.Text;

public class Ferrari : ICar
{
    public Ferrari(Driver driver)
    {
        Driver = driver;
    }

    public string Model { get; } = "488-Spider";
    public Driver Driver { get; }

    public string Brake()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{Model}/{Brake()}/{Gas()}/{Driver.Name}");

        return sb.ToString().TrimEnd();
    }
}