using VehicleManagement.Controllers;
using VehicleManagement.Interfaces;
using VehicleManagement.Seeder;
using VehicleManagement.Services;
using VehicleManagement.Wrappers;

var vehicles = VehicleSeeder.SeedInitialVehicles();

IConsoleWrapper console = new ConsoleWrapper();
IUserInputService userInputService = new UserInputService(console);
IVehicleService vehicleService = new VehicleService(vehicles, userInputService, console);

var controller = new ControllerVehicle(console, userInputService, vehicleService);

controller.RunService();