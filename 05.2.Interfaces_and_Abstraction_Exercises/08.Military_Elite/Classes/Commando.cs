using System;
using System.Collections.Generic;
using System.Text;

public class Commando:SpecialisedSoldier, ICommando
{
    protected List<string[]> missions = new List<string[]>();

    public Commando(int id, string firstName, string lastName, decimal salary, string corps)
        :base(id, firstName, lastName, salary, corps)
    {
    }

    public Commando(int id, string firstName, string lastName, decimal salary, string corps, List<string[]> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public List<string[]> Missions 
    {
        get { return missions; }
        private set
        {
            missions = value;
        }
    }

    public override string ToString()
    {
        if (this.Missions.Count == 0)
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}" +
                $"\nCorps: {this.Corps}" +
                "\nMissions:";
        }
        else
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}" +
                $"\nCorps: {this.Corps}" +
                "\nMissions:");

            foreach (string[] currentMision in this.Missions)
            {
                result.Append($"\n  Code Name: {currentMision[0]} State: {currentMision[1]}");
            }

            return result.ToString();
        }
    }
}