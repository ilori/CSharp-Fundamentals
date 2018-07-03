using System;
using System.Text;

public class Hen : IBird
{
    public Hen(string name, double weight, double wingSize)
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
        this.Weight += food.Quantity * 0.35;
        this.FoodEaten += food.Quantity;
    }

    public bool ValidateFood(IFood food)
    {
        return true;
    }

    public string ProduceSound()
    {
        return "Cluck";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {FoodEaten}]");

        return sb.ToString().TrimEnd();
    }
}