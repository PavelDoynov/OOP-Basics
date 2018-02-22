using System;

public class Validate
{
    public static void ValidatorMoney (decimal money)
    {
        if (money < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }
    }

    public static void ValidatorName (string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
    }
}