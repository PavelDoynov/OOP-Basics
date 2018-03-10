using System;

public class FireMonument : Monument
{
    int fireAffinity;

    public FireMonument(string name, int fireAffinity) 
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    private int FireAffinity
    {
        get { return this.fireAffinity; }
        set
        {
            this.fireAffinity = value;
        }
    }

    public override double GetMonumentBonus()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}Fire Affinity: {this.FireAffinity}";
    }
}
