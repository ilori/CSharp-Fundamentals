using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Weapon : IWeapon
{
    private IGem[] gems;

    protected Weapon(string name, string rarity, int baseMinDamage, int baseMaxDamage, int baseSockets)
    {
        this.gems = new IGem[baseSockets];

        this.Name = name;

        this.Rarity = Enum.Parse<WeaponRarity>(rarity,true);

        this.BaseMinDamage = baseMinDamage;

        this.BaseMaxDamage = baseMaxDamage;
    }

    public string Name { get; }

    public int BaseMinDamage { get; }

    public int BaseMaxDamage { get; }

    public int MinDamage
    {
        get
        {
            return this.BaseMinDamage * (int) this.Rarity + this.Sockets.Where(x => x != null)
                       .Sum(x => x.Strength * (int) WeaponModifiers.StrenghtMinDamage +
                                 x.Agility * (int) WeaponModifiers.AgilityMinDamage);
        }
    }

    public int MaxDamage
    {
        get
        {
            return this.BaseMaxDamage * (int) this.Rarity + this.Sockets.Where(x => x != null)
                       .Sum(x => x.Strength * (int) WeaponModifiers.StrenghtMaxDamage +
                                 x.Agility * (int) WeaponModifiers.AgilityMaxDamage);
        }
    }

    public WeaponRarity Rarity { get; }

    public IReadOnlyCollection<IGem> Sockets => gems;

    public void AddGem(int index, IGem gem)
    {
        if (index >= 0 && index < this.Sockets.Count)
        {
            this.gems[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < this.Sockets.Count)
        {
            this.gems[index] = null;
        }
    }

    public override string ToString()
    {
        int strength = this.Sockets
            .Where(g => g != null)
            .Sum(g => g.Strength);

        int agility = this.Sockets
            .Where(g => g != null)
            .Sum(g => g.Agility);

        int vitality = this.Sockets
            .Where(g => g != null)
            .Sum(g => g.Vitality);

        return
            $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}