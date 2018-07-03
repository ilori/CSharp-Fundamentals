using System;

public class CarFactory
{
    public static Car CreateCar(params object[] args)
    {
        var type = args[0].ToString();
        var brand = args[1].ToString();
        var model = args[2].ToString();
        var yearOfProduction = (int) args[3];
        var horsepower = (int) args[4];
        var acceleration = (int) args[5];
        var suspension = (int) args[6];
        var durability = (int) args[7];

        switch (type)
        {
            case "Performance":
                return new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension,
                    durability);
            case "Show":
                return new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension,
                    durability);
            default:
                throw new InvalidOperationException("Invalid Type of Car");
        }
    }
}