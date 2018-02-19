using System;

public class Cat
{
    string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Cat (string name)
    {
        this.name = name;
    }

}