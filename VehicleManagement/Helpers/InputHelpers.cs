namespace VehicleManagement.Helpers
{
    public static class InputHelpers
    {
        public static char NormalizeOption(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 'A';
            var c = char.ToUpperInvariant(input[0]);
            return c == 'A' || c == 'C' || c == 'M' || c == 'T' || c == 'E' ? c : 'A';
        }
    }
}
