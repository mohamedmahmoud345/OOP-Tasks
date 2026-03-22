using Task_03.Classes;

var agency = new RentalAgency("Prime Car Rentals");

// add behicles to fleet
var car1 = new Vehicle("V001", "Toyota", "Camry", 2022, 45.00m);
var car2 = new Vehicle("V002", "Honda", "Accord", 2023, 50.00m);
var car3 = new Vehicle("V003", "Tesla", "Model 3", 2023, 85.00m);


agency.AddVehicle(car1);
agency.AddVehicle(car2);
agency.AddVehicle(car3);


// register customers

var customer1 = new Customer("C001", "Alice Johnson", "555-0123",
                        "alice@email.com", "DL123456");
var customer2 = new Customer("C002", "Bob Smith", "555-0456",
                        "bob@email.com", "DL789012");

agency.RegisterCustomer(customer1);
agency.RegisterCustomer(customer2);

// display availalbe vehicles
agency.DisplayFleet();

// create Rentals
var rental1 = agency.CreateRental("R001", customer1, car1, 5);
Console.WriteLine($"Rental Created: {rental1.Id}");
Console.WriteLine($"Total Cost: ${rental1.GetTotalCost()}");

var rental2 = agency.CreateRental("R002", customer2, car3, 3);
Console.WriteLine($"Rental Created: {rental2.Id}");
Console.WriteLine($"Total Cost: ${rental2.GetTotalCost()}");

// complete a rental 
agency.CompleteRental(rental1.Id);
System.Console.WriteLine($"Rental {rental1.Id} completed!");

// display customer rental history
var customerRentals = agency.GetCustomerRental("C001");
System.Console.WriteLine($"Alice's rental history: {customerRentals.Count} rental(s)");