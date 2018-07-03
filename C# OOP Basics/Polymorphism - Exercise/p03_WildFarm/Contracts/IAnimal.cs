public interface IAnimal
{
    string Name { get; }
    double Weight { get; }
    int FoodEaten { get; }
    void EatFood(IFood food);
    bool ValidateFood(IFood food);
    string ProduceSound();
}