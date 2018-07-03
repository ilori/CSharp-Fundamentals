using System;
using System.Text;

public class Box
{
    public Box(double length, double width, double height)
    {
        Length = length;
        Height = height;
        Width = width;
    }

    private double lenght;
    private double height;
    private double width;


    public double Length
    {
        get { return this.lenght; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }

            this.lenght = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    private double SurfaceArea => (2 * this.Length * this.Height) + (2 * this.Length * this.Width) +
                                  (2 * this.Width * this.Height);


    private double LeteralSurfaceArea => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);


    private double Volume => this.Length * this.Width * this.Height;


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Surface Area - {this.SurfaceArea:F2}");
        sb.AppendLine($"Lateral Surface Area - {this.LeteralSurfaceArea:F2}");
        sb.AppendLine($"Volume - {this.Volume:F2}");
        return sb.ToString().Trim();
    }
}