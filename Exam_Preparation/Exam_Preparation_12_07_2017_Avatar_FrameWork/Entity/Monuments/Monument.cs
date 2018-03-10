using System;

public abstract class Monument
{
    string name;

    public Monument(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            this.name = value;
        }
    }

    public abstract double GetMonumentBonus();

	public override string ToString()
	{
        string monumentType = this.GetType().Name;
        int index = monumentType.IndexOf("Monument");
        monumentType = monumentType.Insert(index, " ");

        return $"###{monumentType}: {this.Name}, ";
	}
}
