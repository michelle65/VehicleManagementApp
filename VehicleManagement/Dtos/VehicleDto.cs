using System.Text.Json.Serialization;

namespace VehicleManagement.Dtos
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(CarDto), "car")]
    [JsonDerivedType(typeof(MotorcycleDto), "motorcycle")]
    [JsonDerivedType(typeof(TruckDto), "truck")]
    [JsonDerivedType(typeof(ElectricCarDto), "electric")]
    public class VehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
