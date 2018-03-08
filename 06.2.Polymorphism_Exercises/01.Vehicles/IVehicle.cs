using System;

public interface IVehicle
{
    double FuelQuantity { get; }
    double ConsumptionPerKm { get; }

    void Refuel(double amount);
    void Drive(double dictance);
}