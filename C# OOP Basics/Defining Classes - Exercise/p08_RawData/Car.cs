using System.Collections.Generic;

public class Car
{
    public Car(string model, Engine engine, Cargo cargo, ICollection<Tire> tires)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tires = tires;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public ICollection<Tire> Tires { get; set; }


    public override string ToString()
    {
        return $"{this.Model}";
    }
}