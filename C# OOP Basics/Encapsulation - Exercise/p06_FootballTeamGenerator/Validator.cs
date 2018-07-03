public static class Validator
{
    public const string InvalidNameMessage = "A name should not be empty.";
    public const string InvalidStatsMessage = "{0} should be between 0 and 100.";
    public const string MissingPlayerMessage = "Player {0} is not in {1} team.";
    public const string MissingTeamMessage = "Team {0} does not exist.";


    public static bool IsNameValid(string name)
    {
        return !string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name);
    }

    public static bool IsStatsValid(int stat)
    {
        return stat >= 0 && stat <= 100;
    }
}