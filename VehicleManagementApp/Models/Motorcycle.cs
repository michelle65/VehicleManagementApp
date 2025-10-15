namespace VehicleManagementApp.Models
{
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }
        public override string StartEngine()
        {
            return "The motorcycle engine starts with a button.";
        }
    }
}
