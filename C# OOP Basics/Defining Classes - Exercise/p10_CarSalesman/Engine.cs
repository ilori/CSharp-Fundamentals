using System;

public class Engine
{
    public string Model { get; set; }

    public int Power { get; set; }

    public int Displacement { get; set; }

    public string Efficiency { get; set; } = "n/a";

    public override string ToString()
    {
        if (Efficiency == null && Displacement != 0)
        {
            return
                $"{Model}:{Environment.NewLine}    Power: {Power}{Environment.NewLine}    Displacement: {Displacement}{Environment.NewLine}    Efficiency: n/a";
        }

        if (Efficiency != null && Displacement == 0)
        {
            return
                $"{Model}:{Environment.NewLine}    Power: {Power}{Environment.NewLine}    Displacement: n/a{Environment.NewLine}    Efficiency: {Efficiency}";
        }

        if (Efficiency == null && Displacement == 0)
        {
            return
                $"{Model}:{Environment.NewLine}    Power: {Power}{Environment.NewLine}    Displacement: n/a{Environment.NewLine}    Efficiency: n/a";
        }

        return
            $"{Model}:{Environment.NewLine}    Power: {Power}{Environment.NewLine}    Displacement: {Displacement}{Environment.NewLine}    Efficiency: {Efficiency}";
    }
}