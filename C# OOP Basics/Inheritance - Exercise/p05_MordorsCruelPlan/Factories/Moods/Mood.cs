public abstract class Mood
{
    public int HappinessPoints { get; set; }

    protected Mood(int happinessPoints)
    {
        HappinessPoints = happinessPoints;
    }
}