public static class MoodFactory
{
    private const int AngryMood = -5;
    private const int SadMood = 0;
    private const int HappyMood = 15;

    public static Mood GetMood(int happinessPoints)
    {
        if (happinessPoints < AngryMood)
        {
            return new Angry(happinessPoints);
        }
        else if (happinessPoints >= AngryMood && happinessPoints <= SadMood)
        {
            return new Sad(happinessPoints);
        }
        else if (happinessPoints > SadMood && happinessPoints <= HappyMood)
        {
            return new Happy(happinessPoints);
        }
        else
        {
            return new JavaScript(happinessPoints);
        }
    }
}