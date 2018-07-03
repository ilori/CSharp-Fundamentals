using System;
using System.Linq;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;


    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            var tokens = value.Split().ToList();
            if (tokens.Count > 1)
            {
                var secondName = tokens[1];
                if (char.IsDigit(secondName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            author = value;
        }
    }


    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}").AppendLine($"Title: {Title}")
            .AppendLine($"Author: {Author}")
            .AppendLine($"Price: {Price:F2}");

        return sb.ToString().TrimEnd();
    }
}