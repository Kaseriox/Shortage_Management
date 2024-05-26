namespace Presentation.Components;

public static partial class Components
{
    public static int InputNumberWithinRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write($"{prompt} (Enter a number between {min} and {max}): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int userInput) && userInput >= min && userInput <= max)
            {
                return userInput;
            }

            Console.WriteLine("Invalid input. Please enter a number within the specified range.");
        }
    }
}