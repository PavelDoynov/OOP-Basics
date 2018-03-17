using System;

public class ShowCar : Car
{
    int stars;

    public ShowCar(int id, string brand, string model, int yearOfProduction, int horsepower, int acceleration, 
                      int suspension, int durability) 
        : base(id, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.stars = 0;
        this.Stars = this.stars;
    }

    public int Stars { get; private set; }

	internal override void StartsAndAddOn(int tuneIndex)
	{
        this.Horsepower += tuneIndex;
        this.Suspension += (tuneIndex / 2);
        this.Stars += tuneIndex;
	}

	public override string ToString()
	{
        return base.ToString() + Environment.NewLine + $"{this.Stars} *";
	}
}