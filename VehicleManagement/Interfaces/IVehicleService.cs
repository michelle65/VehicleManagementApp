namespace VehicleManagement.Interfaces
{
    public interface IVehicleService
    {
        void AddNewCar();
        void AddNewTruck();
        void AddNewMotorcycle();
        void AddNewElectricCar();
        void CheckVehicles();
        void PrintAllVehicles();
        void SaveJson();
        void LoadJson();

    }
}
