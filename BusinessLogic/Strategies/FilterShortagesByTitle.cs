using Data.Model;

namespace BusinessLogic.Strategies;

public class FilterShortagesByTitle(string title) : IShortageFilterStrategy
{
    public IEnumerable<Shortage> Filter(IEnumerable<Shortage> shortages)
    {
        return shortages.Where(shortage => shortage.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public string GetFilterInformation()
    {
        return $"Filtering by title: {title}";
    }
}