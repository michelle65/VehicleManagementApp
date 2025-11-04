namespace VehicleManagement.Helpers
{
    public static class InputHelpers
    {
        public static char NormalizeOption(string? inputVehicleType)
        {
            if (string.IsNullOrWhiteSpace(inputVehicleType)) return 'A';
            var vehicleType = char.ToUpperInvariant(inputVehicleType[0]);

            return vehicleType == 'A' || vehicleType == 'C' || vehicleType == 'M' || vehicleType == 'T' || vehicleType == 'E' ? vehicleType : 'A';
        }
    }
}
