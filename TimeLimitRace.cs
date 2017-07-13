using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TimeLimitRace : Race
{
    private int goldTime;

    public int GoldTime
    {
        get { return this.goldTime; }
        set { this.goldTime = value; }
    }

    public TimeLimitRace(int id, int lenght, string route, int prizePool, int goldTime) : base(id, lenght, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public override int GetPP(Car car)
    {
        var tp = this.Length * ((car.Horsepower / 100) * car.Acceleration);
        return tp;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString());

        var participant = this.Participants.FirstOrDefault();

        if (participant != null)
        {
            var participantTime = this.GetPP(participant);

            sb.AppendLine($"{participant.Brand} {participant.Model} - {participantTime} s.");

            if (participantTime <= this.GoldTime)
            {
                sb.Append($"Gold Time, ${this.PrizePool}.");
            }
            else if (participantTime <= this.GoldTime + 15)
            {
                sb.Append($"Silver Time, ${this.PrizePool * 50 / 100}.");
            }
            else if (participantTime > this.GoldTime + 15)
            {
                sb.Append($"Bronze Time, ${this.PrizePool * 30 / 100}.");
            }
        }

        return sb.ToString().TrimEnd(new[] { '\r', '\n' });
    }
}
