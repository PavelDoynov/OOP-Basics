using System;

public class Siamese : Cat
{
    int earSize;

    public int EarSize
    {
        get { return earSize; }
        set { earSize = value; }
    }

    public Siamese(string name, int earSize)
        : base(name)
    {
        this.earSize = earSize;
    }

    public override string ToString()
    {
        return $"Siamese {Name} {EarSize}";
    }
}