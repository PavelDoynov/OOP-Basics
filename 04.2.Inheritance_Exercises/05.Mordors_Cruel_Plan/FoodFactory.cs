using System;

public abstract class FoodFactory
{
    public int Points { get; private set; }

    public FoodFactory()
    {
        Points = 0;
    }

    public FoodFactory(int points)
        :this()
    {
        Points = points;
    }
}