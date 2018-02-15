/*
 * 08. Raw Data
 * 
 * You are the owner of a courier company and want to make a system for tracking your cars and their cargo. 
 * Define a class Car that holds information about model, engine, cargo and a collection of exactly 4 tires. 
 * The engine, cargo and tire should be separate classes. Create a constructor that receives all information about the 
 * Car and creates and initializes its inner components (engine, cargo and tires).
 * 
 * On the first line of input you will receive a number N - the amount of cars you have. On each of the next N lines you
 * will receive information about a car in the 
 * format “<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> 
 * <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>” 
 * where the speed, power, weight and tire age are integers, tire pressure is a double. 
 * 
 * After the N lines you will receive a single line with one of 2 commands: “fragile” or “flamable”. 
 * If the command is “fragile” print all cars whose Cargo Type is “fragile” with a tire whose pressure is  < 1. 
 * If the command is “flamable” print all cars whose Cargo Type is “flamable” and have Engine Power > 250. 
 * The cars should be printed in order of appearing in the input.
 * 
 * Example
 * Input:                                                                Output:
 * 2                                                                     Citroen2CV
 * ChevroletAstro 200 180 1000 fragile 1.3 1 1.5 2 1.4 2 1.7 4
 * Citroen2CV 190 165 1200 fragile 0.9 3 0.85 2 0.95 2 1.1 1
 * fragile
 * 
 * Input:                                                                Output:
 * 4                                                                     ChevroletExpress
 * ChevroletExpress 215 255 1200 flamable 2.5 1 2.4 2 2.7 1 2.8 1        DaciaDokker
 * ChevroletAstro 210 230 1000 flamable 2 1 1.9 2 1.7 3 2.1 1
 * DaciaDokker 230 275 1400 flamable 2.2 1 2.3 1 2.4 1 2 1
 * Citroen2CV 190 165 1200 fragile 0.8 3 0.85 2 0.7 5 0.95 2
 * flamable
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        List<Car> data = new List<Car>();

        while (input != 0)
        {
            string[] args = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();
            
            Engine currentEngine = new Engine();
            Cargo currentCargo = new Cargo();
            Tyres currentTyres = new Tyres();

            string name = args[0];
            currentEngine.EngineInfo(args[1], args[2]);
            currentCargo.CargoInfo(args[3], args[4]);
            currentTyres.GetTyres(args[5], args[6], args[7], args[8], 
                                  args[9], args[10], args[11], args[12]);

            Car currentCar = new Car(name, currentEngine, currentCargo, currentTyres);
                
            data.Add(currentCar);

            input--;
        }

        string command = Console.ReadLine();

        if (command == "flamable")
        {
            foreach (var car in data.Where(x => x.Cargo.Type == command).Where(x => x.Engine.Power > 250))
            {
                Console.WriteLine($"{car.Name}");
            }
        }
        else if (command == "fragile")
        {
            foreach (var car in data.Where(x => x.Cargo.Type == command).Where(x => x.Tyres.TyrePressure1 < 1 
                                                                               || x.Tyres.TyrePressure2 < 1 
                                                                               || x.Tyres.TyrePressure3 < 1
                                                                               || x.Tyres.TyrePressure4 < 1))
            {
                Console.WriteLine($"{car.Name}");
            }
        }
    }
}
