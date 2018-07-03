using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public string Title { get; set; }

    public int Year { get; set; }

    public IReadOnlyCollection<string> Authors { get; set; }

    public int CompareTo(Book other)
    {
        int result = this.Year.CompareTo(other.Year);

        if (result == 0)
        {
            result = string.Compare(this.Title, other.Title, StringComparison.InvariantCulture);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}