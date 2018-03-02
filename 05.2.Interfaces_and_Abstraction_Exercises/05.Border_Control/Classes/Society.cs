using System;
using System.Linq;

public abstract class Society : IHuman, IRobot
{
    string name;
    int age;
    string model;
    string id;

    public Society(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public Society(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
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

    internal void PrintFakeID(string fakeIdNumbers)
    {
        char[] idDigits = Id.ToCharArray()
                            .Reverse()
                            .Take(fakeIdNumbers.Length)
                            .ToArray()
                            .Reverse()
                            .ToArray();

        bool isEqual = true;

        for (int i = 0; i < fakeIdNumbers.Length; i++)
        {
            if (fakeIdNumbers[i] != idDigits[i])
            {
                isEqual = false;
                break;
            }
        }

        if (isEqual)
        {
            Console.WriteLine(Id);
        }
    }
}