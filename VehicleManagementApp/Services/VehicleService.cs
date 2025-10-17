using System.Text.Json;
using VehicleManagement.Interfaces;
using VehicleManagement.Models;

namespace VehicleManagement.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly List<Vehicle> _vehicles;
        private readonly IUserInputService _userInputService;
        private IConsoleWrapper _console;

        const string DefaultFile = "vehicles.json";

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public VehicleService(List<Vehicle> vehicles, IUserInputService userInputService, IConsoleWrapper console)
        {
            _vehicles = vehicles;
            _userInputService = userInputService;
            _console = console;
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
        public void AddNewElectricCar()
        {
            _userInputService.InputVehicleComponents(out string brand, out string model, out int year);
            int batteryRangeKm = _userInputService.InputElectricRange();
            _vehicles.Add(new ElectricCar { Brand = brand, Model = model, Year = year, BatteryRangeKm = batteryRangeKm });
        }
        public void PrintAllVehicles()
        {
            _console.WriteLine("*** Thank you for using our app ***");
            _console.WriteLine("Filter by type: All/ (C)ar/ (M)otorcycle/ (T)ruck/ (E)lectricCar");
            string? userInput = _console.ReadLine() ?? string.Empty;
            char option = userInput.Length > 0 ? char.ToUpperInvariant(userInput[0]) : 'A';
           
            _console.WriteLine("*** Vehicles ***");
            for (int i = 0; i < _vehicles.Count; i++)
            {
                if(_vehicles.Count == 0)
                {
                    _console.WriteLine("No vehicles of this Type");
                }
                Vehicle vehicle = _vehicles[i];
                if (!MatchesFilter(vehicle, option))
                    continue;
                if(vehicle is ElectricCar)
                {
                    ElectricCar ec = (ElectricCar)vehicle;
                    _console.WriteLine($"[ElectricCar] {ec.Brand} {ec.Model} {ec.Year} | Doors: {ec.NumberOfDoors} | Range: {ec.BatteryRangeKm} km");
                }else if(vehicle.GetType()== typeof(Car))
                {
                    Car car = (Car)vehicle;
                    _console.WriteLine($"[Car] {car.Brand} {car.Model} {car.Year} | Doors: {car.NumberOfDoors}");
                }else if(vehicle is Motorcycle)
                {
                    Motorcycle motorcycle = (Motorcycle)vehicle;
                    _console.WriteLine($"[Motorcycle] {motorcycle.Brand} {motorcycle.Model} {motorcycle.Year} | Sidecar: {motorcycle.HasSidecar}");
                }
                else if (vehicle is Truck)
                {
                    Truck t = (Truck)vehicle;
                    _console.WriteLine($"[Truck] {t.Brand} {t.Model} {t.Year} | Capacity: {t.CargoCapacity}");
                }
                else
                {
                    _console.WriteLine($"[Vehicle] {vehicle.Brand} {vehicle.Model} {vehicle.Year}");
                }
            }

        }
        public void CheckVehicles()
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                vehicle.StartEngine();
                if (vehicle is IDriveable drivable) drivable.Drive();

            }
        }
        public void SaveJson()
        {
            string path = DefaultFile;
            _console.WriteLine($"Saving to {path} ...");
            var json = JsonSerializer.Serialize(_vehicles, jsonOptions);
            File.WriteAllText(path, json);
            _console.WriteLine("Saved.");
        }
        public void LoadJson()
        {

            string path = DefaultFile;
            if (!File.Exists(path))
            {
                _console.WriteLine($"File '{path}' not found.");
            }
            _console.WriteLine($"Loading from {path} ...");
            var json = File.ReadAllText(path);
            var loaded = JsonSerializer.Deserialize<List<Vehicle>>(json, jsonOptions) ?? new List<Vehicle>();
            _vehicles.AddRange(loaded);
            _console.WriteLine("Loaded.");
        }
        private static bool MatchesFilter(Vehicle vehicle, char choice)
        {
            switch (choice)
            {
                case 'C': return vehicle.GetType() == typeof(Car);
                case 'M': return vehicle is Motorcycle;
                case 'T': return vehicle is Truck;
                case 'E': return vehicle is ElectricCar;
                default: return true;
            }
        }
    }
}
