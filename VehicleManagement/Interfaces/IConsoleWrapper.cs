namespace VehicleManagement.Interfaces
{
    public interface IConsoleWrapper
    {
        public void Clear();
        public void Write(string message);
        public void WriteLine();
        public void WriteLine(string message);
        public void SetForegroundColor(ConsoleColor color);
        public string ReadLine();
        public void ResetColor();
    }
}
