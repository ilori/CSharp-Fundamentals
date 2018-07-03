using System;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string weaponName, string weaponRarity, string weaponType)
    {
        Type type = Type.GetType(weaponType);

        if (type == null)
        {
            throw new ArgumentException("No such weapon!");
        }

        if (!typeof(IWeapon).IsAssignableFrom(type))
        {
            throw new ArgumentException($"Invalid Weapon Type {weaponType}!");
        }

        IWeapon instance = (IWeapon) Activator.CreateInstance(type, weaponName, weaponRarity);

        return instance;
    }
}