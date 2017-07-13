using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DriftRace : Race
{
    public DriftRace(int id, int lenght, string route, int prizePool) : base(id, lenght, route, prizePool)
    {
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString());

        var place = 1;


        foreach (var car in this.Participants.OrderByDescending(x => this.GetPP(x)))
        {
            if (place > 3)
            {
                break;
            }

            sb.Append($"{place}. {car.Brand} {car.Model} {GetPP(car)}PP - $");

            if (place == 1)
            {
                sb.AppendLine($"{this.PrizePool * 50 / 100}");
            }
            else if (place == 2)
            {
                sb.AppendLine($"{this.PrizePool * 30 / 100}");
            }
            else if (place == 3)
            {
                sb.Append($"{this.PrizePool * 20 / 100}");
            }

            place++;
        }

        return sb.ToString().TrimEnd(new[] { '\r', '\n' });
    }

    public override int GetPP(Car car)
    {
        var pp = car.Suspension + car.Durability;
        return pp;
    }
}
