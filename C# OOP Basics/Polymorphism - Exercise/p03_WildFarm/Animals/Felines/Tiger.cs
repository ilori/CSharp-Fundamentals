using System;
using System.Text;

public class Tiger : IMammal
{
    public Tiger(string name, double weight, string livingRegion, string breed)
    {
        Name = name;
        Weight = weight;
        LivingRegion = livingRegion;
        Breed = breed;
    }

    public string Name { get; }
    public double Weight { get; private set; }
    public int FoodEaten { get; private set; }
    public string LivingRegion { get; }
    public string Breed { get; }


    public void EatFood(IFood food)
    {
        if (!ValidateFood(food))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * 1;
        this.FoodEaten += food.Quantity;
    }

    public bool ValidateFood(IFood food)
    {
        return string.Equals(food.GetType().Name, "Meat", StringComparison.InvariantCulture);
    }


    public string ProduceSound()
    {
        return "ROAR!!!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(
            $"{this.GetType().Name} [{this.Name}, {Breed}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]");

        return sb.ToString().TrimEnd();
    }
}