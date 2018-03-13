using System;

class Program
{
    static void Main()
    {
        //Driver newDriver = new AggressiveDriver("Pavel", new Car(100, 20.5 , new UltrasoftTyre(15.5, 13.0)));
        //Console.WriteLine(newDriver.Car.FuelAmount);
        //Console.WriteLine(newDriver.Speed);

        Engine startProgram = new Engine();
        startProgram.StartUp();
    }
}