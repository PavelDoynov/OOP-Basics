using System;
using System.Linq;

public abstract class Society : IHuman, IRobot, IBirthdate
{
    string name;
    int age;
    string model;
    string id;
    string birthdate;

    public Society()
    {
    }

    public Society(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public Society(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }

    public string Name
    {
        get { return name; }
        protected set
        {
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        protected set
        {
            age = value;
        }
    }

    public string Id
    {
        get { return id; }
        protected set
        {
            id = value;
        }
    }

    public string Model
    {
        get { return model; }
        protected set
        {
            model = value;
        }
    }

    public string Birthdate 
    {
        get { return birthdate; }
        protected set
        {
            birthdate = value;
        }
    }

    internal void PrintValidBirthdate(string birthdateYear)
    {
        if (Birthdate.EndsWith(birthdateYear))
        {
            Console.WriteLine(Birthdate);
        }
    }
}