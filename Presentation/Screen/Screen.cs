using BusinessLogic.Interfaces;
using Data.Model.User;

namespace Presentation.Screen;

public partial class Screen(IShortageService shortageService, IUserService userService)
{
    private readonly IShortageService _shortageService = shortageService;
    private User? _user;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Starting Application");
        StartScreen();
    }
}