using VehicleManagementApp.Interfaces;
using VehicleManagementApp.Models;
using VehicleManagementApp.UI;

List<Vehicle> vehicles = new List<Vehicle>();
vehicles.Add(new Car { Brand = "Ford", Model = "Focus", Year = 2016, NumberOfDoors = 4 });
vehicles.Add(new Car { Brand = "Skoda", Model = "Oktavia", Year = 2019, NumberOfDoors = 4 });
vehicles.Add(new Truck { Brand = "Mercedes", Model = "Tavia", Year = 2020, CargoCapacity = 12 });
vehicles.Add(new Motorcycle { Brand = "Davison", Model = "Vison", Year = 2014, HasSidecar = true });

foreach (Vehicle vehicle in vehicles)
{
    vehicle.StartEngine();
    if (vehicle is IDriveable drivable)
    {
        drivable.Drive();
    }
}
int choice = -1;
while (choice != 0)
{
    try
    {
        UserInput.PrintMenu();
        choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 0)
        {
            break;
        }

        switch (choice)
        {
            case 1:
                AddNewCar();
                break;
            case 2:
                AddNewMotorcycle();
                break;
            case 3:
                AddNewTruck();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
GetAllVehicles();
void GetAllVehicles()
{
    Console.WriteLine("*** Thank you for using our app ***");
    Console.WriteLine("The cars in the database:");
    foreach (Vehicle vehicle in vehicles)
    {
        Console.WriteLine(vehicle.Brand + " " + vehicle.Model + " " + vehicle.Year);
    }

}

void AddNewTruck()
{
    UserInput.InputVehicleComponents(out string brand, out string model, out int year);
    int cargoCapacity = UserInput.InputTruckComponent();
    vehicles.Add(new Truck { Brand = brand, Model = model, Year = year, CargoCapacity = cargoCapacity });
}

void AddNewMotorcycle()
{
    UserInput.InputVehicleComponents(out string brand, out string model, out int year);
    bool hasSidecar = UserInput.InputMotorcycleComponent();
    vehicles.Add(new Motorcycle { Brand = brand, Model = model, Year = year, HasSidecar = hasSidecar });
}

void AddNewCar()
{
    UserInput.InputVehicleComponents(out string brand, out string model, out int year);
    int numberOfDoors = UserInput.InputCarComponent();
    vehicles.Add(new Car { Brand = brand, Model = model, Year = year, NumberOfDoors = numberOfDoors });
}

