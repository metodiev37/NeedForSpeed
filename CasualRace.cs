using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CasualRace : Race
{
    public CasualRace(int id, int lenght, string route, int prizePool) : base(id, lenght, route, prizePool)
    {
    }

    public override int GetPP(Car car)
    {
        var pp = car.Horsepower / car.Acceleration + car.Suspension + car.Durability;
        return pp;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString());

        var place = 1;
        

        foreach (var car in this.Participants.OrderByDescending(x => GetPP(x)))
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

        //string data = sb.ToString().Replace("\r\n\r\n", "\r\n");

        return sb.ToString().TrimEnd(new []{'\r','\n'});
    }
}
