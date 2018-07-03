using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var player = new Player();
        player.Eat(Console.ReadLine()
            .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(FoodFactory.GetFood));
        Console.WriteLine(player);
    }
}