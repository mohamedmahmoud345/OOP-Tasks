namespace Task_03.Classes;

public class RentalAgency
{
    public string AgencyName { get; set; }
    public HashSet<Vehicle> Vehicles { get; private set; } = new();
    public HashSet<Customer> Customers { get; private set; } = new();
    public HashSet<Rental> Rentals { get; private set; } = new();
    public RentalAgency(string agencyName)
    {
        AgencyName = agencyName;
    }

    public bool AddVehicle(Vehicle vehicle)
    {
        if (Vehicles.Contains(vehicle))
            return false;

        Vehicles.Add(vehicle);
        return true;
    }

    public bool RegisterCustomer(Customer customer)
    {
        if (Customers.Contains(customer))
            return false;

        Customers.Add(customer);
        return true;
    }

    public List<Vehicle> GetAvailableVehicles()
    {
        if (!Vehicles.Any())
            return [];
        return Vehicles.ToList();
    }

    public Rental CreateRental(string id , Customer customer, Vehicle vehicle, int days)
    {
        var rental = new Rental()
        {
            Id = $"{id}",
            Customer = customer,
            Vehicle = vehicle,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(days)
        };

        Rentals.Add(rental);

        return rental;
    }

    public bool CompleteRental(string rentalId)
    {
        var rental = Rentals.FirstOrDefault(x => x.Id == rentalId);
        if (rental is null)
            return false;

        rental.CompleteRental();
        Console.WriteLine($"Vehicle {rental.Vehicle.Year} {rental.Vehicle.Make} {rental.Vehicle.Model} is now available");
        return true;
    }

    public List<Rental> GetActiveRentals()
    {
        var rentals = Rentals.Where(x => x.IsActive == true);
        if (!rentals.Any())
            return [];

        return rentals.ToList();
    }

    public List<Rental> GetCustomerRental(string customerId)
    {
        var customer = Customers.FirstOrDefault(x => x.Id == customerId);
        if (customer is null)
            throw new NullReferenceException(nameof(customerId));

        var rentals = Rentals.Where(x => x.Customer.Id == customerId);
        if (!rentals.Any())
            return [];

        return rentals.ToList();
    }

    public void DisplayFleet()
    {
        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine(vehicle.GetVehicleInfo());
        }
    }
}
