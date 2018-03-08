using System;

public abstract class Vehicle:IVehicle
{
    double fuelQuantity;
    double consumptionPerKm;
    double distance;

    protected Vehicle(double fuelQuantity, double consumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.ConsumptionPerKm = consumptionPerKm;
        this.Distance = 0;
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
        if (this.FuelQuantity / this.ConsumptionPerKm < distance)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        this.Distance += distance;
        this.FuelQuantity -= distance * this.ConsumptionPerKm;
    }

    public virtual void Refuel(double amount)
    {
        this.FuelQuantity += amount;
    }

    public override string ToString()
    {
        string result = $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        return result;
    }

}