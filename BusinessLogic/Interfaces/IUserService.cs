using Data.Model.User;

namespace BusinessLogic.Interfaces;

public interface IUserService
{
    User? Login(string username, string password);
    bool Register(string username, string password, bool admin = false);
}