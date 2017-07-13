using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
       this.ParkedCars = new List<Car>(); 
    }

    protected List<Car> ParkedCars
    {
        get { return this.parkedCars; }
        set { this.parkedCars = value; }
    }

}
