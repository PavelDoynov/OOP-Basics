using System;
using System.Collections.Generic;

public class DriverFactory
{
    public static Driver GetDriver(List<string> commandArgs)
    {
        string typeDriver = commandArgs[0];
        string name = commandArgs[1];

        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);

        string tyreType = commandArgs[4];
        double tyreHardness = double.Parse(commandArgs[5]);

        Tyre currentTyre;
        if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(commandArgs[6]);
            currentTyre = new UltrasoftTyre(tyreHardness, grip);
        }
        else
        {
            currentTyre = new HardTyre(tyreHardness);
        }

        Car currentCar = new Car(hp, fuelAmount, currentTyre);

        Driver currentDriver;
        Validation.ValidateTyreDriver(typeDriver);
        if (typeDriver == "Aggressive")
        {
            currentDriver = new AggressiveDriver(name, currentCar);
        }
        else 
        {
            currentDriver = new EnduranceDriver(name, currentCar);
        }

        return currentDriver;
    }
}
