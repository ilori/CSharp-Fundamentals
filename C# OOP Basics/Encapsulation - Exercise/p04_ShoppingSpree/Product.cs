using System;

public class Product
{
    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    private string name;
    private decimal cost;

    public decimal Cost
    {
        get => cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Money cannot be negative");
            }

            cost = value;
        }
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(Name)} cannot be empty");
            }

            name = value;
        }
    }
}