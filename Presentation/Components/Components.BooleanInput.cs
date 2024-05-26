namespace Presentation.Components;

public static partial class Components
{
    public static bool BooleanInput(string prompt)
    {
        const string instructions = "(Enter 1 for Yes and 0 for No): ";
        const string emptyMessage = "Cannot be empty";
        const string incorrectInputMessage = "Input must be 1 or 0";
        string finalPrompt = string.Concat(prompt, instructions);
        while (true)
        {
            Console.Write(finalPrompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(emptyMessage);
                continue;
            }

            if (int.TryParse(input, out int value) && value is 0 or 1)
            {
                return value == 1;
            }

            Console.WriteLine(incorrectInputMessage);
        }
    }
}