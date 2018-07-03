using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();


        var trainers = new Dictionary<string, Trainer>();

        while (input != "Tournament")
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var trainerName = tokens[0];

            var pokemonName = tokens[1];

            var pokemonElement = tokens[2];

            var pokemonHealth = int.Parse(tokens[3]);

            var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers[trainerName] = new Trainer()
                {
                    Name = trainerName
                };
            }

            trainers[trainerName].Pokemons.Add(pokemon);

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "End")
        {
            foreach (var trainer in trainers.Values)
            {
                if (trainer.Pokemons.Any(x => x.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }

                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                }
            }

            input = Console.ReadLine();
        }

        foreach (var trainer in trainers.Values.OrderByDescending(x => x.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}