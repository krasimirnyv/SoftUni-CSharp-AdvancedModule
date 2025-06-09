namespace PokemonTrainer;

public class Trainer
{
    public Trainer(string name, int badgesNumber, List<Pokemon> pokemons)
    {
        Name = name;
        BadgesNumber = badgesNumber;
        Pokemons = pokemons;
    }

    public string Name { get; set; }
    public int BadgesNumber { get; set; }
    public List<Pokemon> Pokemons { get; set; }
}