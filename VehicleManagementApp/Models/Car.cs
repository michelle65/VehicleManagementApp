using VehicleManagementApp.Interfaces;

namespace VehicleManagementApp.Models
{
    public class Car : Vehicle, IDriveable
    {
        public int NumberOfDoors { get; set; }

        public void Drive()
        {
            Console.WriteLine("The car is driving on the road.");
        }

        public override string StartEngine()
        {
            return "The car engine starts with a key.";
        }
    }
}
