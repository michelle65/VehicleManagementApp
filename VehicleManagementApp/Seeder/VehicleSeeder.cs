using VehicleManagement.Models;

namespace VehicleManagement.Seeder
{
    public class VehicleSeeder
    {
        public static List<Vehicle> SeedInitialVehicles()
        {
            return new List<Vehicle>
            {
               new Car { Brand = "Ford", Model = "Focus", Year = 2016, NumberOfDoors = 4 },
               new Car { Brand = "Skoda", Model = "Oktavia", Year = 2019, NumberOfDoors = 4 },
               new Truck { Brand = "Mercedes", Model = "Tavia", Year = 2020, CargoCapacity = 12 },
               new Motorcycle { Brand = "Davison", Model = "Vison", Year = 2014, HasSidecar = true },

            };
        }
    }
}
