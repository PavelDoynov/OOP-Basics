using System;

public class CarFactory
{
    const string CAR_TYPE_PERFORMANS = "Performance";
    const string CAR_TYPE_SHOW = "Show";

    internal static Car GetCar(int id, string type, string brand, string model, int yearOfProduction, 
                               int horsepower, int acceleration, int suspension, int durability)
    {
        Car currentCar;

        if (type == CAR_TYPE_PERFORMANS)
        {
            currentCar = new PerformanceCar(id, brand, model, yearOfProduction, 
                                            horsepower, acceleration, suspension, durability);
        }
        else if (type == CAR_TYPE_SHOW)
        {
            currentCar = new ShowCar(id, brand, model, yearOfProduction, horsepower, acceleration, 
                                     suspension, durability);
        }
        else
        {
            throw new ArgumentException("Invalid car type!");
        }

        return currentCar;
    }
}