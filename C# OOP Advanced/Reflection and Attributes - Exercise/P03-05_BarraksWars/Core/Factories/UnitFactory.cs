using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        Type type = Type.GetType(unitType);

        return (IUnit) Activator.CreateInstance(type);
    }
}