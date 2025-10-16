namespace VehicleManagementApp.Interfaces
{
    public interface IConsoleWrapper
    {
        void Write(string message);
        void WriteLine();
        void SetForegroundColor(ConsoleColor color);
        void WriteLine(string message);
        string ReadLine();
        void ResetColor();
        void Clear();
    }
}
