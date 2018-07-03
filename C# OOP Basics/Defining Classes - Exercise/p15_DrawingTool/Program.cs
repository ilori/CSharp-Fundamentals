using System;

public class Program
{
    private static int width;
    private static int height;

    public static void Main()
    {
        var figureType = Console.ReadLine();

        switch (figureType)
        {
            case"Square":
                width = int.Parse(Console.ReadLine());
                var square = new Square(width);
                square.Draw();
                break;
            case"Rectangle":
                width = int.Parse(Console.ReadLine());
                height = int.Parse(Console.ReadLine());
                var rect = new Rectangle(width, height);
                rect.Draw();
                break;
        }
    }
}