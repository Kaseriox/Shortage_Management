using Data.Model.User;
using static Presentation.Components.Components;

namespace Presentation.Screen;

public partial class Screen
{
    private void LoginScreen()
    {
        const string title = "Login Screen";
        Console.Clear();
        Console.WriteLine(title);
        string username = TextInput("Input your username: ");
        string password = TextInput("Input your password: ");
        User? user = userService.Login(username, password);
        if (user is null)
        {
            ContinueMessage("Invalid credentials");
        }
        else
        {
            _user = user;
        }
    }
}