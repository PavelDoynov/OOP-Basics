using System;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    string name;
    int age;
    string id;
    string birthdate;

    public Citizen(string name, int age, string id, string birthday)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthday;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            age = value;
        }
    }

    public string Id
    {
        get { return id; }
        private set
        {
            id = value;
        }
    }

    public string Birthdate
    {
        get { return birthdate; }
        private set 
        {
            birthdate = value;
        }
    }
}