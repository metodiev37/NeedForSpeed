using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarManager : Garage
{
    private List<Car> registeredCars;
    private List<Race> openedRaces;

    public CarManager()
    {
        this.RegisteredCars = new List<Car>();
        this.OpenedReces = new List<Race>();
    }

    protected List<Car> RegisteredCars
    {
        get { return this.registeredCars; }
        set { this.registeredCars = value; }
    }

    protected List<Race> OpenedReces
    {
        get { return this.openedRaces; }
        set { this.openedRaces = value; }
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        if (type == "Performance")
        {
            var car = new PerformanceCar(id, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            this.RegisteredCars.Add(car);
        }
        else if (type == "Show")
        {
            var car = new ShowCar(id, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            this.registeredCars.Add(car);
        }
    }

    public string Check(int id)
    {
        var car = this.RegisteredCars.FirstOrDefault(x => x.Id == id);

        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        if (type == "Casual")
        {
            var race = new CasualRace(id, length, route, prizePool);
            this.OpenedReces.Add(race);
        }
        else if (type == "Drag")
        {
            var race = new DragRace(id, length, route, prizePool);
            this.OpenedReces.Add(race);
        }
        else if (type == "Drift")
        {
            var race = new DriftRace(id, length, route, prizePool);
            this.OpenedReces.Add(race);
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int lastParam)
    {
        if (type == "TimeLimit")
        {
            var race = new TimeLimitRace(id, length, route, prizePool, lastParam);
            this.OpenedReces.Add(race);
        }
        else if (type == "Circuit")
        {
            var race = new CircuitRace(id, length, route, prizePool, lastParam);
            this.OpenedReces.Add(race);
        }
    }

    public void Participate(int carId, int raceId)
    {
        var isParked = this.ParkedCars.Any(x => x.Id == carId);
        var isThereRace = this.OpenedReces.Any(x => x.Id == raceId);
        var isThereCar = this.RegisteredCars.Any(x => x.Id == carId);

        if (!isParked && isThereRace && isThereCar)
        {
            var currentRace = OpenedReces.First(x => x.Id == raceId);
            var currentCar = RegisteredCars.First(x => x.Id == carId);

            if (!(currentRace is TimeLimitRace))
            {
                currentRace.Participants.Add(currentCar);
            }
            else
            {
                if (currentRace.Participants.Count == 0)
                {
                    currentRace.Participants.Add(currentCar);
                }
            }
        }
    }

    public string Start(int id)
    {
        var raceToStart = this.OpenedReces.FirstOrDefault(x => x.Id == id);

        if (raceToStart != null && raceToStart.Participants.Any())
        {
            this.OpenedReces.Remove(raceToStart);
            return raceToStart.ToString();
        }

        return "Cannot start the race with zero participants.";
    }

    public void Park(int id)
    {
        var isParticipant = false;

        foreach (var race in OpenedReces)
        {
            foreach (var car in race.Participants)
            {
                if (car.Id == id)
                {
                    isParticipant = true;
                    break;
                }
            }

            if (isParticipant)
            {
                break;
            }
        }

        if (!isParticipant)
        {
            var currentCar = RegisteredCars.FirstOrDefault(x => x.Id == id);

            if (currentCar != null)
            {
                this.ParkedCars.Add(currentCar);
            }
        }
    }

    public void Unpark(int id)
    {
        var currentCar = RegisteredCars.FirstOrDefault(x => x.Id == id);

        if (currentCar != null)
        {
            this.ParkedCars.Remove(currentCar);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in this.ParkedCars)
        {
            car.GetTuned(tuneIndex, addOn);
        }
    }
}