using System.Text.Json.Serialization;

namespace VehicleManagement.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Car), "car")]
    [JsonDerivedType(typeof(Motorcycle), "motorcycle")]
    [JsonDerivedType(typeof(Truck), "truck")]
    [JsonDerivedType(typeof(ElectricCar), "electric")]
    public abstract class Vehicle
    {
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required int Year { get; set; }

        protected Vehicle() { }

        public virtual string StartEngine()
        {
            return "The vehicle engine starts.";
        }
    }
}
