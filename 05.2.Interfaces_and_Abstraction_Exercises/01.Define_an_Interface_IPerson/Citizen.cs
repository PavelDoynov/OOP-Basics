using System;

public class Citizen:IPerson
{
    string name;
    int age;

    public Citizen(string name, int age)
    {
        Name = name;
        Age = age;
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
}