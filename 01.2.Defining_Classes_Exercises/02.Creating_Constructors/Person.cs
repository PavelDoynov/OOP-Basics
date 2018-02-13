using System;

public class Person
{
    private int age;
    private string name;

    public Person()
    {
        this.Age = 1;
        this.Name = "No name";
    }

    public Person(int age): this()
    {
        this.Age = age;
    }

    public Person(int age, string name) : this(age)
    {
        this.Name = name;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}