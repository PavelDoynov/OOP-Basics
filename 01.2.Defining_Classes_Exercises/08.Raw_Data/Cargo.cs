using System;

public class Cargo
{
    int wight;
    string type;

    public void CargoInfo (string wight, string type)
    {
        this.Wight = int.Parse(wight);
        this.Type = type;
    }

    public int Wight
    {
        get { return wight; }
        set { wight = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

}