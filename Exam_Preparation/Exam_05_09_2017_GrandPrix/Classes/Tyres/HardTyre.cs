using System;

public class HardTyre : Tyre
{
    public HardTyre(double tyreHardness) 
        : base(tyreHardness)
    {
    }

    public override string Name => "Hard";
}