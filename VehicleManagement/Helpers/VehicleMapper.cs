using VehicleManagement.Dtos;
using VehicleManagement.Models;

namespace VehicleManagement.Helpers
{
    public static class VehicleMapper
    {
        public static Vehicle FromDto(VehicleDto vehicleDto)
        {
            if (vehicleDto is ElectricCarDto) { return FromDto((ElectricCarDto)vehicleDto); }
            if (vehicleDto is CarDto) { return FromDto((CarDto)vehicleDto); }
            if (vehicleDto is MotorcycleDto) { return FromDto((MotorcycleDto)vehicleDto); }
            if (vehicleDto is TruckDto) { return FromDto((TruckDto)vehicleDto); }
            throw new NotSupportedException("Not supported type");
        }

        public static Vehicle ToDto(VehicleDto vehicleDto)
        {
            if (vehicleDto is ElectricCarDto) { return ToDto((ElectricCarDto)vehicleDto); }
            if (vehicleDto is CarDto) { return ToDto((CarDto)vehicleDto); }
            if (vehicleDto is MotorcycleDto) { return ToDto((MotorcycleDto)vehicleDto); }
            if (vehicleDto is TruckDto) { return ToDto((TruckDto)vehicleDto); }
            throw new NotSupportedException("Not supported type");
        }

        public static ElectricCar ToDto(ElectricCarDto ec) => new()
        {
            Brand = ec.Brand,
            Model = ec.Model,
            Year = ec.Year,
            NumberOfDoors = ec.NumberOfDoors,
            BatteryRangeKm = ec.BatteryRangeKm,
        };
        public static Car ToDto(CarDto c) => new()
        {
            Brand = c.Brand,
            Model = c.Model,
            Year = c.Year,
            NumberOfDoors = c.NumberOfDoors
        };
        public static Motorcycle ToDto(MotorcycleDto m) => new()
        {
            Brand = m.Brand,
            Model = m.Model,
            Year = m.Year,
            HasSidecar = m.HasSidecar,
        };
        public static Truck ToDto(TruckDto t) => new()
        {
            Brand = t.Brand,
            Model = t.Model,
            Year = t.Year,
            CargoCapacity = t.CargoCapacity,
        };

        public static ElectricCar FromDto(ElectricCarDto ec) => new()
        {
            Brand = ec.Brand,
            Model = ec.Model,
            Year = ec.Year,
            NumberOfDoors = ec.NumberOfDoors,
            BatteryRangeKm = ec.BatteryRangeKm
        };
        public static Car FromDto(CarDto car) => new()
        {
            Brand = car.Brand,
            Model = car.Model,
            Year = car.Year,
            NumberOfDoors = car.NumberOfDoors
        };
        public static Motorcycle FromDto(MotorcycleDto motorcycle) => new()
        {
            Brand = motorcycle.Brand,
            Model = motorcycle.Model,
            Year = motorcycle.Year,
            HasSidecar = motorcycle.HasSidecar
        };
        public static Truck FromDto(TruckDto truck) => new()
        {
            Brand = truck.Brand,
            Model = truck.Model,
            Year = truck.Year,
            CargoCapacity = truck.CargoCapacity
        };
    }
}
