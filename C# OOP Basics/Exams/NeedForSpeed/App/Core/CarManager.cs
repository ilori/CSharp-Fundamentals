using System;
using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }


    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        try
        {
            var car = CarFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension,
                durability);

            if (!cars.ContainsKey(id))
            {
                cars[id] = car;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        try
        {
            var race = RaceFactory.CreateRace(type, length, route, prizePool);

            if (!races.ContainsKey(id))
            {
                races[id] = race;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int param)
    {
        try
        {
            var race = RaceFactory.CreateRace(type, length, route, prizePool, param);

            if (!races.ContainsKey(id))
            {
                races[id] = race;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Participate(int carId, int raceId)
    {
        try
        {
            var car = cars[carId];
            var race = races[raceId];

            if (!garage.ParkedCars.Contains(car))
            {
                if (race.GetType().Name == "TimeLimitRace")
                {
                    if (race.Participants.Count == 0)
                    {
                        race.Participants.Add(car);
                    }
                }
                else
                {
                    race.Participants.Add(car);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public string Start(int id)
    {
        try
        {
            var race = races[id];


            if (race.Participants.Count > 0)
            {
                races.Remove(id);
                return race.Winner();
            }

            throw new InvalidOperationException("Cannot start the race with zero participants.");
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public void Park(int id)
    {
        try
        {
            var car = cars[id];

            foreach (var r in races.Values)
            {
                if (r.Participants.Contains(car))
                {
                    return;
                }
            }

            garage.ParkedCars.Add(car);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Unpark(int id)
    {
        garage.ParkedCars.Remove(cars[id]);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in garage.ParkedCars)
        {
            var carName = car.GetType().Name;
            var horsePowerBoost = car.Horsepower += tuneIndex;
            var suspensionBoost = car.Suspension += (tuneIndex / 2);

            switch (carName)
            {
                case "PerformanceCar":
                    var performanceCar = (PerformanceCar) car;
                    performanceCar.Horsepower = horsePowerBoost;
                    performanceCar.Suspension = suspensionBoost;
                    performanceCar.AddOns.Add(addOn);
                    break;
                case "ShowCar":
                    var showCar = (ShowCar) car;
                    showCar.Horsepower = horsePowerBoost;
                    showCar.Suspension = suspensionBoost;
                    showCar.Stars += tuneIndex;
                    break;
            }
        }
    }
}