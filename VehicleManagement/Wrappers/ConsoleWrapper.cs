using VehicleManagement.Interfaces;

namespace VehicleManagement.Wrappers
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void Clear()
        {
            Console.Clear();
        }
        public void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        public void ResetColor()
        {
            Console.ResetColor();
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
