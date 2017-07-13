using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCar: Car
{
    //private int stars;

    public ShowCar(int id, string brand, string model, int yearOfProduction, int horspower, int acceleration, int suspension, int durability) : base(id, brand, model, yearOfProduction, horspower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars { get; set; }

    //public int Stars
    //{
    //    get { return this.stars; }
    //    set { this.stars = value; }
    //}

    public override string ToString()
    {
        return base.ToString() + $"{this.Stars} *";
    }

    public override void GetTuned(int tuneIndex, string addOn)
    {
        base.GetTuned(tuneIndex, addOn);

        this.Stars += tuneIndex;
    }
}

