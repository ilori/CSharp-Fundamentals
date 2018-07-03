using System;

public class Topping
{
    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    private string type;
    private double weight;
    public double Calories => CalcolateCalories();


    public double Weight
    {
        get => weight;
        private set
        {
            if (value > 50 || value < 1)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }

            weight = value;
        }
    }


    public string Type
    {
        get => type;
        private set
        {
            if (!Enum.TryParse<ToppingType>(value, true, out var _))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            type = value;
        }
    }


    private double CalcolateCalories()
    {
        var baseCalories = 2d;

        switch (Type.ToLower())
        {
            case "meat":
                baseCalories *= Modifiers.Meat;
                break;
            case "veggies":
                baseCalories *= Modifiers.Veggies;
                break;
            case "cheese":
                baseCalories *= Modifiers.Cheese;
                break;
            case "sauce":
                baseCalories *= Modifiers.Sauce;
                break;
        }

        baseCalories *= Weight;
        return baseCalories;
    }
}