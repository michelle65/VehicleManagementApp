using VehicleManagementApp.Interfaces;
using VehicleManagementApp.Models;

List<Vehicle> vehicles =
[
    new Car { Brand = "Ford", Model = "Focus", Year = 2016, NumberOfDoors = 4 },
    new Car { Brand = "Skoda", Model = "Oktavia", Year = 2019, NumberOfDoors = 4 },
    new Truck { Brand = "Mercedes", Model = "Tavia", Year = 2020,CargoCapacity=12 },
    new Motorcycle { Brand = "Davison", Model = "Vison", Year = 2014,HasSidecar=true },
];

foreach(Vehicle vehicle in vehicles)
{
    vehicle.StartEngine();
    if(vehicle is IDriveable drivable)
    {
        drivable.Drive();
    }
}



