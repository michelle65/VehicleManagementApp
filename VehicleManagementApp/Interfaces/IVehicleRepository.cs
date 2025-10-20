using VehicleManagement.Models;

namespace VehicleManagement.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> LoadOrSeed(out string infoMessage);
        void Save(IEnumerable<Vehicle> vehicles);
    }
}
