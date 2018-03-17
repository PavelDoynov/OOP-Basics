using System;
using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    List<string> addOns;

    public PerformanceCar(int id, string brand, string model, int yearOfProduction, int horsepower, int acceleration, 
                             int suspension, int durability) 
        : base(id, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        addOns = new List<string>();
        this.AddOns = this.addOns;
        this.Horsepower = horsepower + (horsepower * 50) / 100;
        this.Suspension = suspension - (suspension * 25) / 100;
    }

    public List<string> AddOns { get; private set; }

	internal override void AddOnAndStats(int tuneIndex, string addOn)
	{
        this.Horsepower += tuneIndex;
        this.Suspension += (tuneIndex / 2);
        this.AddOns.Add(addOn);
	}

	public override string ToString()
	{
        StringBuilder result = new StringBuilder();
        result.Append("Add-ons: ");

        if (this.AddOns.Count != 0)
        {
            result.Append($"{string.Join(", ", this.AddOns)}");
        }
        else
        {
            result.Append("None");
        }

        return base.ToString() + Environment.NewLine + result.ToString();
	}
}