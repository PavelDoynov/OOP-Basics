using System;
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    string name;
    int badges = 0;
    List<Pokemon> pokemon = new List<Pokemon>();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Pokemon Pokemon
    {
        set { pokemon.Add(value); }
    }

    public List<Pokemon> PokemonList
    {
        get { return pokemon; }
    }

    public int Badges
    {
        get { return badges; }
    }

    internal void CurrentElement(string tournamentArgs)
    {
        if (this.PokemonList.Select(x => x.Element).ToList().Contains(tournamentArgs))
        {
            this.badges++;
        }
        else
        {
            for (int pokemonIndex = 0; pokemonIndex < this.PokemonList.Count(); pokemonIndex++)
            {
                if (this.PokemonList[pokemonIndex].Health <= 0)
                {
                    this.PokemonList.RemoveAt(pokemonIndex);
                }
                else 
                {
                    this.PokemonList[pokemonIndex].Health -= 10;
                    if (this.PokemonList[pokemonIndex].Health <= 0)
                    {
                        this.PokemonList.RemoveAt(pokemonIndex);
                    }
                }
            }
        }
    }
}