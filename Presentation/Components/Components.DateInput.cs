using System.Globalization;

namespace Presentation.Components;

public static partial class Components
{
    public static DateTime DateInput(string prompt)
    {
        const string incorrectInputMessage = "Invalid input. Please enter a date in the format MM/DD/YYYY";
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            DateTime userInput;
            if (DateTime.TryParseExact(input, "MM/dd/yyyy", null, DateTimeStyles.None, out userInput))
            {
                return userInput;
            }

            Console.WriteLine(incorrectInputMessage);
        }
    }
}