namespace VehicleManagement.Interfaces
{
    public interface IConsoleWrapper
    {
        void Clear();
        void Write(string message);
        void WriteLine();
        void WriteLine(string message);
        void SetForegroundColor(ConsoleColor color);
        string ReadLine();
        void ResetColor();
    }
}
