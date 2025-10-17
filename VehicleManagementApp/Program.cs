using VehicleManagement.Interfaces;
using VehicleManagement.Models;
using VehicleManagement.Seeder;
using VehicleManagement.Services;
using VehicleManagement.Wrappers;

List<Vehicle> vehicles = VehicleSeeder.SeedInitialVehicles();

IConsoleWrapper console = new ConsoleWrapper();
IUserInputService userInputService = new UserInputService(console);
IVehicleService vehicleService = new VehicleService(vehicles, userInputService);

int choice = -1;
while (choice != 0)
{
    try
    {
        userInputService.PrintMenu();
        choice = Convert.ToInt32(console.ReadLine());

        if (choice == 0)
        {
            break;
        }

        switch (choice)
        {
            case 1:
                vehicleService.AddNewCar();
                break;
            case 2:
                vehicleService.AddNewMotorcycle();
                break;
            case 3:
                vehicleService.AddNewTruck();
                break;
            default:
                userInputService.NoValidOption();
                break;
        }
    }
    catch (Exception ex)
    {
        console.WriteLine(ex.Message);
    }
}

console.WriteLine();
vehicleService.CheckVehicles();
console.WriteLine();
vehicleService.PrintAllVehicles();


