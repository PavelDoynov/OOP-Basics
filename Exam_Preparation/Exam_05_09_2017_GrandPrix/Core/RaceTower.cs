using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class RaceTower
{
    const string AGGRESSIVE_DRIVER = "AggressiveDriver UltrasoftTyre";
    const string ENDURANCE_DRIVER = "EnduranceDriver HardTyre";

    List<Driver> drivers;
    int currentLaps;
    int lapsNumber;
    Dictionary<Driver, string> problemDrivers;  

    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.currentLaps = 0;
        this.problemDrivers = new Dictionary<Driver, string>();
        this.Weather = "Sunny";
    }

    public int LapsNumber 
    { 
        get { return this.lapsNumber; }
        private set
        {
            Validation.ValidateLapsNumber(value, this.currentLaps);
            this.lapsNumber = value;
        }
    }
    public int TrackLength { get; private set; }
    public string Weather { get; private set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Driver currentDriver = DriverFactory.GetDriver(commandArgs);
            drivers.Add(currentDriver);
        }
        catch (Exception exArgs)
        {
            Console.WriteLine(exArgs.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string repairType = commandArgs[0];
        commandArgs.RemoveAt(0);

        string driverName = commandArgs[0];
        commandArgs.RemoveAt(0);

        for (int i = 0; i < this.drivers.Count; i++)
        {
            if (drivers[i].Name == driverName)
            {
                BoxFactory.MakeChanges(repairType, commandArgs, drivers[i]);
            }
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder result = new StringBuilder();
        int completeLaps = int.Parse(commandArgs[0]);

        if (completeLaps > this.LapsNumber - this.currentLaps)
        {
            result.Append($"There is no time! On lap {this.currentLaps}.");
        }
        else
        {
            for (int i = 0; i < completeLaps; i++)
            {
                RecalculateDriverStats();
                this.currentLaps++;
                result.Append(CheckForOvertaking(this.currentLaps).Trim());
            }
        }
        return result.ToString(); 
    }

    public string GetLeaderboard()
    {
        StringBuilder result = new StringBuilder();
        result.Append($"Lap {this.currentLaps}/{this.LapsNumber}");

        int place = 1;

        foreach (Driver driver in drivers.OrderBy(d => d.TotalTime))
        {
            result.Append(Environment.NewLine + $"{place} {driver.Name} {driver.TotalTime:f3}");
            place++;
        }

        if (problemDrivers.Count != 0) 
        {
            foreach (var driver in problemDrivers.Reverse())
            {
                result.Append(Environment.NewLine + $"{place} {driver.Key.Name} {driver.Value}");
                place++;
            }
        }

        return result.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.Weather = commandArgs[0];
    }

    internal bool IsTheRaceOver()
    {
        if (this.LapsNumber == this.currentLaps)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void RecalculateDriverStats() 
    {
        List<int> indexOfProblemDrivers = new List<int>();

        for (int i = 0; i < this.drivers.Count; i++)
        {
            this.drivers[i].RecalculateTime(this.TrackLength);
            try
            {
                this.drivers[i].Car.ReduceFuel(this.TrackLength, this.drivers[i].FuelConsumptionPerKm);
                this.drivers[i].Car.Tyre.ReduceDegradation();
            }
            catch (Exception ex)
            {
                indexOfProblemDrivers.Add(i);
                this.problemDrivers[drivers[i]] = ex.Message;
            }
        }

        indexOfProblemDrivers = indexOfProblemDrivers.OrderByDescending(x => x).ToList();
        if (indexOfProblemDrivers.Count != 0)
        {
            for (int i = 0; i < indexOfProblemDrivers.Count; i++)
            {
                this.drivers.RemoveAt(indexOfProblemDrivers[i]);
            }
        }
    }

    internal Driver GetWinner() 
    {
        Driver winner = this.drivers.OrderBy(d => d.TotalTime).First();
        return winner;
    }

    private string CheckForOvertaking(int lap)
    {
        StringBuilder result = new StringBuilder();

        List<Driver> currentDrivers = this.drivers.OrderByDescending(d => d.TotalTime).ToList();
        List<int> indexOfCrashedDrivers = new List<int>();

        for (int i = 0; i < currentDrivers.Count - 1; i ++)
        {
            double timeDifferenceBetweenDrivers = currentDrivers[i + 1].TotalTime - currentDrivers[i].TotalTime;
            string typeOfParam = GetType(currentDrivers[i]);

            if (this.Weather == "Foggy" && typeOfParam == AGGRESSIVE_DRIVER 
                && timeDifferenceBetweenDrivers <= 3 && timeDifferenceBetweenDrivers >= 0)
            {
                indexOfCrashedDrivers.Add(i);
                this.problemDrivers[currentDrivers[i]] = "Crashed";
            }
            else if (this.Weather == "Rainy" && typeOfParam == ENDURANCE_DRIVER 
                     && timeDifferenceBetweenDrivers <= 3 && timeDifferenceBetweenDrivers >= 0)
            {
                indexOfCrashedDrivers.Add(i);
                this.problemDrivers[currentDrivers[i]] = "Crashed";
            }
            else if (this.Weather == "Sunny" && typeOfParam == ENDURANCE_DRIVER
                     && timeDifferenceBetweenDrivers <= 3 && timeDifferenceBetweenDrivers >= 0
                     || this.Weather == "Sunny" && typeOfParam == AGGRESSIVE_DRIVER
                     && timeDifferenceBetweenDrivers <= 3 && timeDifferenceBetweenDrivers >= 0)
            {
                currentDrivers[i].ReduceTime(3);
                currentDrivers[i + 1].IncreaseTime(3);

                result.Append($"{currentDrivers[i].Name} has overtaken {currentDrivers[i + 1].Name} " +
                              $"on lap {lap}." + Environment.NewLine);
            }
            else if (timeDifferenceBetweenDrivers >= 0 && timeDifferenceBetweenDrivers <= 2)
            {
                currentDrivers[i].ReduceTime(2);
                currentDrivers[i + 1].IncreaseTime(2);

                result.Append($"{currentDrivers[i].Name} has overtaken {currentDrivers[i + 1].Name} " +
                              $"on lap {lap}." + Environment.NewLine);
            }
        }

        if (indexOfCrashedDrivers.Count != 0)
        {
            for (int x = 0; x < indexOfCrashedDrivers.Count; x++)
            {
                currentDrivers.RemoveAt(indexOfCrashedDrivers[x]);
            }
        }

        this.drivers = currentDrivers;

        return result.ToString();
    }

    private string GetType(Driver driver)
    {
        StringBuilder result = new StringBuilder();
        result.Append($"{driver.GetType().Name} {driver.Car.Tyre.GetType().Name}");
        return result.ToString();
    }
}