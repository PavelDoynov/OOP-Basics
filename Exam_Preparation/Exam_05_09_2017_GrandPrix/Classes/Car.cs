using System;
using System.Collections.Generic;

public class Car
{
    const int TANK_CAPACITY = 160;
    const string TYRE_TYPE_HARD = "Hard";
    const string TYRE_TYPE_ULTRASOFT = "Ultrasoft";

    double fuelAmount;
    Tyre tyre;

    public Car (int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            Validation.ValidateFuelAmount(value);
            if (value > TANK_CAPACITY)
            {
                this.fuelAmount = TANK_CAPACITY;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public Tyre Tyre 
    {
        get { return this.tyre; }
        private set
        {
            this.tyre = value;
        }
    }

    internal void ReduceFuel(int trackLength, double fuelConsumation)
    {
        this.FuelAmount -= trackLength * fuelConsumation;
    }

    internal void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    internal void ChangeTyres(List<string> commandArgs)
    {
        string tyreType = commandArgs[0];
        double hardness = double.Parse(commandArgs[1]);

        if (tyreType == TYRE_TYPE_HARD)
        {
            this.Tyre = new HardTyre(hardness);
        }
        else if (tyreType == TYRE_TYPE_ULTRASOFT)
        {
            double grip = double.Parse(commandArgs[2]);
            this.Tyre = new UltrasoftTyre(hardness, grip);
        }
    }
}