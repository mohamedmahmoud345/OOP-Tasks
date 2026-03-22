namespace Task_03.Classes;

public class Vehicle
{
    public Vehicle(string id, string make, string model, int year, decimal dailyRate)
    {
        Id = id;
        Make = make;
        Model = model;
        Year = year;
        DailyRate = dailyRate;
        IsAvailable = true;
    }

    public string Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsAvailable { get; private set; }


    public string GetVehicleInfo()
    {
        var availabilityStatus = IsAvailable ? "Available" : "Rented";
        return
            $"{Id} - {Year} {Make} {Model} - {DailyRate} - {availabilityStatus}";
    }

    public void Rent()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("the car is already rented");
        IsAvailable = false;
    }
    public void ReturnVehicle() => IsAvailable = true;
    public decimal CalculateRentalCost(int days)
    {
        return days * DailyRate;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vehicle vehicle)
            return Id == vehicle.Id;
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
