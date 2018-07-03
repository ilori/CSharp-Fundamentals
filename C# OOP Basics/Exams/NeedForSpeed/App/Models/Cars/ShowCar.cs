public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration,
        int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension,
        durability)
    {
    }

    public int Stars { get; set; }

    public override string ToString()
    {
        var sb = base.ToString();
        sb += $"{this.Stars} *";

        return sb;
    }
}