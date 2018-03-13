using System;

public abstract class Tyre
{
    const double DEGRADATON_VALUE = 100;

    double degradation;

    protected Tyre(double tyreHardness) 
    {
        this.Hardness = tyreHardness;
        this.Degradation = DEGRADATON_VALUE;
    }

    public double Hardness { get; private set; }

    public abstract string Name { get; }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            Validation.ValidateDegradationValueTyre(value);
            this.degradation = value;
        }
    }

    internal virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}