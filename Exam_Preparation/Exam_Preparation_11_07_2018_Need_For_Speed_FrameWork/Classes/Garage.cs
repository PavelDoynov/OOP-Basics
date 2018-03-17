using System;
using System.Collections.Generic;
using System.Linq;

public class Garage
{
    List<Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<Car>();
        this.ParkedCars = parkedCars;
    }

    public List<Car> ParkedCars { get; private set; }

    internal bool HasParkedCar(int carId)
    {
        if (this.ParkedCars.Count > 0)
        {
            List<int> idList = this.ParkedCars.Select(c => c.Id).ToList();
            if (idList.Contains(carId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    internal void AddCarToGarage(Car car)
    {
        this.ParkedCars.Add(car);
    }

    internal Car UnparkCar(int id)
    {
        Car currentCar = this.ParkedCars.Where(c => c.Id == id).FirstOrDefault();

        for (int i = 0; i < this.ParkedCars.Count; i++)
        {
            if (this.ParkedCars[i].Id == id)
            {
                this.ParkedCars.RemoveAt(i);
                break;
            }
        }

        return currentCar;
    }

    internal void GetTuned(int tuneIndex, string addOn)
    {
        for (int i = 0; i < this.ParkedCars.Count; i++)
        {
            string carType = this.ParkedCars[i].GetType().Name;

            if (carType == "PerformanceCar")
            {
                this.ParkedCars[i].AddOnAndStats(tuneIndex, addOn);
            }
            else if (carType == "ShowCar")
            {
                this.ParkedCars[i].StartsAndAddOn(tuneIndex);
            }
        }
    }
}