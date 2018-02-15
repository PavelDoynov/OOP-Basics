using System;

public class Pokemon
{
    string pokemonName;
    string pokemonElement;
    int pokemonHealth;

    public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
    {
        this.pokemonName = pokemonName;
        this.pokemonElement = pokemonElement;
        this.pokemonHealth = pokemonHealth;
    }

    public string Name
    {
        get { return pokemonName; }
    }

    public string Element
    {
        get { return pokemonElement; }
    }

    public int Health
    {
        get { return pokemonHealth; }
        set { pokemonHealth = value; }
    }
}
