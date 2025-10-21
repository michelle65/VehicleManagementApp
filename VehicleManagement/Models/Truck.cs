using VehicleManagement.Interfaces;

namespace VehicleManagement.Models
{
    public class Truck : Vehicle, IDriveable, IRefuelable
    {
        public decimal CargoCapacity { get; set; }
        public Truck() { }
        public void Drive()
        {
            Console.WriteLine("The truck is driving on city streets.");
        }
        public override string StartEngine()
        {
            return "The truck engine drives on the road.";
        }
        public void Refuel()
        {
            Console.WriteLine($"The truck is being refueled.");
        }

    }
}
