public interface ICar
{
    string Model { get; }
    Driver Driver { get; }
    string Brake();
    string Gas();
}