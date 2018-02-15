/*
 * 07. Speed Racing
 * 
 * Your task is to implement a program that keeps track of cars and their fuel and supports methods for moving the cars.
 * Define a class Car that keeps track of a car’s model, fuel amount, fuel consumption for 1 kilometer and distance traveled.
 * A Car’s model is unique - there will never be 2 cars with the same model.
 * 
 * On the first line of the input you will receive a number N – the number of cars you need to track, on each of the next
 * N lines you will receive information for a car in the following format “<Model> <FuelAmount> <FuelConsumptionFor1km>”.
 * All cars start at 0 kilometers traveled.
 * 
 * After the N lines, until the command “End” is received, you will receive commands in the following format 
 * “Drive <CarModel>  <amountOfKm>”. Implement a method in the Car class to calculate whether or not a car can move that 
 * distance. If it can, the car’s fuel amount should be reduced by the amount of used fuel and its distance traveled 
 * should be increased by the number of kilometers traveled. Otherwise, the car should not move 
 * (its fuel amount and distance traveled should stay the same) and you should print on the console 
 * “Insufficient fuel for the drive”. After the “End” command is received, print each car and its current fuel amount
 * and distance traveled in the format “<Model> <fuelAmount>  <distanceTraveled>”. 
 * Print the fuel amount rounded to two decimal places after the separator.
 * 
 * Example
 * Input:               Output:                    Input:                             Output:
 * 2                    AudiA4 17.60 18            3                                  Insufficient fuel for the drive
 * AudiA4 23 0.3        BMW-M2 21.48 56            AudiA4 18 0.34                     Insufficient fuel for the drive
 * BMW-M2 45 0.42                                  BMW-M2 33 0.41                     AudiA4 1.00 50
 * Drive BMW-M2 56                                 Ferrari-488Spider 50 0.47          BMW-M2 33.00 0
 * Drive AudiA4 5                                  Drive Ferrari-488Spider 97         Ferrari-488Spider 4.41 97
 * Drive AudiA4 13                                 Drive Ferrari-488Spider 35
 * End                                             Drive AudiA4 85
 *                                                 Drive AudiA4 50
 *                                                 End
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int numberOfInput = int.Parse(Console.ReadLine());

        Dictionary<string, Car> data = new Dictionary<string, Car>();

        while (numberOfInput != 0)
        {
            string[] input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Car currentCar = new Car();
            currentCar.Model = input[0];
            currentCar.FuelAmount = decimal.Parse(input[1]);
            currentCar.Consumation = decimal.Parse(input[2]);

            if (!data.ContainsKey(input[0]))
            {
                data[input[0]] = currentCar;
            }

            numberOfInput--;
        }

        string drive;
        while ((drive = Console.ReadLine()) != "End") 
        {
            string[] args = drive
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (data.ContainsKey(args[1]))
            {
                Car currentCar = new Car();
                currentCar = data[args[1]];

                currentCar.Distance(int.Parse(args[2]));
            }
        }

        foreach (var car in data)
        {
            Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TraveledDistance}");
        }
    }
}
