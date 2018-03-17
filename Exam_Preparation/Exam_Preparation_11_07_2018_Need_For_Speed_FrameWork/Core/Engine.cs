using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    bool startProgram;
    CarManager manageTheRace;

    public Engine()
    {
        this.startProgram = true;
        this.manageTheRace = new CarManager();
    }

    public void StartUp()
    {
        while (startProgram)
        {
            List<string> commandArgs = Console.ReadLine().Split(' ').ToList();
            string command = commandArgs[0];
            commandArgs.RemoveAt(0);

            if (command == "register")
            {
                int id = int.Parse(commandArgs[0]);
                string type = commandArgs[1];
                string brand = commandArgs[2];
                string model = commandArgs[3];
                int year = int.Parse(commandArgs[4]);
                int horsepower = int.Parse(commandArgs[5]);
                int acceleration = int.Parse(commandArgs[6]);
                int suspension = int.Parse(commandArgs[7]);
                int durability = int.Parse(commandArgs[8]);

                manageTheRace.Register(id, type, brand, model, year, horsepower, acceleration,
                                       suspension, durability);
            }
            else if (command == "check")
            {
                int id = int.Parse(commandArgs[0]);
                Console.WriteLine(manageTheRace.Check(id));
            }
            else if (command == "open")
            {
                int id = int.Parse(commandArgs[0]);
                string type = commandArgs[1];
                int length = int.Parse(commandArgs[2]);
                string route = commandArgs[3];
                int prizePool = int.Parse(commandArgs[4]);

                manageTheRace.Open(id, type, length, route, prizePool);
            }
            else if (command == "participate")
            {
                int carId = int.Parse(commandArgs[0]);
                int raceId = int.Parse(commandArgs[1]);

                manageTheRace.Participate(carId, raceId);
            }
            else if (command == "start")
            {
                int raceId = int.Parse(commandArgs[0]);
                Console.WriteLine(manageTheRace.Start(raceId));
            }
            else if (command == "park")
            {
                int carId = int.Parse(commandArgs[0]);
                manageTheRace.Park(carId);
            }
            else if (command == "unpark")
            {
                int carId = int.Parse(commandArgs[0]);
                manageTheRace.Unpark(carId);
            }
            else if (command == "tune")
            {
                int tuneIndex = int.Parse(commandArgs[0]);
                string addOn = commandArgs[1];
                manageTheRace.Tune(tuneIndex, addOn);
            }
            else if (command == "Cops")
            {
                startProgram = false;
            }
        }
    }
}