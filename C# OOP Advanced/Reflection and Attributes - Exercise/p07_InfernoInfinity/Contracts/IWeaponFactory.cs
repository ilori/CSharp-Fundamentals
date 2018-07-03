public interface IWeaponFactory
{
    IWeapon CreateWeapon(string weaponName, string weaponRarity, string weaponType);
}