using BusinessLogic.Interfaces;
using Data.Model.User;
using Data.Repository;

namespace BusinessLogic.Services;

public class UserService(IRepository<User> userRepository) : IUserService
{
    public User? Login(string username, string password)
    {
        return userRepository.GetAll().FirstOrDefault(user => user.Username == username && user.Password == password);
    }

    public bool Register(string username, string password, bool admin = false)
    {
        bool usernameTaken = userRepository.GetAll()
            .Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (usernameTaken)
        {
            return false;
        }

        User newUser;
        if (admin)
        {
            newUser = new Admin
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = password
            };
        }
        else
        {
            newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = password
            };
        }

        userRepository.Add(newUser);
        return true;
    }
}