public class Amethyst : Gem
{
    public const int BaseStrenght = 2;
    public const int BaseAgility = 8;
    public const int BaseVitality = 4;

    public Amethyst(string quality) : base(BaseStrenght, BaseAgility, BaseVitality, quality)
    {
        this.Strength += (int) this.Quality;
        this.Agility += (int) this.Quality;
        this.Vitality += (int) this.Quality;
    }
}