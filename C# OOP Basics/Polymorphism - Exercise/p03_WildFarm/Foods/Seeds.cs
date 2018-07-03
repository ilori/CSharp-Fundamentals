public class Seeds : IFood
{
    public Seeds(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity { get; }
}