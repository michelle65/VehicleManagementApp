using VehicleManagement.Models;

namespace VehicleManagement.Interfaces
{
    public interface IVehicleRepository
    {
        public List<Vehicle> LoadOrSeed(out string infoMessage);
        public void Save(IEnumerable<Vehicle> vehicles);
    }
}
