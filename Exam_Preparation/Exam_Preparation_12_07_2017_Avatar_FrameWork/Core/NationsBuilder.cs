using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> wars;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation()},
            {"Earth", new Nation()},
            {"Fire", new Nation()},
            {"Water", new Nation()}
        };

        this.wars = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double specialPower = double.Parse(benderArgs[3]);

        if (type == "Air")
        {
            nations[type].AddBender(new AirBender(name, power, specialPower));
        }
        else if (type == "Earth")
        {
            nations[type].AddBender(new EarthBender(name, power, specialPower));
        }
        else if (type == "Fire")
        {
            nations[type].AddBender(new FireBender(name, power, specialPower));
        }
        else if (type == "Water")
        {
            nations[type].AddBender(new WaterBender(name, power, specialPower));
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        if (type == "Air")
        {
            nations[type].AddMonuments(new AirMonument(name, affinity));
        }
        else if (type == "Earth")
        {
            nations[type].AddMonuments(new EarthMonument(name, affinity));
        }
        else if (type == "Fire")
        {
            nations[type].AddMonuments(new FireMonument(name, affinity));
        }
        else if (type == "Water")
        {
            nations[type].AddMonuments(new WaterMonument(name, affinity));
        }
    }
    public string GetStatus(string nationsType)
    {
        string resultStatus = $"{nationsType} Nation" + Environment.NewLine + $"{nations[nationsType].ToString()}";
        return resultStatus;
    }
    public void IssueWar(string nationsType)
    {
        this.wars.Add(nationsType);
        double warResult = nations.Max(p => p.Value.GetTotalPoints());

        foreach (var nation in nations)
        {
            if (nation.Value.GetTotalPoints() != warResult)
            {
                nation.Value.DeleteNation();
            }
        }
    }
    public string GetWarsRecord()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < this.wars.Count; i++)
        {
            result.AppendLine($"War {i + 1} issued by {this.wars[i]}");
        }

        return result.ToString();
    }

}