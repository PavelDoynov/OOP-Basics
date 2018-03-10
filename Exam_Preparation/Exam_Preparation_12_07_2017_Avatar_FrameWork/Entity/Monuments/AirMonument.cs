using System;

public class AirMonument : Monument
{
    int airAffinity;

    public AirMonument(string name, int airAffinity) 
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    private int AirAffinity
    {
        get { return this.airAffinity; }
        set
        {
            this.airAffinity = value;
        }
    }

    public override double GetMonumentBonus()
    {
        return this.AirAffinity;
    }

	public override string ToString()
	{
        return $"{base.ToString()}Air Affinity: {this.AirAffinity}";
	}
}