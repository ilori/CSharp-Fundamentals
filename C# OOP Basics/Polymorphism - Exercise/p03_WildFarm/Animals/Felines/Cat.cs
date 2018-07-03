using System;
using System.Text;

public class Cat : IMammal
{
    public Cat(string name, double weight, string livingRegion, string breed)
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
    public string Breed { get; set; }


    public void EatFood(IFood food)
    {
        if (!ValidateFood(food))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * 0.3;
        this.FoodEaten += food.Quantity;
    }

    public bool ValidateFood(IFood food)
    {
        return string.Equals(food.GetType().Name, "Vegetable", StringComparison.InvariantCulture) ||
               string.Equals(food.GetType().Name, "Meat", StringComparison.InvariantCulture);
    }


    public string ProduceSound()
    {
        return "Meow";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(
            $"{this.GetType().Name} [{this.Name}, {Breed}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]");

        return sb.ToString().TrimEnd();
    }
}