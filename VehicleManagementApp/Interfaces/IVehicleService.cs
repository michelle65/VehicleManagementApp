namespace VehicleManagement.Interfaces
{
    public interface IVehicleService
    {
        public void AddNewCar();
        public void AddNewTruck();
        public void AddNewMotorcycle();
        public void AddNewElectricCar();
        public void PrintAllVehicles();
        public void SaveJson();
        public void LoadJson();
        public void CheckVehicles();
       
    }
}
