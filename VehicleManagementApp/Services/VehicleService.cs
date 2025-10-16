using VehicleManagementApp.Interfaces;
using VehicleManagementApp.Models;
using VehicleManagementApp.Wrappers;

namespace VehicleManagementApp.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly List<Vehicle> _vehicles;
        private readonly IUserInputService _userInputService;
        IConsoleWrapper console = new ConsoleWrapper();

        public VehicleService(List<Vehicle> vehicles, IUserInputService userInputService)
        {
           _vehicles = vehicles;
           _userInputService = userInputService;

        }
        public void AddNewCar()
        {
            _userInputService.InputVehicleComponents(out string brand, out string model, out int year); 
            int numberOfDoors = _userInputService.InputCarComponent();
            _vehicles.Add(new Car { Brand = brand, Model = model, Year = year, NumberOfDoors = numberOfDoors });
        }
        public void AddNewTruck()
        {
            _userInputService.InputVehicleComponents(out string brand, out string model, out int year);
            int cargoCapacity = _userInputService.InputTruckComponent();
            _vehicles.Add(new Truck { Brand = brand, Model = model, Year = year, CargoCapacity = cargoCapacity });

        }
        public void AddNewMotorcycle()
        {
            _userInputService.InputVehicleComponents(out string brand, out string model, out int year);
            bool hasSidecar = _userInputService.InputMotorcycleComponent();
            _vehicles.Add(new Motorcycle { Brand = brand, Model = model, Year = year, HasSidecar = hasSidecar });
        }
        public void PrintAllVehicles()
        {
            console.WriteLine("*** Thank you for using our app ***");
            console.WriteLine("The cars in the database:");
            foreach (Vehicle vehicle in _vehicles)
            {
                console.WriteLine(vehicle.Brand + " " + vehicle.Model + " " + vehicle.Year);
            }
        }
        public void CheckVehicles()
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                vehicle.StartEngine();
                if (vehicle is IDriveable drivable)
                {
                    drivable.Drive();
                }
            }
        }
      
    }
}
