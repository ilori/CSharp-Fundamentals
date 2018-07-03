public class Sword : Weapon
{
    private const int MinimumDamage = 4;
    private const int MaximumDamage = 6;
    private const int NumberOfSockets = 3;


    public Sword(string name, string rarity) : base(name, rarity,
        MinimumDamage, MaximumDamage, NumberOfSockets)
    {
    }
}