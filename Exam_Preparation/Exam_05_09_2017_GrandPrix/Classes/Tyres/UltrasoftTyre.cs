using System;

public class UltrasoftTyre : Tyre
{
    double grip;

    public UltrasoftTyre(double tyreHardness, double grip) 
        : base(tyreHardness)
    {
        this.Grip = grip;
    }

    public double Grip 
    {
        get { return this.grip; }
        private set
        {
            this.grip = value;
        }
    }

    public override string Name => "UtrasoftTyre";

    public override double Degradation 
    { 
        get => base.Degradation; 
        protected set 
        {
            Validation.ValidateDegradationValueUltrasoft(value);
            base.Degradation = value;
        }
    }

	internal override void ReduceDegradation()
	{
        base.Degradation -= (this.Hardness + this.Grip);
	}
}