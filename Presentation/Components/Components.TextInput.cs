namespace Presentation.Components;

public static partial class Components
{
    public static string TextInput(string prompt)
    {
        const string emptyInput = "Cannot be empty";
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine(emptyInput);
        }
    }
}