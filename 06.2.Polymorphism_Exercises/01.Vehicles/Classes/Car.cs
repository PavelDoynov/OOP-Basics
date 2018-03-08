using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double consumptionPerKm) 
        : base(fuelQuantity, consumptionPerKm)
    {
    }

    public override double ConsumptionPerKm 
    { 
        get => base.ConsumptionPerKm + 0.9; 
    }

}