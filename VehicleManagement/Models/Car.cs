using VehicleManagement.Interfaces;

namespace VehicleManagement.Models
{
    public class Car : Vehicle, IDriveable
    {
        public int NumberOfDoors { get; set; }

        public Car() { }
        public override string StartEngine()
        {
            return "The car engine starts with a key.";
        }

        public virtual void Drive()
        {
            Console.WriteLine("The car is driving on the road.");
        }
    }
}
