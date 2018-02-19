using System;

public class StreetExtraordinaire : Cat
{
    int decibelsOfMeows;

    public int DecibelsOfMeows
    {
        get { return decibelsOfMeows; }
        set { decibelsOfMeows = value; }
    }

    public StreetExtraordinaire (string name, int decibelsOfMeows)
        :base(name)
    {
        this.decibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {Name} {DecibelsOfMeows}";
    }
}