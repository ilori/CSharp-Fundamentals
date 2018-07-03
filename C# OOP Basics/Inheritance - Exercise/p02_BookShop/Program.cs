using System;

public class Program
{
    public static void Main()
    {
        try
        {
            var author = Console.ReadLine();
            var title = Console.ReadLine();
            var price = decimal.Parse(Console.ReadLine());

            var book = new Book(author, title, price);
            var goldenEditionBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book + Environment.NewLine);
            Console.WriteLine(goldenEditionBook);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}