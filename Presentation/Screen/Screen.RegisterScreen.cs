using static Presentation.Components.Components;

namespace Presentation.Screen;

public partial class Screen
{
    private void RegisterScreen()
    {
        const string title = "Register Screen";
        Console.Clear();
        Console.WriteLine(title);
        string username = TextInput("Input your username: ");
        string password = TextInput("Input your password: ");
        bool adminAccount = BooleanInput("Admin Account? ");
        if (userService.Register(username, password, adminAccount))
        {
            ContinueMessage("Account created");
        }
        else
        {
            ContinueMessage("Username is taken");
        }
    }
}