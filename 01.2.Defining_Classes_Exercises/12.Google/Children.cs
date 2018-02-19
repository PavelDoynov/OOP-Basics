using System;

public class Children
{
    public string name;
    public string birthday;

    public Children(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{name} {birthday}";
    }
}
