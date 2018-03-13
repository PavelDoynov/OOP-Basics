using System;

public abstract class Driver
{
    const double TOTAL_TIME_VALUE = 0;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = TOTAL_TIME_VALUE;
    }

    public string Name { get; }

    public Car Car { get; }

    public double TotalTime { get;  private set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public abstract double FuelConsumptionPerKm { get; }

    public void RecalculateTime(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    internal void reduceBoxTime()
    {
        this.TotalTime += 20;
    }

    public void ReduceTime()
    {
        this.TotalTime -= 2;
    }

    public void IncreaseTime()
    {
        this.TotalTime += 2;
    }
}