using System;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        var carInfo = Console.ReadLine().Split().ToList();
        var truckInfo = Console.ReadLine().Split().ToList();

        var carFuelQuantity = double.Parse(carInfo[1]);
        var carFuelConsumption = double.Parse(carInfo[2]);
        var car = new Car(carFuelQuantity, carFuelConsumption);

        var truckFuelQuantity = double.Parse(truckInfo[1]);
        var truckFuelConsupmtion = double.Parse(truckInfo[2]);
        var truck = new Truck(truckFuelQuantity, truckFuelConsupmtion);

        var n = int.Parse(Console.ReadLine());

        var sb = new StringBuilder();
        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split().ToList();

            var command = tokens[0];
            var vehicleType = tokens[1];


            switch (command.ToLower())
            {
                case "drive":
                    switch (vehicleType.ToLower())
                    {
                        case "car":

                            sb.AppendLine(car.Drive(double.Parse(tokens[2])));
                            break;
                        case "truck":
                            sb.AppendLine(truck.Drive(double.Parse(tokens[2])));
                            break;
                    }

                    break;
                case "refuel":
                    switch (vehicleType.ToLower())
                    {
                        case "car":
                            car.Refuel(double.Parse(tokens[2]));
                            break;
                        case "truck":
                            truck.Refuel(double.Parse(tokens[2]));
                            break;
                    }

                    break;
            }
        }

        Console.WriteLine(sb.ToString().TrimEnd());
        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }
}