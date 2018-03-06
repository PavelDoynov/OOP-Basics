using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{

    protected List<Private> privateList;

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary, List<Private> currentPrivates)
        :base(id, firstName, lastName, salary)
    {
        this.PrivateList = currentPrivates;
    }

    public List<Private> PrivateList 
    {
        get { return privateList; }
        private set
        {
            privateList = value;
        }
    }

    public override string ToString()
    {
        StringBuilder currentResult = new StringBuilder();
        currentResult.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}" +
                             "\nPrivates:");

        foreach (Private privateSoldier in this.PrivateList)
        {
            currentResult.Append($"\n  Name: {privateSoldier.FirstName} {privateSoldier.LastName} " +
                                 $"Id: {privateSoldier.Id} Salary: {privateSoldier.Salary:f2}");
        }

        return currentResult.ToString();
    }
}