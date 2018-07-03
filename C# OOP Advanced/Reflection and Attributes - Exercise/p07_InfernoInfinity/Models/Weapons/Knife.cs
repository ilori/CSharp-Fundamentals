public class Knife : Weapon
{
    private const int MinimumDamage = 3;
    private const int MaximumDamage = 4;
    private const int NumberOfSockets = 2;

    public Knife(string name, string rarity) : base(name, rarity,
        MinimumDamage, MaximumDamage, NumberOfSockets)
    {
    }
}