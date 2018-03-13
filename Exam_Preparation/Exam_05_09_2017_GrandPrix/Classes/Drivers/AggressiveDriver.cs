using System;

public class AggressiveDriver : Driver
{
    const double AGGRESIVE_DRIVER_FUEL_CONSUMATION = 2.7;
    const double AGGRESIVE_DRIVER_SPEED = 1.3;

    public AggressiveDriver(string name, Car car) 
        : base(name, car)
    {
    }

    public override double FuelConsumptionPerKm => AGGRESIVE_DRIVER_FUEL_CONSUMATION;

    public override double Speed => base.Speed * AGGRESIVE_DRIVER_SPEED;

}