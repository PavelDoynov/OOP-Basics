/*
 * 02. Vehicles Extension
 * 
 * Use your solution of the previous task for the starting point and add more functionality. Add a new vehicle – Bus. 
 * Add to every vehicle a new property – tank capacity. A vehicle cannot start with or refuel above its tank capacity.
 * 
 * If you try to put more fuel in the tank than the available space, print on the console "Cannot fit {fuel amount} fuel
 * in the tank" and do not add any fuel in the vehicle’s tank. If you try to create a vehicle with more fuel than its tank
 * capacity, create it but start with an empty tank.
 * 
 * Add a new command for the bus. You can drive the bus with or without people. With people, the air-conditioner is turned
 * on and its fuel consumption per kilometer is increased by 1.4 liters. If there are no people in the bus, the 
 * air-conditioner is turned off and does not increase the fuel consumption.
 * 
 * Finally, add validation for the amount of fuel given to the Refuel command – if it is 0 or negative, print "Fuel must 
 * be a positive number".
 * 
 * Input
 * •   On the first three lines you will receive information about the vehicles in the format:
 *   •   "Vehicle {initial fuel quantity} {liters per km} {tank capacity}"
 * •   On the fourth line – the number of commands N that will be given on the next N lines
 * •   On the next N lines – commands in format:
 *   •   "Drive Car {distance}"
 *   •   "Drive Truck {distance}"
 *   •   "Drive Bus {distance}"
 *   •   "DriveEmpty Bus {distance}"
 *   •   "Refuel Car {liters}"
 *   •   "Refuel Truck {liters}"
 *   •   "Refuel Bus {liters}"
 * 
 * Output
 * •   After each Drive command, if there was enough fuel, print on the console a message in the format:
 *   •   "Car/Truck travelled {distance} km"
 * •   If there was not enough fuel, print:
 *   •   "Car/Truck needs refueling"
 * •   If you try to refuel with an amount ≤ 0 print:
 *   •   "Fuel must be a positive number"
 * •   If the given fuel cannot fit in the tank, print:
 *   •   "Cannot fit {fuel amount} fuel in the tank"
 * •   After the End command, print the remaining fuel for all vehicles, rounded to 2 digits after the floating
 * point in the format:
 *   •   "Car: {liters}"
 *   •   "Truck: {liters}"
 *   •   "Bus: {liters}"
 * 
 * Example
 * Input:                  Output:
 * Car 30 0.04 70          Fuel must be a positive number
 * Truck 100 0.5 300       Fuel must be a positive number
 * Bus 40 0.3 150          Cannot fit 300 fuel in the tank
 * 8                       Bus travelled 10 km
 * Refuel Car -10          Cannot fit 1000 fuel in the tank
 * Refuel Truck 0          Bus needs refueling
 * Refuel Car 10           Cannot fit 1000 fuel in the tank
 * Refuel Car 300          Car: 40.00
 * Drive Bus 10            Truck: 100.00
 * Refuel Bus 1000         Bus: 23.00
 * DriveEmpty Bus 100
 * Refuel Truck 1000  
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {
        IVehicle car = GetVehicle(Console.ReadLine().Split(' '));
        IVehicle truck = GetVehicle(Console.ReadLine().Split(' '));
        IVehicle bus = GetVehicle(Console.ReadLine().Split(' '));

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
                else if (input[1] == "Truck")
                {
                    currentVehicle = truck;
                }
                else
                {
                    currentVehicle = bus;
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
                else if (input[0] == "DriveEmpty")
                {
                    ((Bus)currentVehicle).DriveEmpty(double.Parse(input[2]));
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
        Console.WriteLine(bus);
    }

    private static IVehicle GetVehicle(string[] input)
    {
        string type = input[0];
        double fuelQuantity = double.Parse(input[1]);
        double consumation = double.Parse(input[2]);
        double tankCapacity = double.Parse(input[3]);

        if (fuelQuantity > tankCapacity)
        {
            fuelQuantity = 0;
        }

        IVehicle currentVehicle;
        if (type == "Car")
        {
            currentVehicle = new Car(fuelQuantity, consumation, tankCapacity);
        }
        else if (type == "Truck")
        {
            currentVehicle = new Truck(fuelQuantity, consumation, tankCapacity);
        }
        else 
        {
            currentVehicle = new Bus(fuelQuantity, consumation, tankCapacity);
        }
        return currentVehicle;
    }
}