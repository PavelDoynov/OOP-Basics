using System;

public class WaterMonument : Monument
{
    int waterAffinity;

    public WaterMonument(string name, int waterAffinity) 
        : base(name)
    {
        this.WaterAffinity = waterAffinity;  
    }

    private int WaterAffinity
    {
        get { return this.waterAffinity; } 
        set
        {
            this.waterAffinity = value;
        }
    }

    public override double GetMonumentBonus()
    {
        return this.WaterAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}Water Affinity: {this.WaterAffinity}";
    }
}