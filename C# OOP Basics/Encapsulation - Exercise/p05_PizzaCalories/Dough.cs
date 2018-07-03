using System;

public class Dough
{
    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }


    private string flourType;
    private string bakingTechnique;
    private double weight;

    public double Calories => CalculeateCalories();

    public string FlourType
    {
        get => flourType;
        private set
        {
            if (!Enum.TryParse<FlourType>(value, true, out var _))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get => bakingTechnique;
        private set
        {
            if (!Enum.TryParse<BakingTechnique>(value, true, out var _))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get => weight;
        private set
        {
            if (value > 200 || value < 1)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }


    private double CalculeateCalories()
    {
        var baseCalories = 2d;

        switch (FlourType.ToLower())
        {
            case "white":
                baseCalories *= Modifiers.White;
                break;
            case "wholegrain":
                baseCalories *= Modifiers.WholeGrain;
                break;
        }

        switch (BakingTechnique.ToLower())
        {
            case "crispy":
                baseCalories *= Modifiers.Crispy;
                break;
            case "chewy":
                baseCalories *= Modifiers.Chewy;
                break;
            case "homemade":
                baseCalories *= Modifiers.Homemade;
                break;
        }

        baseCalories *= Weight;
        return baseCalories;
    }
}