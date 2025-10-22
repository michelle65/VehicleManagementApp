using VehicleManagement.Interfaces;

namespace VehicleManagement.Services
{
    public class UserInputService : IUserInputService
    {
        private readonly IConsoleWrapper _console;

        public UserInputService(IConsoleWrapper console)
        {
            _console = console;
        }

        public void InputVehicleComponents(out string brand, out string model, out int year)
        {
            _console.WriteLine("*******************");
            _console.WriteLine("Please enter the brand:");
            brand = _console.ReadLine();
            brand = string.IsNullOrWhiteSpace(brand) ? "Unknown brand" : brand;
            _console.WriteLine("Please enter the model:");
            model = _console.ReadLine();
            model = string.IsNullOrWhiteSpace(model) ? "Unknown model" : model;
            _console.WriteLine("Please enter the year:");
            year = int.TryParse(_console.ReadLine(), out var parsedYear) ? parsedYear : 2000;
            _console.WriteLine();
        }

        public decimal InputTruckComponent()
        {

            _console.WriteLine("*******************");
            _console.WriteLine("Please enter the cargo capacity:");
            decimal cargoCapacity = decimal.TryParse(_console.ReadLine(), out var parsedCargoCapacity) ? parsedCargoCapacity : 0;
            return cargoCapacity;
        }

        public bool InputMotorcycleComponent()
        {
            _console.WriteLine("*******************");
            _console.WriteLine("Has sidecar? (true or false): ");
            bool hasSidecar = bool.TryParse(_console.ReadLine(), out var parsedValueSidecar) ? parsedValueSidecar : false;
            return hasSidecar;
        }

        public int InputCarComponent()
        {
            _console.WriteLine("*******************");
            _console.WriteLine("Please enter number of doors: ");
            int numberOfDoors = int.TryParse(_console.ReadLine(), out var parsedNumberOfCars) ? parsedNumberOfCars : 4;
            return numberOfDoors;
        }

        public int InputElectricRange()
        {
            _console.WriteLine("*******************");
            _console.WriteLine("Please enter battery range (km):");
            int batteryRange = int.TryParse(_console.ReadLine(), out var parsedBatteryRange) ? parsedBatteryRange : 0;
            return batteryRange;
        }

        public void PrintMenu()
        {
            _console.WriteLine("*******************");
            _console.WriteLine("**** - Welcome to the sample service ! ***");
            _console.WriteLine("Please select an operation.");
            _console.WriteLine("0.Exit program.");
            _console.WriteLine("1.Add new car.");
            _console.WriteLine("2.Add new motorcycle.");
            _console.WriteLine("3.Add new truck.");
            _console.WriteLine("4.Add new electric car.");
            _console.WriteLine("5.List vehicles (with filter).");
            _console.WriteLine("6.Check vehicles.");
            _console.WriteLine("7.Save vehicles to json file.");
            _console.WriteLine("8.Load vehicles to json file.");
            _console.WriteLine("*******************");
        }

        public void NoValidOption()
        {
            _console.WriteLine("*******************");
            _console.WriteLine("Invalid option.");
            _console.WriteLine("*******************");
        }
    }
}
