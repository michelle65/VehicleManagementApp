namespace VehicleManagement.Interfaces
{
    public interface IUserInputService
    {
        void PrintMenu();
        void InputVehicleComponents(out string brand, out string model, out int year);
        int InputTruckComponent();
        bool InputMotorcycleComponent();
        int InputElectricRange();
        int InputCarComponent();
        void NoValidOption();

    }
}
