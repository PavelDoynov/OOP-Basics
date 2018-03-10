using System;

public class FireBender : Bender
{
    double heatAggression;

    public FireBender(string name, int power, double heatAggression) 
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return this.heatAggression; }
        private set
        {
            this.heatAggression = value;
        }
    }

    public override double GetTotalPower()
    {
        double totalPower = base.Power * this.HeatAggression;
        return totalPower;
    }

    public override string ToString()
    {
        return $"###Fire Bender: {base.ToString()} Heat Aggression: {this.HeatAggression:f2}";
    }
}