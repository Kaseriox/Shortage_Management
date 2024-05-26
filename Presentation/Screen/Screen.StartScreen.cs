using static Presentation.Components.Components;

namespace Presentation.Screen;

public partial class Screen
{
    private void StartScreen()
    {
        const string title = "Shortage Management Application";
        while (_user is null)
        {
            Console.Clear();
            Console.WriteLine(title);
            StartPageChoices choice = EnumSelection<StartPageChoices>("Actions");
            switch (choice)
            {
                case StartPageChoices.Login:
                    LoginScreen();
                    break;
                case StartPageChoices.Register:
                    RegisterScreen();
                    break;
                case StartPageChoices.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        MainScreen();
    }

    private enum StartPageChoices
    {
        Login,
        Register,
        Exit
    }
}