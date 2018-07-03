public class Vegetable : IFood
{
    public Vegetable(int quantity)
    {
        Quantity = quantity;
    }
    public int Quantity { get; }
}