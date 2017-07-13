using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;
    private int id;

    public Race(int id, int lenght, string route, int prizePool)
    {
        this.Id = id;
        this.Length = lenght;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public List<Car> Participants
    {
        get { return this.participants; }
        set { this.participants = value; }
    }

    public int PrizePool
    {
        get { return this.prizePool; }
        set { this.prizePool = value; }
    }

    public string Route
    {
        get { return this.route; }
        set { this.route = value; }
    }

    public int Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public override string ToString()
    {
        return $"{this.Route} - {this.Length}";
    }

    public abstract int GetPP(Car car);
}
