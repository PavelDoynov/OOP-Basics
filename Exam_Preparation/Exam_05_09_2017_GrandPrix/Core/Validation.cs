using System;

public class Validation
{
    public static void ValidateFuelAmount(double fuelAmount)
    {
        if (fuelAmount < 0)
        {
            throw new ArgumentException("Out of fuel");
        }
    }

    public static void ValidateDegradationValueTyre (double currentDeggradation)
    {
        if (currentDeggradation < 0)
        {
            throw new ArgumentException("Blown Tyre");
        }
    }

    public static void ValidateDegradationValueUltrasoft(double currentDeggradation)
    {
        if (currentDeggradation < 30)
        {
            throw new ArgumentException("Blown Tyre");
        }
    }

    public static void ValidateTyreDriver(string typeDriver)
    {
        if (typeDriver != "Endurance" && typeDriver != "Aggressive")
        {
            throw new ArgumentException("Invalid driver type.");
        }
    }

    public static void ValidateLapsNumber (int laps, int currentLap)
    {
        if (laps < 0)
        {
            throw new ArgumentException($"There is no time! On lap {currentLap}.");
        }
    }
}
