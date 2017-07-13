using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CircuitRace : Race
{
    private int laps;

    public int Laps
    {
        get { return this.laps; }
        set { this.laps = value; }
    }

    public CircuitRace(int id, int lenght, string route, int prizePool, int laps) : base(id, lenght, route, prizePool)
    {
        this.Laps = laps;
    }

    public override int GetPP(Car car)
    {
        var pp = car.Horsepower / car.Acceleration + car.Suspension + car.Durability;
        return pp;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");

        var place = 1;

        foreach (var car in this.Participants.OrderByDescending(x => GetPP(x)))
        {
            car.Durability -= this.Laps * this.Length * this.Length;

            if (place > 4)
            {
                break;
            }

            sb.Append($"{place}. {car.Brand} {car.Model} {GetPP(car)}PP - $");

            if (place == 1)
            {
                sb.AppendLine($"{this.PrizePool * 40 / 100}");
            }
            else if (place == 2)
            {
                sb.AppendLine($"{this.PrizePool * 30 / 100}");
            }
            else if (place == 3)
            {
                sb.AppendLine($"{this.PrizePool * 20 / 100}");
            }
            else if (place == 4)
            {
                sb.Append($"{this.PrizePool * 10 / 100}");
            }

            place++;
        }

        return sb.ToString().TrimEnd(new[] { '\r', '\n' });
    }
}
