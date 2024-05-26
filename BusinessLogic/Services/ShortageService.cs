using BusinessLogic.Interfaces;
using BusinessLogic.Strategies;
using Data.Model;
using Data.Model.User;
using Data.Repository;

namespace BusinessLogic.Services;

public class ShortageService(IRepository<Shortage> shortageRepository) : IShortageService
{
    public IEnumerable<Shortage> GetShortages(User user, IShortageFilterStrategy? shortageFilterStrategy)
    {
        IEnumerable<Shortage> shortages = shortageRepository.GetAll();
        if (shortageFilterStrategy is not null)
        {
            shortages = shortageFilterStrategy.Filter(shortages);
        }

        if (user is Admin)
        {
            return shortages.ToList();
        }

        return shortages.Where(shortage => shortage.UserId == user.Id).ToList();
    }

    public bool AddShortage(Shortage newShortage)
    {
        IEnumerable<Shortage> shortages = shortageRepository.GetAll();
        Shortage? shortageInDatabase = shortages.FirstOrDefault(shortage =>
            shortage.Title == newShortage.Title && shortage.ShortageRoom == newShortage.ShortageRoom);

        if (shortageInDatabase is null)
        {
            shortageRepository.Add(newShortage);
            return true;
        }

        if (newShortage.Priority <= shortageInDatabase.Priority)
        {
            return false;
        }

        shortageRepository.Remove(shortageInDatabase);
        shortageRepository.Add(newShortage);
        return true;
    }

    public bool DeleteShortage(User user, Shortage shortage)
    {
        if (user is Admin)
        {
            shortageRepository.Remove(shortage);
            return true;
        }

        if (shortage.UserId == user.Id)
        {
            shortageRepository.Remove(shortage);
            return true;
        }

        return false;
    }
}