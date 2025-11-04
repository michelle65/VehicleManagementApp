namespace VehicleManagement.Interfaces
{
    public interface IVehicleService
    {
        public void AddNewCar();
        public void AddNewTruck();
        public void AddNewMotorcycle();
        public void AddNewElectricCar();
        public void CheckVehicles();
        public void PrintAllVehicles();
        public void SaveVehicles();
        public void LoadVehicles();
    }
}
