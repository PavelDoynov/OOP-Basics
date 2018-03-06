using System;
using System.Collections.Generic;

public class Private: Soldier, IPrivate
{
    protected decimal salary;

    public Private(int id, string firstName, string lastName, decimal salary)
        :base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public decimal Salary 
    {
        get { return salary; }
        private set
        {
            salary = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
    }
}