using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var carManager = new CarManager();

        while (input != "Cops Are Here")
        {
            var infoParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var typeOfCommand = infoParts[0];

            if (typeOfCommand == "register")
            {
                var id = int.Parse(infoParts[1]);
                var carType = infoParts[2];
                var brand = infoParts[3];
                var model = infoParts[4];
                var year = int.Parse(infoParts[5]);
                var hp = int.Parse(infoParts[6]);
                var acc = int.Parse(infoParts[7]);
                var suspension = int.Parse(infoParts[8]);
                var durability = int.Parse(infoParts[9]);

                carManager.Register(id, carType, brand, model, year, hp, acc, suspension, durability);
            }
            else if (typeOfCommand == "participate")
            {
                var carId = int.Parse(infoParts[1]);
                var raceId = int.Parse(infoParts[2]);

                carManager.Participate(carId, raceId);
            }
            else if (typeOfCommand == "open")
            {
                if (infoParts.Length < 7)
                {
                    var id = int.Parse(infoParts[1]);
                    var raceType = infoParts[2];
                    var length = int.Parse(infoParts[3]);
                    var route = infoParts[4];
                    var price = int.Parse(infoParts[5]);

                    carManager.Open(id, raceType, length, route, price);
                }
                else
                {
                    var id = int.Parse(infoParts[1]);
                    var raceType = infoParts[2];
                    var length = int.Parse(infoParts[3]);
                    var route = infoParts[4];
                    var price = int.Parse(infoParts[5]);
                    var lastParam = int.Parse(infoParts[6]);

                    carManager.Open(id, raceType, length, route, price, lastParam);
                }
            }
            else if (typeOfCommand == "check")
            {
                var id = int.Parse(infoParts[1]);

                Console.WriteLine(carManager.Check(id));
            }
            else if (typeOfCommand == "start")
            {
                var id = int.Parse(infoParts[1]);

                Console.WriteLine(carManager.Start(id));
            }
            else if (typeOfCommand == "park")
            {
                var id = int.Parse(infoParts[1]);

                carManager.Park(id);
            }
            else if (typeOfCommand == "unpark")
            {
                var id = int.Parse(infoParts[1]);

                carManager.Unpark(id);
            }
            else if (typeOfCommand == "tune")
            {
                var tuneIndex = int.Parse(infoParts[1]);
                var addOn = infoParts[2];

                carManager.Tune(tuneIndex, addOn);
            }

            input = Console.ReadLine();
        }
    }
}

