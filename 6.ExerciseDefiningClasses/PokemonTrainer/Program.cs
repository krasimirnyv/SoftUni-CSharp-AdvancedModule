namespace PokemonTrainer;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
        string command = default;
        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string trainerName = tokens[0],
                   pokemonName = tokens[1],
                   pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            if (!trainers.ContainsKey(trainerName))
                trainers[trainerName] = new Trainer(trainerName, 0, new List<Pokemon>());
            
            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            trainers[trainerName].Pokemons.Add(pokemon);
        }

        while ((command = Console.ReadLine()) != "End")
        {
            foreach (Trainer trainer in trainers.Values)
            {
                ProcessCommand(command, trainer);
            }
        }

        foreach (Trainer trainer in trainers.Values.OrderByDescending(t => t.BadgesNumber))
        {
            Console.WriteLine($"{trainer.Name} {trainer.BadgesNumber} {trainer.Pokemons.Count}");
        }
    }

    private static void ProcessCommand(string command, Trainer trainer)
    {
        if (trainer.Pokemons.Any(p => p.Element == command))
            trainer.BadgesNumber++;
        else
        {
            for (int i = trainer.Pokemons.Count - 1; i >= 0; i--)
            {
                trainer.Pokemons[i].Health -= 10;
                if (trainer.Pokemons[i].Health <= 0) 
                    trainer.Pokemons.RemoveAt(i);
            }
        }
    }
}
