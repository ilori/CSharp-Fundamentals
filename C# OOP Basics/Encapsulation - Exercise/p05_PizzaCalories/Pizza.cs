using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    public Pizza(string name)
    {
        Name = name;
    }

    private string name;
    private Dough dough;
    private IReadOnlyCollection<Topping> toppings = new List<Topping>();
    public double Calories => PizzaCalories();


    public Dough Dough
    {
        get => dough;
        set => dough = value;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15 ||
                value.Length < 1)
            {
                throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    public IReadOnlyCollection<Topping> Toppings
    {
        get => toppings;
        set
        {
            if (value.Count < 0 || value.Count > 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }

            toppings = value;
        }
    }

    private double PizzaCalories()
    {
        return Dough.Calories + Toppings.Sum(x => x.Calories);
    }

    public override string ToString()
    {
        return $"{Name} - {Calories:F2} Calories.";
    }
}