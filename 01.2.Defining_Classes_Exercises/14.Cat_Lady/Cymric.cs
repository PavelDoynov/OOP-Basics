using System;

public class Cymric : Cat
{
    decimal furLength;

    public decimal FurLength
    {
        get { return furLength; }
        set { furLength = value; }
    }

    public Cymric (string name, decimal furLength)
        :base(name)
    {
        this.furLength = furLength;
    }

    public override string ToString()
    {
        return $"Cymric {Name} {FurLength:f2}";
    }
}