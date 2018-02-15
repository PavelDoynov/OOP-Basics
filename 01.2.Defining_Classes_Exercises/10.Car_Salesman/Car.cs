using System;

public class Car
{
    string model;
    Engine engine;
    string weight;
    string color;

    public Car()
    {
        this.Weight = "n/a";
        this.Color = "n/a";
    }

    public Car(string weight) :this()
    {
        this.Weight = weight;
    }

    public Car(string weight, string color) : this(weight)
    {
        this.Color = color;
    }

    public string Model
    {
        set { model = value; }
    }

    public Engine Engine
    {
        set { engine = value; }
    }

    public string Weight
    {
        set { weight = value; }
    }

    public string Color
    {
        set { color = value; }
    }

    public override string ToString()
    {
        return $"{this.model}:\n  {this.engine.Model}:\n    Power: {this.engine.Power}\n    Displacement: {this.engine.Displacement}\n    " +
            $"Efficiency: {this.engine.Efficiency}\n  Weight: {this.weight}\n  Color: {this.color}";
    }
}
