using System;

public class Car
{
    public string model;
    public int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public override string ToString()
    {
        return $"{model} {speed}";
    }
}

