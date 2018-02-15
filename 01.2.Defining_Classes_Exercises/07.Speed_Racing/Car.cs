using System;

public class Car
{
    string carModel;
    decimal fuelAmount;
    decimal fuelConsumation;
    int traveledDistance = 0;

    public string Model
    {
        get { return carModel; }
        set { carModel = value; }
    }

    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public decimal Consumation
    {
        get { return fuelConsumation; }
        set { fuelConsumation = value; }
    }

    public int TraveledDistance
    {
        get { return traveledDistance; }
    }

    public void Distance(int v)
    {
        decimal needAmout = v * this.Consumation;

        if (needAmout <= this.FuelAmount)
        {
            this.FuelAmount -= needAmout;
            this.traveledDistance += v;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
