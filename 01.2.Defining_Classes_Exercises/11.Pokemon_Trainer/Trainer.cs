using System;
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public int badges = 0;
    public string name;
    public List<Pokemon> pokemon = new List<Pokemon>();

    public Trainer(string name, Pokemon currentPokemon)
    {
        this.name = name;
        this.pokemon.Add(currentPokemon);
    }

    public Pokemon Pokemon
    {
        set { pokemon.Add(value); }
    }

    internal void CurrentElement(string tournamentArgs)
    {
        if (this.pokemon.Select(x => x.pokemonElement).ToList().Contains(tournamentArgs))
        {
            this.badges++;
        }
        else
        {
            for (int pokemonIndex = 0; pokemonIndex < this.pokemon.Count(); pokemonIndex++)
            {
                this.pokemon[pokemonIndex].pokemonHealth -= 10;
                if (this.pokemon[pokemonIndex].pokemonHealth <= 0)
                {
                    this.pokemon.RemoveAt(pokemonIndex);
                }
            }
        }
    }
}