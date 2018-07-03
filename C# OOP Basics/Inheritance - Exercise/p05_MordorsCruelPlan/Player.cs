using System;
using System.Collections.Generic;

public class Player
{
    private int happinessPoints = default(int);

    public void Eat(IEnumerable<Food> foods)
    {
        foreach (var food in foods)
        {
            this.happinessPoints += food.HappinessPoints;
        }
    }

    public override string ToString()
    {
        var mood = MoodFactory.GetMood(happinessPoints);

        return $"{this.happinessPoints}{Environment.NewLine}{mood.GetType().Name}";
    }
}