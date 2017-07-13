using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;
    private int id;

    public Car(int id, string brand, string model, int yearOfProduction, int horspower, int acceleration, int suspension, int durability)
    {
        this.Id = id;
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horspower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public int Durability
    {
        get { return this.durability; }
        set { this.durability = value; }
    }

    public int Suspension
    {
        get { return this.suspension; }
        set { this.suspension = value; }
    }

    public int Acceleration
    {
        get { return this.acceleration; }
        set { this.acceleration = value; }
    }

    public int Horsepower
    {
        get { return this.horsepower; }
        set { this.horsepower = value; }
    }

    public int YearOfProduction
    {
        get { return this.yearOfProduction; }
        set { this.yearOfProduction = value; }
    }
    
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Brand
    {
        get { return this.brand; }
        set { this.brand = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString();
    }
}

