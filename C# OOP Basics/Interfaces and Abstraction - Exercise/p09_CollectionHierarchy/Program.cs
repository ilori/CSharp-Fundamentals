using System;
using System.Text;

public class Program
{
    private static readonly IAddCollection<string> Addcollection = new AddCollection<string>();
    private static readonly IAddRemoveCollection<string> AddRemoveCollection = new AddRemoveCollection<string>();
    private static readonly IMyList<string> MyList = new MyList<string>();
    private static readonly StringBuilder Sb = new StringBuilder();

    public static void Main()
    {
        var input = Console.ReadLine()?.Split();

        FillCollection(input, Addcollection);
        FillCollection(input, AddRemoveCollection);
        FillCollection(input, MyList);

        var removals = int.Parse(Console.ReadLine());
        RemoveItems(removals, AddRemoveCollection);
        RemoveItems(removals, MyList);

        Console.WriteLine(Sb.ToString().Trim());
    }

    private static void RemoveItems<T>(int removals, IAddRemoveCollection<T> collection)
    {
        while (removals > 0)
        {
            var removedElement = collection.Remove();
            Sb.Append($"{removedElement} ");
            removals--;
        }

        Sb.Remove(Sb.Length - 1, 1).AppendLine();
    }

    private static void FillCollection(string[] input, IAddCollection<string> collection)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        foreach (var str in input)
        {
            var index = collection.Add(str);
            Sb.Append($"{index} ");
        }

        Sb.Remove(Sb.Length - 1, 1).AppendLine();
    }
}