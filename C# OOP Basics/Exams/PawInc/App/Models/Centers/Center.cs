using System.Collections.Generic;

public abstract class Center
{
    protected Center(string name)
    {
        this.Name = name;
        this.Animals = new List<Animal>();
    }

    public string Name { get; protected set; }

    public List<Animal> Animals { get; protected set; }
}