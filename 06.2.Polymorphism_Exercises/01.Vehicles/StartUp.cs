/*
 * 01. Vehicles
 * 
 * Write a program that models 2 vehicles (Car and Truck) and simulates driving and refueling them. Car and truck both 
 * have fuel quantity, fuel consumption in liters per km and can be driven a given distance and refueled with a given 
 * amount of fuel. It’s summer, so both vehicles use air conditioners and their fuel consumption per km is increased 
 * by 0.9 liters for the car and with 1.6 liters for the truck. Also, the truck has a tiny hole in its tank and when its 
 * refueled it keeps only 95% of the given fuel. The car has no problems and adds all the given fuel to its tank. 
 * If a vehicle cannot travel the given distance, its fuel does not change.
 * 
 * Input
 * •   On the first line – information about the car in the format: "Car {fuel quantity} {liters per km}"
 * •   On the second line – info about the truck in the format: "Truck {fuel quantity} {liters per km}"
 * •   On the third line – the number of commands N that will be given on the next N lines
 * •   On the next N lines – commands in the format:
 *   •   "Drive Car {distance}"
 *   •   "Drive Truck {distance}"
 *   •   "Refuel Car {liters}"
 *   •   "Refuel Truck {liters}"
 * 
 * Output
 * •   After each Drive command, if there was enough fuel, print on the console a message in the format:
 *   •   "Car/Truck travelled {distance} km"
 * •   If there was not enough fuel, print: "Car/Truck needs refueling"
 * •   After the End command, print the remaining fuel for both the car and the truck, rounded to 2 digits after the 
 * floating point in the format:
 *   •   "Car: {liters}"
 *   •   "Truck: {liters}"
 * 
 * Example
 * Input:                Output:
 * Car 15 0.3            Car travelled 9 km
 * Truck 100 0.9         Car needs refueling
 * 4                     Truck travelled 10 km
 * Drive Car 9           Car: 54.20
 * Drive Car 30          Truck: 75.00
 * Refuel Car 50
 * Drive Truck 10
 * 
 * Input:                   Output:
 * Car 30.4 0.4             Car needs refueling
 * Truck 99.34 0.9          Car travelled 13.5 km
 * 5                        Truck needs refueling
 * Drive Car 500            Car: 113.05
 * Drive Car 13.5           Truck: 109.13
 * Refuel Truck 10.300
 * Drive Truck 56.2
 * Refuel Car 100.2
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {
        string[] inputCar = Console.ReadLine().Split(' ');
        IVehicle car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]));

        string[] inputTruck = Console.ReadLine().Split(' ');
        IVehicle truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]));

        int numberOfLines = int.Parse(Console.ReadLine());
        while (numberOfLines != 0)
        {
            string[] input = Console.ReadLine().Split(' ');

            try
            {
                IVehicle currentVehicle;
                if (input[1] == "Car")
                {
                    currentVehicle = car;
                }
                else
                {
                    currentVehicle = truck;
                }

                if (input[0] == "Refuel")
                {
                    currentVehicle.Refuel(double.Parse(input[2]));
                }
                else if (input[0] == "Drive")
                {
                    currentVehicle.Drive(double.Parse(input[2]));
                    Console.WriteLine($"{currentVehicle.GetType().Name} travelled {double.Parse(input[2])} km");
                }
            }
            catch (Exception exArgs)
            {
                Console.WriteLine(exArgs.Message);
            }

            numberOfLines--;
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}