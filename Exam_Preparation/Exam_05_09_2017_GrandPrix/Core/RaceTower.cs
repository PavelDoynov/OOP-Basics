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
    Dictionary<string, string> problemDrivers;  

    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.currentLaps = 0;
        this.problemDrivers = new Dictionary<string, string>();
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

        if (completeLaps > this.LapsNumber - this.currentLaps || completeLaps < 0)
        {
            result.Append($"There is no time! On lap {this.currentLaps}.");
        }
        else
        {
            for (int i = 0; i < completeLaps; i++)
            {
                RecalculateDriverStats();
                this.currentLaps++;
                CheckForOvertaking(result);
            }
        }
        return result.ToString().Trim(); 
    }

    public string GetLeaderboard()
    {
        StringBuilder result = new StringBuilder();
        result.Append($"Lap {this.currentLaps}/{this.LapsNumber}");

        int place = 1;

        foreach (Driver driver in drivers.OrderBy(d => d.TotalTime))
        {
            result.Append(Environment.NewLine + $"{place++} {driver.Name} {driver.TotalTime:f3}");
        }

        if (problemDrivers.Count != 0) 
        {
            foreach (var driver in problemDrivers.Reverse())
            {
                result.Append(Environment.NewLine + $"{place++} {driver.Key} {driver.Value}");
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
                this.problemDrivers[drivers[i].Name] = ex.Message;
                this.drivers.RemoveAt(i);
                i--;
            }
        }
    }

    internal Driver GetWinner() 
    {
        Driver winner = this.drivers.OrderBy(d => d.TotalTime).First();
        return winner;
    }

    private void CheckForOvertaking(StringBuilder result)
    {
        this.drivers = this.drivers.OrderByDescending(d => d.TotalTime).ToList();

        for (int i = 0; i < this.drivers.Count - 1; i ++)
        {
            double timeDifferenceBetweenDrivers = Math.Abs(this.drivers[i + 1].TotalTime - this.drivers[i].TotalTime);
            string typeOfParam = GetType(this.drivers[i]);

            if (this.Weather == "Foggy" && typeOfParam == AGGRESSIVE_DRIVER 
                && timeDifferenceBetweenDrivers <= 3)
            {
                this.problemDrivers[this.drivers[i].Name] = "Crashed";
                this.drivers.RemoveAt(i);
                i--;
            }
            else if (this.Weather == "Rainy" && typeOfParam == ENDURANCE_DRIVER 
                     && timeDifferenceBetweenDrivers <= 3)
            {
                this.problemDrivers[this.drivers[i].Name] = "Crashed";
                this.drivers.RemoveAt(i);
                i--;
            }
            else if (typeOfParam == ENDURANCE_DRIVER && timeDifferenceBetweenDrivers <= 3 
                     || typeOfParam == AGGRESSIVE_DRIVER && timeDifferenceBetweenDrivers <= 3)
            {
                this.drivers[i].ReduceTime(3);
                this.drivers[i + 1].IncreaseTime(3);

                result.Append($"{this.drivers[i].Name} has overtaken {this.drivers[i + 1].Name} " +
                              $"on lap {this.currentLaps}." + Environment.NewLine);
            }
            else if (timeDifferenceBetweenDrivers <= 2)
            {
                this.drivers[i].ReduceTime(2);
                this.drivers[i + 1].IncreaseTime(2);

                result.Append($"{this.drivers[i].Name} has overtaken {this.drivers[i + 1].Name} " +
                              $"on lap {this.currentLaps}." + Environment.NewLine);
            }
        }
    }

    private string GetType(Driver driver)
    {
        StringBuilder result = new StringBuilder();
        result.Append($"{driver.GetType().Name} {driver.Car.Tyre.GetType().Name}");
        return result.ToString();
    }
}