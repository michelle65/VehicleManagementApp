using VehicleManagement.Interfaces;

namespace VehicleManagement.Services
{
    public class UserInputService : IUserInputService
    {
        private readonly IConsoleWrapper _console;
        public UserInputService(IConsoleWrapper console) => _console = console;
        public void PrintMenu()
        {
            _console.Clear();
            _console.WriteLine("**** - Welcome to the sample service ! ***");
            _console.WriteLine("Please select an operation.");
            _console.WriteLine("0.Exit program.");
            _console.WriteLine("1.Add new car.");
            _console.WriteLine("2.Add new motorcycle.");
            _console.WriteLine("3.Add new truck.");
            _console.WriteLine("4.Add new electric car.");
            _console.WriteLine("5.List vehices (with filter)");
            _console.WriteLine("6.Check vehicles ( with filter)");
            _console.WriteLine("7.Save to JSON");
            _console.WriteLine("8.Load to JSON");
        }
        public void InputVehicleComponents(out string brand, out string model, out int year)
        {
            _console.WriteLine("Please enter the brand:");
            brand = _console.ReadLine();
            _console.WriteLine("Please enter the model:");
            model = _console.ReadLine();
            _console.WriteLine("Please enter the year:");
            year = Convert.ToInt32(_console.ReadLine());
        }

        public int InputTruckComponent()
        {
            _console.WriteLine("Please enter the cargo capacity:");
            int cargoCapacity = Convert.ToInt32(_console.ReadLine());
            return cargoCapacity;
        }

        public bool InputMotorcycleComponent()
        {
            _console.WriteLine("Has sidecar? (true or false): ");
            bool hasSidecar = Convert.ToBoolean(_console.ReadLine());
            return hasSidecar;
        }

        public int InputCarComponent()
        {
            _console.WriteLine("Please enter number of doors: ");
            int numberOfDoors = Convert.ToInt32(_console.ReadLine());
            return numberOfDoors;
        }
        public int InputElectricRange()
        {
            _console.WriteLine("Please enter battery range (km):");
            int batteryRange = Convert.ToInt32(_console.ReadLine());
            return batteryRange;
        }
        public void NoValidOption()
        {
            _console.WriteLine("*******************");
            _console.WriteLine("Invalid option.");
            _console.WriteLine("*******************");

        }

    }
}
