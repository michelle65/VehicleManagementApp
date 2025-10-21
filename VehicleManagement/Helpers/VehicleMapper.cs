using VehicleManagement.DTO_s;
using VehicleManagement.Models;

namespace VehicleManagement.Helpers
{
    public static class VehicleMapper
    {
        public static VehicleDto ToDto(Vehicle v) => v switch
        {
            ElectricCar ec => new VehicleDto
            {
                Type = VehicleType.ElectricCar,
                Brand = ec.Brand,
                Model = ec.Model,
                Year = ec.Year,
                NumberOfDoors = ec.NumberOfDoors,
                BatteryRangeKm = ec.BatteryRangeKm
            },
            Car c => new VehicleDto
            {
                Type = VehicleType.Car,
                Brand = c.Brand,
                Model = c.Model,
                Year = c.Year,
                NumberOfDoors = c.NumberOfDoors
            },
            Motorcycle m => new VehicleDto
            {
                Type = VehicleType.Motorcycle,
                Brand = m.Brand,
                Model = m.Model,
                Year = m.Year,
                HasSidecar = m.HasSidecar
            },
            Truck t => new VehicleDto
            {
                Type = VehicleType.Truck,
                Brand = t.Brand,
                Model = t.Model,
                Year = t.Year,
                CargoCapacity = t.CargoCapacity
            },
            _ => throw new NotSupportedException($"Unsupported vehicle: {v?.GetType().Name}")
        };

        public static Vehicle FromDto(VehicleDto d) => d.Type switch
        {
            VehicleType.ElectricCar => new ElectricCar
            {
                Brand = d.Brand,
                Model = d.Model,
                Year = d.Year,
                NumberOfDoors = d.NumberOfDoors ?? 4,
                BatteryRangeKm = d.BatteryRangeKm ?? 0
            },
            VehicleType.Car => new Car
            {
                Brand = d.Brand,
                Model = d.Model,
                Year = d.Year,
                NumberOfDoors = d.NumberOfDoors ?? 4
            },
            VehicleType.Motorcycle => new Motorcycle
            {
                Brand = d.Brand,
                Model = d.Model,
                Year = d.Year,
                HasSidecar = d.HasSidecar ?? false
            },
            VehicleType.Truck => new Truck
            {
                Brand = d.Brand,
                Model = d.Model,
                Year = d.Year,
                CargoCapacity = d.CargoCapacity ?? 0
            },
            _ => throw new NotSupportedException($"Unsupported DTO type: {d.Type}")
        };
    }
}
