using System;

public abstract class SpecialisedSoldier: Private, ISpecialisedSoldier
{
    protected string corps;

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        :base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps 
    {
        get { return corps; }
        private set
        {
            corps = value;
        }
    }

    public abstract override string ToString();
}