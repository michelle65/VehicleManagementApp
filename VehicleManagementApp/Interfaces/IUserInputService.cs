namespace VehicleManagement.Interfaces
{
    public interface IUserInputService
    {
        public void PrintMenu();
        public void InputVehicleComponents(out string brand, out string model, out int year);
        public int InputTruckComponent();
        public bool InputMotorcycleComponent();
        public int InputCarComponent();
        public void NoValidOption();

    }
}
