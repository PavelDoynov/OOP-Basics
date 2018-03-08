using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double consumptionPerKm) 
        : base(fuelQuantity, consumptionPerKm)
    {
    }

    public override double ConsumptionPerKm
    {
        get => base.ConsumptionPerKm + 1.6;
    }

    public override void Refuel(double amount)
    {
        this.FuelQuantity += amount * 0.95;
    }
}