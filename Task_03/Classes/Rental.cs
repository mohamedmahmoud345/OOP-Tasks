namespace Task_03.Classes;

public class Rental
{
    public Rental(string id, Customer customer, Vehicle vehicle, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Customer = customer;
        Vehicle = vehicle;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = true;
    }
    public Rental() { IsActive = true; }
    public string Id { get; set; }
    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; private set; }


    public int GetRentalDuration()
    {
        return EndDate.Day - StartDate.Day;
    }

    public decimal GetTotalCost()
    {
        var days = GetRentalDuration();
        return Vehicle.CalculateRentalCost(days);
    }
    public void CompleteRental()
    {
        if (!IsActive)
            throw new InvalidOperationException();

        IsActive = false;
    }
    public string GetRentalInfo()
    {
        return $"Rental created: {Id}\n" +
                $"Customer Name: {Customer.Name}\n" +
                $"Vehicle: {Vehicle.Year} {Vehicle.Make} {Vehicle.Model}\n" +
                $"Duration: {GetRentalDuration()} days\n" +
                $"Total Cost: ${GetTotalCost()}\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Rental rental)
            return Id == rental.Id &&
                    Customer.Id == rental.Customer.Id &&
                    Vehicle.Id == rental.Vehicle.Id;
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Customer.Id, Vehicle.Id);
    }
}
