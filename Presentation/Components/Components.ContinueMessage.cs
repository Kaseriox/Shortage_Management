namespace Presentation.Components;

public static partial class Components
{
    public static void ContinueMessage(string prompt)
    {
        const string continueMessage = " (Press any key to continue)";
        Console.WriteLine(string.Concat(prompt, continueMessage));
        Console.ReadKey();
    }
}