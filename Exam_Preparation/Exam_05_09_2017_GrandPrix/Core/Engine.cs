using System;
using System.Linq;
using System.Collections.Generic;

public class Engine
{
    bool start;
    RaceTower currentRace;
    List<string> inputArgs;

    public Engine()
    {
        start = true;
        currentRace = new RaceTower();
        inputArgs = new List<string>();
    }

    public void StartUp()
    {

        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        this.currentRace.SetTrackInfo(lapsNumber, trackLength);

        while (start)
        {
            inputArgs = Console.ReadLine().Split(' ').ToList();
            string command = inputArgs[0];
            inputArgs.RemoveAt(0);

            if (command == "RegisterDriver")
            {
                this.currentRace.RegisterDriver(inputArgs);
            }
            else if (command == "Leaderboard")
            {
                Console.WriteLine(this.currentRace.GetLeaderboard());
            }
            else if (command == "CompleteLaps")
            {
                string result = currentRace.CompleteLaps(inputArgs);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine(result);
                }

                start = currentRace.IsTheRaceOver();
            }
            else if (command == "Box")
            {
                currentRace.DriverBoxes(inputArgs);
            }
            else if (command == "ChangeWeather")
            {
                currentRace.ChangeWeather(inputArgs);
            }
        }

        Driver winner = currentRace.GetWinner();
        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
    }
}