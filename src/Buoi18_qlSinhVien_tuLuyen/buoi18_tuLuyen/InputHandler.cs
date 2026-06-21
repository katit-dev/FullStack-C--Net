public static class InputHandler
{

    // kiem tra input interger
    /// </summary>
    /// This method would check if integer is valid or not
    /// prompt: message to display to the user
    /// min: minimum acceptable value
    /// max: maximum acceptable value
    /// <returns></returns>
    public static int NhapSoNguyen(string prompt, int min, int max)
    {
        int value;
        bool isValid;
        do
        {
            Console.Write($"{prompt} ({min}-{max}): ");
            string input = Console.ReadLine() ?? "";
            isValid = int.TryParse(input, out value);
            if (!isValid || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vui long nhap tu {min} den {max}.");
                Console.ResetColor();
            }

        } while (!isValid || value < min || value > max);
        return value;

    }

    // kiem tra input double
    public static double NhapSoThu(string prompt, double min, double max)
    {
        double value;
        bool isValid;
        do
        {
            Console.Write($"{prompt} ({min}-{max}): ");
            string input = Console.ReadLine() ?? "";
            isValid = double.TryParse(input, out value);
            if (!isValid || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vui long nhap tu {min} den {max}.");
                Console.ResetColor();
            }
        } while (!isValid || value < min || value > max);

        return value;
    }


    // kiem tra input string
    public static string NhapChuoi(string prompt)
    {
        string input;
        do
        {
            Console.Write($"{prompt}: ");
            input = Console.ReadLine() ?? "";
            if(string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vui long nhap khong duoc de trong.");
                Console.ResetColor();
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
}