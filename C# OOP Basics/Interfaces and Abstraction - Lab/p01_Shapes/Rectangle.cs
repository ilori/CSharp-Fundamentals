using System;

public class Rectangle : IDrawable
{
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    private int width;
    private int height;

    public int Width
    {
        get => width;
        private set => width = value;
    }

    public int Height
    {
        get => height;
        private set => height = value;
    }

    public void Draw()
    {
        DrawLine(Width, '*', '*');

        for (var i = 1; i < Height - 1; ++i)
        {
            DrawLine(Width, '*', ' ');
        }

        DrawLine(Width, '*', '*');
    }

    private static void DrawLine(int width, char end, char mid)
    {
        Console.Write(end);

        for (var i = 1; i < width - 1; i++)
        {
            Console.Write(mid);
        }

        Console.WriteLine(end);
    }
}