using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Race
{
    List<Car> participants;

    protected Race(int id, int length, string route, int prizePool)
    {
        this.Id = id;
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;

        participants = new List<Car>();
        this.Participants = this.participants;
    }

    public int Id { get; }

    public int Length { get; }

    public string Route { get; }

    public int PrizePool { get; }

    public List<Car> Participants { get; protected set; }

    internal void AddCar(Car currentCar)
    {
        this.Participants.Add(currentCar);
    }

    internal bool HasAParticipateCar(int id)
    {
        List<int> idCar = this.Participants.Select(c => c.Id).ToList();
        if (idCar.Contains(id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal void ClearRace()
    {
        this.Participants.Clear();
    }

	public override string ToString()
	{
        if (this.Participants.Count == 0)
        {
            throw new ArgumentException("Cannot start the race with zero participants.");
        }
        else
        {
            return $"{this.Route} - {this.Length}";
        }
    }
}