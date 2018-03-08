using System;

public class Truck : Vehicle
{
    const double TRUCK_CLIMA_CONSUMATION = 1.6;
    const double TRUCK_TANK_PROBLEM = 0.95;

    public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity)
        : base(fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

    public override double ConsumptionPerKm
    {
        get => base.ConsumptionPerKm + TRUCK_CLIMA_CONSUMATION;
    }

    public override void Refuel(double amount)
    {
        Validate.RefuelValidation(amount);
        Validate.RefuelTankCapacity(this.TankCapacity, amount);

        this.FuelQuantity += amount * TRUCK_TANK_PROBLEM;
    }
}