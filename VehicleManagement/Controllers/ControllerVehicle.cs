using VehicleManagement.Interfaces;

namespace VehicleManagement.Controllers
{
    public class ControllerVehicle
    {
        private readonly IConsoleWrapper _console;
        private readonly IUserInputService _userInputService;
        private readonly IVehicleService _vehicleService;

        public ControllerVehicle(IConsoleWrapper console, IUserInputService userInputService, IVehicleService vehicleService)
        {
            _console = console;
            _userInputService = userInputService;
            _vehicleService = vehicleService;
        }

        public void RunService()
        {
            int choice = -1;
            while (choice != 0)
            {
                try
                {
                    _userInputService.PrintMenu();
                    choice = int.TryParse(_console.ReadLine(), out int parsedChoice) ? parsedChoice: -1;

                    if (choice == 0)
                    {
                        break;
                    }

                    switch (choice)
                    {
                        case 1: _vehicleService.AddNewCar(); break;
                        case 2: _vehicleService.AddNewMotorcycle(); break;
                        case 3: _vehicleService.AddNewTruck(); break;
                        case 4: _vehicleService.AddNewElectricCar(); break;
                        case 5: _vehicleService.PrintAllVehicles(); break;
                        case 6: _vehicleService.CheckVehicles(); break;
                        case 7: _vehicleService.SaveJson(); break;
                        case 8: _vehicleService.LoadJson(); break;
                        default: _userInputService.NoValidOption(); break;
                    }
                }
                catch (Exception ex)
                {
                    _console.WriteLine(ex.Message);
                    _console.WriteLine("Invalid input. Please enter a number between 0–8.");
                }
            }
        }
    }
}
