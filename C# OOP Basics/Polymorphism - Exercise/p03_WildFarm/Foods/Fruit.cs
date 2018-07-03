public class Fruit : IFood
{
    public Fruit(int quantity)
    {
        Quantity = quantity;
    }
    public int Quantity { get; }
}