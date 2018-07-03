using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }

    public Company Company { get; set; }

    public Car Car { get; set; }

    public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

    public List<Parent> Parents { get; set; } = new List<Parent>();

    public List<Children> Childrens { get; set; } = new List<Children>();
}