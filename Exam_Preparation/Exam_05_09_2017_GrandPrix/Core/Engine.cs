using System;
using System.Linq;
using System.Collections.Generic;

public class Engine
{
    bool takeLaps;
    bool start;
    RaceTower currentRace;
    List<string> inputArgs;

    public Engine()
    {
        takeLaps = true;
        start = true;
        currentRace = new RaceTower();
        inputArgs = new List<string>();
    }

    public void StartUp()
    {

        while (takeLaps)
        {
            int lapsNumber = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());

            try
            {
                this.currentRace.SetTrackInfo(lapsNumber, trackLength);
                takeLaps = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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
                Console.WriteLine(this.currentRace.GetLeaderboard().Trim());
            }
            else if (command == "CompleteLaps")
            {
                string result = currentRace.CompleteLaps(inputArgs);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine(result.Trim());
                }

                start = currentRace.IsTheRaceOver();
                if (!start)
                {
                    Driver winner = currentRace.GetWinner();
                    Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.".Trim());
                }
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
    }
}