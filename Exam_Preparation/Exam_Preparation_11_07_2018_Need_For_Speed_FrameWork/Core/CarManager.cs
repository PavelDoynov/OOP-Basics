using System;
using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    List<Car> carsList;
    List<Race> racesList;
    Garage garage; 

    public CarManager()
    {
        carsList = new List<Car>();
        racesList = new List<Race>();
        garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, 
                  int acceleration, int suspension, int durability)
    {
        try
        {
            Car currentCar = CarFactory.GetCar(id, type, brand, model, yearOfProduction, horsepower, acceleration,
                                           suspension, durability);

            this.carsList.Add(currentCar);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string Check(int id)
    {
        return $"{this.carsList.Where(c => c.Id == id).First().ToString()}";
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        try
        {
            Race currentRace = RaceFactory.GetRace(id, type, length, route, prizePool);
            this.racesList.Add(currentRace);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.garage.HasParkedCar(carId)) 
        {
            this.racesList.Where(r => r.Id == raceId).FirstOrDefault()
                .AddCar(this.carsList.Where(c => c.Id == carId).FirstOrDefault());
        }
    }

    public string Start(int id)
    {
        string result;
        try
        {
            result = $"{this.racesList.Where(r => r.Id == id).First()}";
        }
        catch (Exception ex)
        {
            result = $"{ex.Message}";
        }

        this.racesList.Where(r => r.Id == id).First().ClearRace();

        return result;
    }

    public void Park(int id)
    {
        if (this.racesList.Count > 0)
        {
            bool IsCarInRace = false;
            foreach (var race in this.racesList)
            {
                if (race.HasAParticipateCar(id))
                {
                    IsCarInRace = true;
                    break;
                }
            }

            if (!IsCarInRace)
            {
                this.garage.AddCarToGarage(this.carsList.Where(c => c.Id == id).FirstOrDefault());
            }

        }
        else
        {
            this.garage.AddCarToGarage(this.carsList.Where(c => c.Id == id).FirstOrDefault());
        }
    }

    public void Unpark(int id)
    {
        Car currentCar = this.garage.UnparkCar(id);

        for (int i = 0; i < this.carsList.Count; i++)
        {
            if (this.carsList[i].Id == id)
            {
                this.carsList.RemoveAt(i);
                break;
            }
        }

        this.carsList.Add(currentCar);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        this.garage.GetTuned(tuneIndex, addOn);
    }
}