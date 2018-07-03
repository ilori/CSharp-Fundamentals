using System;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps) : base(id,
        firstName,
        lastName, salary)
    {
        ParseCorpse(corps);
    }

    private void ParseCorpse(string corps)
    {
        var validCorps = Enum.TryParse<Corps>(corps, out var outCorps);
        if (!validCorps)
        {
            throw new ArgumentException("Invalid corps!");
        }

        Corps = outCorps;
    }

    public Corps Corps { get; private set; }
}