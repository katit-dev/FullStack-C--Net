public static class InputHandler
{
    // method check integer input
    public static int CheckIntInput(string title, int min, int max)
    {
        int value;
        bool checkValue;
        do
        {
            Console.Write($"{title} ({min} - {max}): ");
            checkValue = int.TryParse(Console.ReadLine(), out value);
            if (!checkValue || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Please enter a valid integer between {min} and {max}.");
                Console.ResetColor();
            }
        }while(!checkValue || value < min || value > max);
        return value;
    }


    // method check string input
    public static string CheckStringInput(string title)
    {
        string? value;
        do
        {
            Console.Write($"{title}: ");
            value = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty. Please enter a valid string.");
                Console.ResetColor();
            }

        } while (string.IsNullOrWhiteSpace(value));
        return value;
    }

    // method check double input
    public static double CheckDoubleInput(string title, double min, double max)
    {
        double value;
        bool checkDouble;
        do
        {
            Console.Write($"{title} ({min} - {max}): ");
            checkDouble = double.TryParse(Console.ReadLine(), out value);
            if(!checkDouble || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Please enter a valid number between {min} and {max}.");
                Console.ResetColor();
            }
        } while (!checkDouble || value < min || value > max);
        return value;
    }
}