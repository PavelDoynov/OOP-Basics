using System;
using System.Collections.Generic;

public class Car
{
    const int TANK_CAPACITY = 160;

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

	internal void TakeTyre(Tyre newTyre)
	{
        this.Tyre = newTyre;
	}

	internal void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }
}