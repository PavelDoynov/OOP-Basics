using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender (Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonuments (Monument monument)
    {
        this.monuments.Add(monument);
    }

    public double GetTotalPoints()
    {
        double powerBenders = this.benders.Sum(p => p.GetTotalPower());
        double powerMonumets = this.monuments.Sum(p => p.GetMonumentBonus());

        double resultPower = powerBenders += powerBenders / 100 * powerMonumets;

        return resultPower;
    }

	public override string ToString()
	{
        StringBuilder result = new StringBuilder();

        if (benders.Count > 0)
        {
            result.Append("Benders:");

            foreach (var bender in benders)
            {
                result.Append(Environment.NewLine + $"{bender}");
            }
        }
        else
        {
            result.Append("Benders: None");
        }

        if (monuments.Count > 0)
        {
            result.Append(Environment.NewLine + "Monuments:");

            foreach (var monument in monuments)
            {
                result.Append(Environment.NewLine + $"{monument}");
            }
        }
        else
        {
            result.Append(Environment.NewLine + "Monuments: None");
        }

        return result.ToString();
	}

    internal void DeleteNation()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}