using VehicleManagement.Interfaces;

namespace VehicleManagement.Models
{
    public class Truck : Vehicle, IDriveable
    {
        public decimal CargoCapacity { get; set; }
        public void Drive()
        {
            Console.WriteLine("The truck is driving on city streets.");
        }

        public override string StartEngine()
        {
            return "The truck engine rumbles to life.";
        }
        public void Refuel()
        {
            Console.WriteLine($"The truck is being refueled .");
        }
    
    }
}
