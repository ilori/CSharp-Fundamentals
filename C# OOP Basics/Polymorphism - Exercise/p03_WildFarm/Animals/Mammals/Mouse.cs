using System;
using System.Text;

public class Mouse : IMammal
{
    public Mouse(string name, double weight, string livingRegion)
    {
        Name = name;
        Weight = weight;
        LivingRegion = livingRegion;
    }

    public string Name { get; }
    public double Weight { get; private set; }
    public int FoodEaten { get; private set; }
    public string LivingRegion { get; }

    public void EatFood(IFood food)
    {
        if (!ValidateFood(food))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * 0.1;
        this.FoodEaten += food.Quantity;
    }

    public bool ValidateFood(IFood food)
    {
        return string.Equals(food.GetType().Name, "Vegatable", StringComparison.InvariantCulture) ||
               string.Equals(food.GetType().Name, "Fruit", StringComparison.InvariantCulture);
    }

    public string ProduceSound()
    {
        return "Squeak";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]");
        return sb.ToString().TrimEnd();
    }
}