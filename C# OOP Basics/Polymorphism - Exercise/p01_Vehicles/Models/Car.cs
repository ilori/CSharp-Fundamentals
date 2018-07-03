public class Car : IVehicle
{
    private const double AirConditioner = 0.9;


    public Car(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; private set; }
    public double FuelConsumption { get; }

    public string Drive(double distance)
    {
        var fuelNeeded = this.FuelConsumption * distance + AirConditioner * distance;
        if (this.FuelQuantity - fuelNeeded >= 0)
        {
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        else
        {
            return $"{this.GetType().Name} needs refueling";
        }
    }

    public void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }
}