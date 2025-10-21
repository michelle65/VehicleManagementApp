using VehicleManagement.Models;

namespace VehicleManagement.Helpers
{
    public static class VehicleFilters
    {
        public static IEnumerable<Vehicle> FilterByOption(IEnumerable<Vehicle> source, char option) => option switch
        {
            'C' => source.OfType<Car>(),
            'M' => source.OfType<Motorcycle>(),
            'T' => source.OfType<Truck>(),
            'E' => source.OfType<ElectricCar>(),
            _ => source
        };
    }
}
