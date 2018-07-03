using System;
using System.Text;

public class Owl : IBird
{
    public Owl(string name, double weight, double wingSize)
    {
        Name = name;
        Weight = weight;
        WingSize = wingSize;
    }

    public string Name { get; }
    public double Weight { get; private set; }
    public int FoodEaten { get; private set; }
    public double WingSize { get; }

    public void EatFood(IFood food)
    {
        if (!ValidateFood(food))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * 0.25;
        this.FoodEaten += food.Quantity;
    }

    public bool ValidateFood(IFood food)
    {
        return string.Equals(food.GetType().Name, "Meat", StringComparison.InvariantCulture);
    }


    public string ProduceSound()
    {
        return "Hoot Hoot";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {FoodEaten}]");

        return sb.ToString().TrimEnd();
    }
}