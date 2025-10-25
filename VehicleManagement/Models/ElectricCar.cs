using VehicleManagement.Interfaces;

namespace VehicleManagement.Models
{
    public class ElectricCar : Car, IDriveable
    {
        public int BatteryRangeKm { get; set; }

        public override string StartEngine()
        {
            return "Driving an electric car...";
        }

        public override void Drive()
        {
            Console.WriteLine("The electric drives safely...");
        }
    }
}
