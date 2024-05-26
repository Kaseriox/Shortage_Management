using System.Text.RegularExpressions;

namespace Presentation.Components;

public static partial class Components
{
    public static T EnumSelection<T>(string prompt) where T : struct, Enum
    {
        const string enterNumberMessage = "Enter the number of your choice: ";
        const string invalidSelectionMessage = "Invalid selection";
        List<T> enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();

        Console.WriteLine(prompt);
        for (int i = 0; i < enumValues.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {AddSpacesToCamelCase(enumValues[i].ToString())}");
        }

        while (true)
        {
            Console.Write(enterNumberMessage);
            string? input = Console.ReadLine();

            int selectedIndex;
            if (int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= enumValues.Count)
            {
                return enumValues[selectedIndex - 1];
            }

            Console.WriteLine(invalidSelectionMessage);
        }
    }

    private static string AddSpacesToCamelCase(string input)
    {
        string result = MyRegex().Replace(input, " $1");
        return result;
    }

    [GeneratedRegex("(\\B[A-Z])")]
    private static partial Regex MyRegex();
}