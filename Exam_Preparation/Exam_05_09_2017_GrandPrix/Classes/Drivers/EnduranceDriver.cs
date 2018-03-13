using System;

public class EnduranceDriver : Driver
{
    const double ENDURANCE_DRIVER_FUEL_CONSUMATION = 1.5;

    public EnduranceDriver(string name, Car car) 
        : base(name, car)
    {
    }

    public override double FuelConsumptionPerKm => ENDURANCE_DRIVER_FUEL_CONSUMATION;
}
