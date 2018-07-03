using System.Collections.Generic;
using System.Text;

public class Person
{
    public string BirthDate { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public List<Person> Children { get; set; } = new List<Person>();

    public List<Person> Parents { get; set; } = new List<Person>();

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{FirstName} {LastName} {BirthDate}");
        builder.AppendLine("Parents:");

        foreach (var parent in Parents)
        {
            builder.AppendLine($"{parent.FirstName} {parent.LastName} {parent.BirthDate}");
        }

        builder.AppendLine("Children:");

        foreach (var child in Children)
        {
            builder.AppendLine($"{child.FirstName} {child.LastName} {child.BirthDate}");
        }

        return builder.ToString();
    }
}