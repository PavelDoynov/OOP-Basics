using System;

public class Spy : Soldier, ISpy
{
    protected int codeNumber;

    public Spy(int id, string firstName, string lastName, int codeNumber)
        :base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber 
    {
        get { return codeNumber; }
        protected set 
        {
            codeNumber = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} \nCode Number: {this.CodeNumber}";
    }
}