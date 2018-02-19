using System;

public class Parents
{
    public string name;
    public string birthday;

    public Parents(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{name} {birthday}";
    }
}