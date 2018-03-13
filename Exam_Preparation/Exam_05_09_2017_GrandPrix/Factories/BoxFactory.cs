using System;
using System.Collections.Generic;

public class BoxFactory
{
    const string FUEL = "Refuel";
    const string CHANGE_TYRES = "ChangeTyres";
    const string TYRE_TYPE_HARD = "Hard";
    const string TYRE_TYPE_ULTRASOFT = "Ultrasoft";

    internal static void MakeChanges(string repairType, List<string> commandArgs, Driver driver)
    {
        if (repairType == FUEL)
        {
            double refuel = double.Parse(commandArgs[0]);

            driver.Car.Refuel(refuel);
        }
        else if (repairType == CHANGE_TYRES)
        {
            string tyreType = commandArgs[0];
            double hardness = double.Parse(commandArgs[1]);

            Tyre newTyre;

            if (tyreType == TYRE_TYPE_ULTRASOFT)
            {
                double grip = double.Parse(commandArgs[2]);
                newTyre = new UltrasoftTyre(hardness, grip);
            }
            else 
            {
                newTyre = new HardTyre(hardness);
            }

            driver.Car.TakeTyre(newTyre);
        }

        driver.reduceBoxTime();
    }
}