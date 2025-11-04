using Microsoft.Extensions.Configuration;
using VehicleManagement.Controllers;
using VehicleManagement.Interfaces;
using VehicleManagement.Repositories;
using VehicleManagement.Seeder;
using VehicleManagement.Services;
using VehicleManagement.Wrappers;

var vehicles = VehicleSeeder.SeedInitialVehicles();

IConsoleWrapper console = new ConsoleWrapper();
IUserInputService userInputService = new UserInputService(console);
IConfiguration config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

IVehicleRepository repository = new JsonFileVehicleRepository(config);
IVehicleService vehicleService = new VehicleService(vehicles, userInputService, console,repository);

var controller = new VehicleController(console, userInputService, vehicleService);
controller.RunService();