using System;
using System.Text;

public abstract class Car
{
    protected Car(int id, string brand, string model, int yearOfProduction, int horsepower, 
                  int acceleration, int suspension, int durability)
    {
        this.Id = id;
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public int Id { get; }

    public string Brand { get; }

    public string Model { get; }

    public int YearOfProduction { get; }

    public int Horsepower { get; protected set; }

    public int Acceleration { get; }

    public int Suspension { get; protected set; }

    public int Durability { get; }

    public int Points { get; private set; }

    public void OverallPerformance()
    {
        this.Points = (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public void EnginePerformance()
    {
        this.Points = (this.Horsepower / this.Acceleration);
    }

    public void SuspensionPerformance()
    {
        this.Points = (this.Suspension + this.Durability);
    }

    internal virtual void AddOnAndStats(int tuneIndex, string addOn)
    {
    }

    internal virtual void StartsAndAddOn(int tuneIndex)
    {
    }

	public override string ToString()
	{
        StringBuilder result = new StringBuilder();

        result.Append($"{this.Brand} {this.Model} {this.YearOfProduction}" + Environment.NewLine);
        result.Append($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s" + Environment.NewLine);
        result.Append($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return result.ToString();
	}
}