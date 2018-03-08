using System;

public class Validate
{
    public static void ReachDistanceValidation(double fuelNeeded, double distance, string type)
    {
        if (fuelNeeded < distance)
        {
            throw new ArgumentException($"{type} needs refueling");
        }
    }

    public static void RefuelValidation(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
    }

    public static void RefuelTankCapacity (double tankSpace, double amount)
    {
        if (amount > tankSpace)
        {
            throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
        }
    }
}
