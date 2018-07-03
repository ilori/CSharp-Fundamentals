using System;

public class Car
{
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public int Weight { get; set; }

    public string Color { get; set; }


    public override string ToString()
    {
        if (Color == null && Weight != 0)
        {
            return
                $"{Model}:{Environment.NewLine}  {Engine}{Environment.NewLine}  Weight: {Weight}{Environment.NewLine}  Color: n/a";
        }

        if (Color != null && Weight == 0)
        {
            return
                $"{Model}:{Environment.NewLine}  {Engine}{Environment.NewLine}  Weight: n/a{Environment.NewLine}  Color: {Color}";
        }

        if (Color == null && Weight == 0)
        {
            return
                $"{Model}:{Environment.NewLine}  {Engine}{Environment.NewLine}  Weight: n/a{Environment.NewLine}  Color: n/a";
        }

        return
            $"{Model}:{Environment.NewLine}  {Engine}{Environment.NewLine}  Weight: {Weight}{Environment.NewLine}  Color: {Color}";
    }
}