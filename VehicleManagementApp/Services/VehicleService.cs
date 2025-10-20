using VehicleManagement.Interfaces;
using VehicleManagement.Models;
using VehicleManagement.Repositories;
using VehicleManagementApp.Helpers;

namespace VehicleManagement.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly List<Vehicle> _vehicles;
        private readonly IUserInputService _userInputService;
        private readonly IConsoleWrapper _console;
        private readonly IVehicleRepository _repo;

        public VehicleService(
            List<Vehicle> vehicles,
            IUserInputService userInputService,
            IConsoleWrapper console,
            IVehicleRepository? repository = null)
        {
            _vehicles = vehicles ?? throw new ArgumentNullException(nameof(vehicles));
            _userInputService = userInputService ?? throw new ArgumentNullException(nameof(userInputService));
            _console = console ?? throw new ArgumentNullException(nameof(console));

            _repo = repository ?? new JsonFileVehicleRepository();

            var loaded = _repo.LoadOrSeed(out var info);
            ReplaceVehicles(loaded);
            _console.WriteLine(info);
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
            foreach (var v in filtered)
                _console.WriteLine(VehicleFormatter.FormatVehicleLine(v));
        }

        public void CheckVehicles()
        {
            foreach (var v in _vehicles)
            {
                v.StartEngine();
                if (v is IDriveable d) d.Drive();
            }
        }

        public void SaveJson()
        {
            _repo.Save(_vehicles);
            _console.WriteLine("Saved.");
        }

        public void LoadJson()
        {
            var loaded = _repo.LoadOrSeed(out var msg);
            ReplaceVehicles(loaded);
            _console.WriteLine(msg);

            _console.WriteLine("*** Vehicles (after load) ***");
            if (_vehicles.Count == 0) _console.WriteLine("No vehicles in the system yet.");
            foreach (var v in _vehicles)
                _console.WriteLine(VehicleFormatter.FormatVehicleLine(v));
        }

        private void ReplaceVehicles(IEnumerable<Vehicle> src)
        {
            _vehicles.Clear();
            _vehicles.AddRange(src);
        }
    }
}