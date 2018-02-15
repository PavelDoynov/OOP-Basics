/*
 * 10. Car Salesman
 * 
 * Define two classes Car and Engine. A Car has a model, engine, weight and color. 
 * An Engine has model, power, displacement and efficiency. A Car’s weight and color and its Engine’s displacements and 
 * efficiency are optional. 
 * 
 * On the first line you will read a number N which will specify how many lines of engines you will receive. 
 * On each of the next N lines you will receive information about an Engine in the following 
 * format “<Model> <Power> <Displacement> <Efficiency>”. 
 * After the lines with engines, on the next line you will receive a number M – specifying the number of Cars that will 
 * follow. On each of the next M lines information about a Car will follow in the 
 * format “<Model> <Engine> <Weight> <Color>”, where the engine will be the model of an existing Engine. 
 * When creating the object for a Car, you should keep a reference to the real engine in it, instead of just the engine’s 
 * model.
 * 
 * Note that the optional properties might be missing from the formats.
 * 
 * Your task is to print each car (in the order you received them) and its information in the format defined bellow, 
 * if any of the optional fields has not been given print “n/a” in its place instead:
 * <CarModel>:
 *   <EngineModel>:
 *      Power: <EnginePower>
 *      Displacement: <EngineDisplacement>
 *      Efficiency: <EngineEfficiency>
 *   Weight: <CarWeight>
 *   Color: <CarColor>
 * 
 * Bonus*
 * Override the classes’ ToString() methods to have a reusable way of displaying the objects.
 * 
 * Example
 * Input:                              Output:
 * 2                                   FordFocus:
 * V8-101 220 50                         V4-33:
 * V4-33 140 28 B                          Power: 140
 * 3                                       Displacement: 28
 * FordFocus V4-33 1300 Silver             Efficiency: B
 * FordMustang V8-101                    Weight: 1300
 * VolkswagenGolf V4-33 Orange           Color: Silver
 *                                     FordMustang:
 *                                       V8-101:
 *                                         Power: 220
 *                                         Displacement: 50
 *                                         Efficiency: n/a
 *                                       Weight: n/a
 *                                       Color: n/a
 *                                     VolkswagenGolf:
 *                                       V4-33:
 *                                         Power: 140
 *                                         Displacement: 28
 *                                         Efficiency: B
 *                                       Weight: n/a
 *                                       Color: Orange
 * 
 * 
 * Input:                                      Output:
 * 4                                           FordMondeo:
 * DSL-10 280 B                                  DSL-13:
 * V7-55 200 35                                    Power: 305
 * DSL-13 305 55 A+                                Displacement: 55
 * V7-54 190 30 D                                  Efficiency: A+
 * 4                                             Weight: n/a
 * FordMondeo DSL-13 Purple                      Color: Purple
 * VolkswagenPolo V7-54 1200 Yellow            VolkswagenPolo:
 * VolkswagenPassat DSL-10 1375 Blue             V7-54:
 * FordFusion DSL-13                               Power: 190
 *                                                 Displacement: 30
 *                                                 Efficiency: D
 *                                               Weight: 1200
 *                                               Color: Yellow
 *                                             VolkswagenPassat:
 *                                               DSL-10:
 *                                                 Power: 280
 *                                                 Displacement: n/a
 *                                                 Efficiency: B
 *                                               Weight: 1375
 *                                               Color: Blue
 *                                             FordFusion:
 *                                               DSL-13:
 *                                                 Power: 305
 *                                                 Displacement: 55
 *                                                 Efficiency: A+
 *                                               Weight: n/a
 *                                               Color: n/a
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
        int inputEngine = int.Parse(Console.ReadLine());

        List<Engine> engineData = new List<Engine>();

        while (inputEngine != 0)
        {
            string[] engineInfo = Console.ReadLine()
                                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();

            Engine currentEngine = new Engine();
            currentEngine.Model = engineInfo[0];
            currentEngine.Power = engineInfo[1];

            if (engineInfo.Length == 3)
            {
                try
                {
                    int isItNumber = int.Parse(engineInfo[2]);
                    currentEngine.Displacement = engineInfo[2];
                }
                catch (Exception)
                {
                    currentEngine.Efficiency = engineInfo[2];
                }
            }
            else if (engineInfo.Length == 4)
            {
                currentEngine.Displacement = engineInfo[2];
                currentEngine.Efficiency = engineInfo[3];
            }

            engineData.Add(currentEngine);

            inputEngine--;
        }

        int inputCars = int.Parse(Console.ReadLine());

        List<Car> dataCars = new List<Car>();

        while (inputCars != 0)
        {
            string[] carInfo = Console.ReadLine()
                                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();

            Car currentCar = new Car();
            currentCar.Model = carInfo[0];
            currentCar.Engine = engineData.Where(x => x.Model == carInfo[1]).FirstOrDefault();

            if (carInfo.Length == 3)
            {
                try
                {
                    int isItNumber = int.Parse(carInfo[2]);
                    currentCar.Weight = carInfo[2];
                }
                catch (Exception)
                {
                    currentCar.Color = carInfo[2];
                }
            }
            else if (carInfo.Length == 4)
            {
                currentCar.Weight = carInfo[2] ;
                currentCar.Color = carInfo[3];
            }

            dataCars.Add(currentCar);

            inputCars--;
        }

        foreach (var car in dataCars)
        {
            Console.WriteLine(car);
        }
    }
}
