using System;

public abstract class Animal : ISoundProducable
{
    string name;
    int age;
    string gender;

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            Validate.ValidateStringArgs(value);
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            Validate.ValidateNumbers(value);
            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            Validate.ValidateStringArgs(value);
            gender = value;
        }
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        return $"{this.GetType().Name}\n{Name} {Age} {Gender}\n{ProduceSound()}";
    }
}