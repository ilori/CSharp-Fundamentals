using System;

public class Square : Figure
{
    public Square(int width)
    {
        Width = width;
    }

    public int Width { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"|{new string('-', Width)}|");

        for (var i = 0; i < Width - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', Width)}|");
        }

        Console.WriteLine($"|{new string('-', Width)}|");
    }
}