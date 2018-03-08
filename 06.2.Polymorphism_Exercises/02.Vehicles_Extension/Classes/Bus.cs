using System;

public class Bus : Vehicle
{
    const double BUS_CLIMA_CONSUMATION = 1.4;

    public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

    public override double ConsumptionPerKm
    {
        get => base.ConsumptionPerKm + BUS_CLIMA_CONSUMATION;
    }

    public void DriveEmpty (double distance)
    {
        string type = this.GetType().Name;
        double fuelNeeded = this.FuelQuantity / (this.ConsumptionPerKm - BUS_CLIMA_CONSUMATION);

        Validate.ReachDistanceValidation(fuelNeeded, distance, type);

        this.Distance += distance;
        this.FuelQuantity -= distance * (this.ConsumptionPerKm - BUS_CLIMA_CONSUMATION);
    }
}