using System;

public class Engine
{
    int speed;
    int power;

    public void EngineInfo(string speed, string power)
    {
        this.Speed = int.Parse(speed);
        this.Power = int.Parse(power);
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }
}
