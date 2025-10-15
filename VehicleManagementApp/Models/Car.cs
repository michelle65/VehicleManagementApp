namespace VehicleManagementApp.Models
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public override string StartEngine()
        {
            return "The car engine starts with a key.";
        }
    }
}
