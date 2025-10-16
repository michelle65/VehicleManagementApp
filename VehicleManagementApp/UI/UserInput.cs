namespace VehicleManagementApp.UI
{
    public static class UserInput
    {
       public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("**** - Welcome to the sample service ! ***");
            Console.WriteLine("Please select an operation.");
            Console.WriteLine("0.Exit program.");
            Console.WriteLine("1.Add new car.");
            Console.WriteLine("2.Add new motorcycle.");
            Console.WriteLine("3.Add new truck.");
        }
        public static void InputVehicleComponents(out string brand, out string model, out int year)
        {
            Console.WriteLine("Please enter the brand:");
            brand = Console.ReadLine();
            Console.WriteLine("Please enter the model:");
            model = Console.ReadLine();
            Console.WriteLine("Please enter the year:");
            year = Convert.ToInt32(Console.ReadLine());
        }

        public static int InputTruckComponent()
        {
            Console.WriteLine("Please enter the cargo capacity:");
            int cargoCapacity = Convert.ToInt32(Console.ReadLine());
            return cargoCapacity;
        }

        public static bool InputMotorcycleComponent()
        {
            Console.WriteLine("Has sidecar? (true or false): ");
            bool hasSidecar = Convert.ToBoolean(Console.ReadLine());
            return hasSidecar;
        }

        public static int InputCarComponent()
        {
            Console.WriteLine("Please enter number of doors: ");
            int numberOfDoors = Convert.ToInt32(Console.ReadLine());
            return numberOfDoors;
        }
    }
}
