using VehicleManagementApp.Interfaces;

namespace VehicleManagementApp.Models
{
    public class Motorcycle : Vehicle, IDriveable
    {
        public bool HasSidecar { get; set; }

        public void Drive()
        {
            Console.WriteLine("The motorcycle is driving in the park.");
        }

        public override string StartEngine()
        {
            return "The motorcycle engine starts with a button.";
        }
    }
}
