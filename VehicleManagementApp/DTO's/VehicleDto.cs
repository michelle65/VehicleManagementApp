namespace VehicleManagement.DTO_s
{
    public class VehicleDto
    {
        public VehicleType Type { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }

        public int? NumberOfDoors { get; set; }   
        public bool? HasSidecar { get; set; }     
        public decimal? CargoCapacity { get; set; }   
        public int? BatteryRangeKm { get; set; }  
    }
}
