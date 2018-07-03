using System;

public class Circle : IDrawable
{
    public Circle(int radius)
    {
        Radius = radius;
    }

    private int radius;

    public int Radius
    {
        get => radius;
        private set => radius = value;
    }


    public void Draw()
    {
        var radiusIn = Radius - 0.4;
        var radiusOut = Radius + 0.4;

        for (double y = Radius; y >= -Radius; --y)
        {
            for (double x = -Radius; x < radiusOut; x += 0.5)
            {
                var value = x * x + y * y;
                if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}