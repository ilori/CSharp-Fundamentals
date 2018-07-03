using System;

public abstract class Gem : IGem
{
    protected Gem(int strength, int agility, int vitality, string quality)
    {
        this.Strength = strength;
        this.Agility = agility;
        this.Vitality = vitality;
        this.Quality = Enum.Parse<GemQuality>(quality, true);
    }

    public int Strength { get; protected set; }

    public int Agility { get; protected set; }

    public int Vitality { get; protected set; }

    public GemQuality Quality { get; protected set; }
}