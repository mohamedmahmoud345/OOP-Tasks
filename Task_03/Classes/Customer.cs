namespace Task_03.Classes;

public class Customer
{
    public Customer(string id, string name, string phone, string email, string driversLicenseNumber)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        DriversLicenseNumber = driversLicenseNumber;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string DriversLicenseNumber { get; set; }

    public string GetCustomerInfo()
    {
        return $"---- Customer Info ----\n" +
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Phone: {Phone}\n" +
                $"Email: {Email}\n" +
                $"DriversLicenseNumber: {DriversLicenseNumber}\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Customer customer)
            return Id == customer.Id;
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
