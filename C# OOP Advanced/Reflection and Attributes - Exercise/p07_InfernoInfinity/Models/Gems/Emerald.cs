public class Emerald : Gem
{
    public const int BaseStrenght = 1;
    public const int BaseAgility = 4;
    public const int BaseVitality = 9;


    public Emerald(string quality) : base(BaseStrenght, BaseAgility, BaseVitality, quality)
    {
        this.Strength += (int) this.Quality;
        this.Agility += (int) this.Quality;
        this.Vitality += (int) this.Quality;
    }
}