using System;

public abstract class Soldier : ISoldier
{ 
    protected int id;
    protected string firstName;
    protected string lastName;
    
    public Soldier(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public int Id 
    {
        get { return id; }
        private set
        {
            id = value;
        }
    }

    public string FirstName 
    { 
        get { return firstName; }
        private set 
        {
            firstName = value;
        }
    }

    public string LastName 
    { 
        get { return lastName; }
        private set
        {
            lastName = value;
        }
    }

    public abstract override string ToString();
}