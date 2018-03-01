using System;

public class Ferrari:ICar
{
    string driver;
    string model;

    public Ferrari()
    {
        Model = "488-Spider";
    }

    public Ferrari(string driverName)
        :this ()
    {
        Driver = driverName;
    }

    public string Model 
    {
        get { return model; }
        private set
        {
            model = value;
        }
    }

    public string Driver 
    {
        get { return driver; }
        private set 
        {
            driver = value;
        }
    }

    public string Start()
    {
        return "Zadu6avam sA!";
    }

    public string Stop()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{Stop()}/{Start()}/{this.Driver}";
    }
}