using System;
using System.Collections.Generic;

public class Person
{
    public string name;
    public Company compnany;
    public Car car;
    public List<Pokemon> pokemons;
    public List<Parents> parents;
    public List<Children> childrens;

    public Person(string name)
    {
        this.name = name;
        compnany = null;
        car = null;
        pokemons = new List<Pokemon>();
        parents = new List<Parents>();
        childrens = new List<Children>();
    }
}
