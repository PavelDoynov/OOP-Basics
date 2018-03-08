using System;

public abstract class Vehicle : IVehicle
{
    double tankCapacity;
    double fuelQuantity;
    double consumptionPerKm;
    double distance;

    protected Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.ConsumptionPerKm = consumptionPerKm;
        this.Distance = 0;
    }

    public virtual double TankCapacity
    {
        get { return this.tankCapacity; }
        protected set
        {
            this.tankCapacity = value;
        }
    }

    public virtual double FuelQuantity
    {
        get { return this.fuelQuantity; }
        protected set
        {
            this.fuelQuantity = value;
        }
    }

    public virtual double ConsumptionPerKm
    {
        get { return this.consumptionPerKm; }
        protected set
        {
            this.consumptionPerKm = value;
        }
    }

    public virtual double Distance
    {
        get { return this.distance; }
        protected set
        {
            this.distance = value;
        }
    }

    public virtual void Drive(double distance)
    {
        string type = this.GetType().Name;
        double fuelNeeded = this.FuelQuantity / this.ConsumptionPerKm;

        Validate.ReachDistanceValidation(fuelNeeded, distance, type);

        this.Distance += distance;
        this.FuelQuantity -= distance * this.ConsumptionPerKm;
    }

    public virtual void Refuel(double amount)
    {
        Validate.RefuelValidation(amount);
        Validate.RefuelTankCapacity(this.TankCapacity, amount);

        this.FuelQuantity += amount;
    }

    public override string ToString()
    {
        string result = $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        return result;
    }

}