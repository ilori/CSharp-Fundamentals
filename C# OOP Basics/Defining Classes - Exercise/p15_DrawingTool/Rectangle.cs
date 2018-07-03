using System;

public class Rectangle : Figure
{
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"|{new string('-', Width)}|");

        for (var i = 0; i < Height - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', Width)}|");
        }

        Console.WriteLine($"|{new string('-', Width)}|");
    }
}