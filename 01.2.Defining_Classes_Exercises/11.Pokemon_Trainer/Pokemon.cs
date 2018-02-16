using System;

public class Pokemon
{
    string pokemonName;
    public string pokemonElement;
    public int pokemonHealth;

    public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
    {
        this.pokemonName = pokemonName;
        this.pokemonElement = pokemonElement;
        this.pokemonHealth = pokemonHealth;
    }
}
