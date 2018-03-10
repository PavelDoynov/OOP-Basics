using System;

public class EarthBender : Bender
{
    double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return this.groundSaturation; }
        private set
        {
            this.groundSaturation = value;
        }
    }

    public override double GetTotalPower()
    {
        double totalPower = base.Power * this.GroundSaturation;
        return totalPower;
    }

    public override string ToString()
    {
        return $"###Earth Bender: {base.ToString()} Ground Saturation: {this.GroundSaturation:f2}";
    }
}