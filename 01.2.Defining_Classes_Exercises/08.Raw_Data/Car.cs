using System;

public class Car
{
    string name;
    Engine engine;
    Cargo cargo;
    Tyres tyres;

    public Car(string name, Engine engine, Cargo cargo, Tyres tyres)
    {
        this.name = name;
        this.engine = engine;
        this.cargo = cargo;
        this.tyres = tyres;
    }

    public string Name
    {
        get { return name; }
    }

    public Engine Engine
    {
        get { return engine; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
    }

    public Tyres Tyres
    {
        get { return tyres; }
    }
}