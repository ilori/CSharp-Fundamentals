using System.Collections.Generic;

public interface IWeapon
{
    string Name { get; }

    int BaseMinDamage { get; }

    int BaseMaxDamage { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    WeaponRarity Rarity { get; }

    IReadOnlyCollection<IGem> Sockets { get; }

    void AddGem(int index, IGem gem);

    void RemoveGem(int index);
}