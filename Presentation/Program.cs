using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Data.Model;
using Data.Model.User;
using Data.Repository;
using Data.Utils.JsonFileHandler;
using Presentation.Screen;

const string userJsonFileName = "user";
const string shortageJsonFileName = "shortage";
IJsonFileHandler jsonFileHandler = new JsonFileHandler();
IRepository<User> userRepository = new JsonRepository<User>(jsonFileHandler, userJsonFileName);
IRepository<Shortage> shortageRepository = new JsonRepository<Shortage>(jsonFileHandler, shortageJsonFileName);
IUserService userService = new UserService(userRepository);
IShortageService shortageService = new ShortageService(shortageRepository);
try
{
    new Screen(shortageService, userService).Start();
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadKey();
}