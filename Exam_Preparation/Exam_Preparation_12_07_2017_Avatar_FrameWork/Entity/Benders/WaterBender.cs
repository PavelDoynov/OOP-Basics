using System;

public class WaterBender : Bender
{
    double waterClarity;

    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return this.waterClarity; }
        private set
        {
            this.waterClarity = value;
        }
    }

    public override double GetTotalPower()
    {
        double totalPower = base.Power * this.WaterClarity;
        return totalPower;
    }

    public override string ToString()
    {
        return $"###Water Bender: {base.ToString()} Water Clarity: {this.WaterClarity:f2}";
    }
}