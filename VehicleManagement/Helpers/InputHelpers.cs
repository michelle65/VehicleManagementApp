namespace VehicleManagement.Helpers
{
    public static class InputHelpers
    {
        public static char NormalizeOption(string? inputTypeVehicle)
        {
            if (string.IsNullOrWhiteSpace(inputTypeVehicle)) return 'A';
            var vehicleType = char.ToUpperInvariant(inputTypeVehicle[0]);

            return vehicleType == 'A' || vehicleType == 'C' || vehicleType == 'M' || vehicleType == 'T' || vehicleType == 'E' ? vehicleType : 'A';
        }
    }
}
