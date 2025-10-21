using VehicleManagement.Models;

namespace VehicleManagement.Helpers
{
    public static class VehicleFormatter
    {
        public static string FormatVehicleLine(Vehicle v) => v switch
        {
            ElectricCar e => $"[ElectricCar] {e.Brand} {e.Model} {e.Year} | Doors: {e.NumberOfDoors} | Range: {e.BatteryRangeKm} km",
            Truck t => $"[Truck] {t.Brand} {t.Model} {t.Year} | Capacity: {t.CargoCapacity}",
            Motorcycle m => $"[Motorcycle] {m.Brand} {m.Model} {m.Year} | Sidecar: {m.HasSidecar}",
            Car c => $"[Car] {c.Brand} {c.Model} {c.Year} | Doors: {c.NumberOfDoors}",
            _ => $"[Vehicle] {v.Brand} {v.Model} {v.Year}"
        };

        public static string NoResultsMessage(char option) => option switch
        {
            'C' => "No Cars found.",
            'M' => "No Motorcycles found.",
            'T' => "No Trucks found.",
            'E' => "No Electric Cars found.",
            _ => "No vehicles in the system yet."
        };
    }
}
