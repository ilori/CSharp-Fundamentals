using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var rectangleCount = input[0];
        var checkCount = input[1];

        var rectangles = new List<Rectangle>();

        for (var i = 0; i < rectangleCount; i++)
        {
            var tokens = Console.ReadLine().Split().ToArray();

            var id = tokens[0];
            var width = double.Parse(tokens[1]);
            var height = double.Parse(tokens[2]);
            var x = double.Parse(tokens[3]);
            var y = double.Parse(tokens[4]);

            var rectangle = new Rectangle(id, width, height, x, y);

            rectangles.Add(rectangle);
        }

        for (var i = 0; i < checkCount; i++)
        {
            var tokens = Console.ReadLine().Split().ToArray();
            var firstId = tokens[0];
            var secondId = tokens[1];


            var firstRectangle = rectangles.SingleOrDefault(x => x.Id == firstId);
            var secondRectangle = rectangles.SingleOrDefault(x => x.Id == secondId);

            Console.WriteLine(firstRectangle.DoesRectanglesIntersect(secondRectangle).ToString().ToLower());
        }
    }
}