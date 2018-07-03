using System.Collections.Generic;

public class Trainer
{
    public string Name { get; set; }

    public int Badges { get; set; }

    public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}