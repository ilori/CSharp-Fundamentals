public class Ruby : Gem
{
    public const int BaseStrenght = 7;
    public const int BaseAgility = 2;
    public const int BaseVitality = 5;

    public Ruby(string quality) : base(BaseStrenght, BaseAgility, BaseVitality,
        quality)
    {
        this.Strength += (int) this.Quality;
        this.Agility += (int) this.Quality;
        this.Vitality += (int) this.Quality;
    }
}