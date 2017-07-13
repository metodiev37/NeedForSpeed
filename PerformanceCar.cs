using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(int id, string brand, string model, int yearOfProduction, int horspower, int acceleration, int suspension, int durability) : base(id, brand, model, yearOfProduction, horspower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower += (this.Horsepower * 50) / 100;
        this.Suspension -= (this.Suspension * 25) / 100;
    }

    public List<string> AddOns
    {
        get { return this.addOns; }
        set { this.addOns = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(base.ToString());

        if (this.AddOns.Any())
        {
            sb.Append($"Add-ons: {string.Join(", ", this.AddOns)}");
        }
        else
        {
            sb.Append("Add-ons: None");
        }

        return sb.ToString();
    }

}

