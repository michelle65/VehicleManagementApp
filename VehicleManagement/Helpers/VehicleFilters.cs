using VehicleManagement.Models;

namespace VehicleManagement.Helpers
{
    public static class VehicleFilters
    {
        public static IEnumerable<Vehicle> FilterByOption(IEnumerable<Vehicle> vehicles, char categoryCode) => categoryCode switch
        {
            'C' => vehicles.OfType<Car>(),
            'M' => vehicles.OfType<Motorcycle>(),
            'T' => vehicles.OfType<Truck>(),
            'E' => vehicles.OfType<ElectricCar>(),
            _ => vehicles
        };
    }
}
