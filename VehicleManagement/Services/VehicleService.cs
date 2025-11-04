using VehicleManagement.Helpers;
using VehicleManagement.Interfaces;
using VehicleManagement.Models;

namespace VehicleManagement.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly List<Vehicle> _vehicles;
        private readonly IUserInputService _userInputService;
        private readonly IConsoleWrapper _console;
        private readonly IVehicleRepository _repo;

        public VehicleService(List<Vehicle> vehicles, IUserInputService userInputService, IConsoleWrapper console, IVehicleRepository repository)
        {
            _vehicles = vehicles;
            _userInputService = userInputService;
            _console = console;
            _repo = repository;

            EnsureVehiclesLoaded();
        }

        public void AddNewCar()
        {
            _userInputService.InputVehicleComponents(out var brand, out var model, out var year);
            var doors = _userInputService.InputCarComponent();
            _vehicles.Add(new Car { Brand = brand, Model = model, Year = year, NumberOfDoors = doors });
        }

        public void AddNewTruck()
        {
            _userInputService.InputVehicleComponents(out var brand, out var model, out var year);
            var capacity = _userInputService.InputTruckComponent();
            _vehicles.Add(new Truck { Brand = brand, Model = model, Year = year, CargoCapacity = capacity });
        }

        public void AddNewMotorcycle()
        {
            _userInputService.InputVehicleComponents(out var brand, out var model, out var year);
            var sidecar = _userInputService.InputMotorcycleComponent();
            _vehicles.Add(new Motorcycle { Brand = brand, Model = model, Year = year, HasSidecar = sidecar });
        }

        public void AddNewElectricCar()
        {
            _userInputService.InputVehicleComponents(out var brand, out var model, out var year);
            var doors = _userInputService.InputCarComponent();
            var range = _userInputService.InputElectricRange();
            _vehicles.Add(new ElectricCar { Brand = brand, Model = model, Year = year, NumberOfDoors = doors, BatteryRangeKm = range });
        }

        public void CheckVehicles()
        {
            _console.WriteLine("*** Vehicle check ***");
            foreach (var vehicle in _vehicles)
            {
                _console.WriteLine(vehicle.StartEngine());
                if (vehicle is IDriveable drivable) drivable.Drive();
            }
            _console.WriteLine("*** Vehicle checks completed ***");
        }

        public void PrintAllVehicles()
        {
            _console.WriteLine("*** * ***");
            _console.WriteLine("Filter: (A)ll / (C)ar / (M)otorcycle / (T)ruck / (E)lectricCar");
            _console.WriteLine("Please select one option: A / C / M / T / E");

            var option = InputHelpers.NormalizeOption(_console.ReadLine());

            if (_vehicles.Count == 0)
            {
                _console.WriteLine(VehicleFormatter.NoResultsMessage(option));
                return;
            }

            var filtered = VehicleFilters.FilterByOption(_vehicles, option);
            if (!filtered.Any())
            {
                _console.WriteLine(VehicleFormatter.NoResultsMessage(option));
                return;
            }

            _console.WriteLine("*** Vehicles ***");
            foreach (var vehicle in filtered)
            {
                _console.WriteLine(VehicleFormatter.FormatVehicleLine(vehicle));
            }
        }

        public void LoadVehicles()
        {
            var loaded = _repo.LoadOrSeed(out var msg);
            ReplaceVehicles(loaded);
            _console.WriteLine(msg);

            _console.WriteLine("*** Vehicles (after load) ***");
            if (_vehicles.Count == 0) _console.WriteLine("No vehicles in the system yet.");
            foreach (var vehicle in _vehicles)
                _console.WriteLine(VehicleFormatter.FormatVehicleLine(vehicle));
        }

        public void SaveVehicles()
        {
            _repo.Save(_vehicles);
            _console.WriteLine("Vehicle(s) saved!");
            _console.WriteLine();
        }

        private void EnsureVehiclesLoaded()
        {
            var loaded = _repo.LoadOrSeed(out var info);
            ReplaceVehicles(loaded);
            _console.WriteLine(info);
        }

        private void ReplaceVehicles(IEnumerable<Vehicle> vehicles)
        {
            _vehicles.Clear();
            _vehicles.AddRange(vehicles);
        }
    }
}