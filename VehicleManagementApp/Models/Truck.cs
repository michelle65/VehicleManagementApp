namespace VehicleManagementApp.Models
{
    public class Truck : Vehicle
    {
        public decimal CargoCapacity { get; set; }
        public override string StartEngine()
        {
            return "The truck engine rumbles to life.";
        }
    }
}
