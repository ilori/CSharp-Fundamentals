using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    private string name;
    private decimal money;
    private List<Product> products;

    public IReadOnlyCollection<Product> Products => products;


    public decimal Money
    {
        get => money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(Money)} cannot be negative");
            }

            money = value;
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

    public string AddProduct(Product product)
    {
        if (this.Money - product.Cost >= 0)
        {
            products.Add(product);
            this.Money -= product.Cost;
            return $"{this.Name} bought {product.Name}";
        }

        return $"{this.Name} can't afford {product.Name}";
    }

    public override string ToString()
    {
        return $"{this.Name} - {string.Join(", ", this.Products.Select(x => x.Name))}";
    }
}