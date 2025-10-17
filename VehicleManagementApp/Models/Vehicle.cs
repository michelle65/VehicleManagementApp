namespace VehicleManagement.Models
{
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public virtual string  StartEngine()
        {
            return "The vehicle engine starts.";
        }
    }
}
