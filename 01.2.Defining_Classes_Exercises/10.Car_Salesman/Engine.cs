using System;

public class Engine
{
    string model;
    string power;
    string displacement;
    string efficiency;

    public Engine()
    {
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }

    public Engine(string displacement):this()
    {
        this.Displacement = displacement;
    }

    public Engine(string displacement, string efficiency) : this(displacement)
    {
        this.Efficiency = efficiency;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Power
    {
        get { return power; }
        set { power = value; }
    }

    public string Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }

    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }
}
