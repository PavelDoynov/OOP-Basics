﻿using System;

public class EarthMonument : Monument
{
    int earthAffinity;

    public EarthMonument(string name, int earthAffinity) 
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    private int EarthAffinity
    {
        get { return this.earthAffinity; }
        set
        {
            this.earthAffinity = value;
        }
    }

    public override double GetMonumentBonus()
    {
        return this.EarthAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}Earth Affinity: {this.EarthAffinity}";
    }
}