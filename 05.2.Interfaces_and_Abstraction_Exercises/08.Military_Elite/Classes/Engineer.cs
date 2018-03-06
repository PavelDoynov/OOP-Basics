using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    protected List<string[]> repairs = new List<string[]>();

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
        :base (id, firstName, lastName, salary, corps)
    {
    }

    public Engineer (int id, string firstName, string lastName, decimal salary, 
                     string corps, List<string[]> repairs)
        :base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public List<string[]> Repairs
    {
        get { return repairs; }
        protected set
        {
            repairs = value;
        }
    }

    public override string ToString()  
    {
        if (this.Repairs.Count == 0)
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}" +
                $"\nCorps: {this.Corps}" +
                "\nRepairs:";
        }
        else 
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}" +
                $"\nCorps: {this.Corps}" +
                $"\nRepairs:");

            foreach (var item in this.Repairs)
            {
                result.Append($"\n  Part Name: {item[0]} Hours Worked: {item[1]}");
            }

            return result.ToString();
        }
    }
}