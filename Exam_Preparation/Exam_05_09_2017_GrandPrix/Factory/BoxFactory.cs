using System;
using System.Collections.Generic;

public class BoxFactory
{
    const string FUEL = "Refuel";
    const string CHANGE_TYRES = "ChangeTyres";

    internal static void MakeChanges(string repairType, List<string> commandArgs, Driver driver)
    {
        if (repairType == FUEL)
        {
            double refuel = double.Parse(commandArgs[0]);

            driver.Car.Refuel(refuel);
        }
        else if (repairType == CHANGE_TYRES)
        {
            driver.Car.ChangeTyres(commandArgs);
        }

        driver.reduceBoxTime();
    }
}