using System;

public class Car : Vehicle
{
    const double CAR_CLIMA_CONSUMATION = 0.9;

    public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

    public override double ConsumptionPerKm
    {
        get => base.ConsumptionPerKm + CAR_CLIMA_CONSUMATION;
    }

}