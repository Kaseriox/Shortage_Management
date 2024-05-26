using BusinessLogic.Strategies;
using Data.Model;
using Data.Model.User;

namespace BusinessLogic.Interfaces;

public interface IShortageService
{
    IEnumerable<Shortage> GetShortages(User user, IShortageFilterStrategy? shortageFilterStrategy);
    bool AddShortage(Shortage newShortage);
    bool DeleteShortage(User user, Shortage shortage);
}