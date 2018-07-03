public class Axe : Weapon
{
    private const int MinimumDamage = 5;
    private const int MaximumDamage = 10;
    private const int NumberOfSockets = 4;


    public Axe(string name, string rarity) : base(name, rarity,
        MinimumDamage, MaximumDamage, NumberOfSockets)
    {
    }
}