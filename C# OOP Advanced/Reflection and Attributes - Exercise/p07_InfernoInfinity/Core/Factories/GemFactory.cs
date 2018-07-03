using System;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(string gemQuality, string gemType)
    {
        Type type = Type.GetType(gemType);

        if (type == null)
        {
            throw new ArgumentException("No such gem!");
        }

        if (!typeof(IGem).IsAssignableFrom(type))
        {
            throw new ArgumentException($"Invalid Gem Type {gemType}!");
        }

        IGem instance = (IGem) Activator.CreateInstance(type, gemQuality);

        return instance;
    }
}