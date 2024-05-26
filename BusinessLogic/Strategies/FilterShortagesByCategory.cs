using Data.Model;

namespace BusinessLogic.Strategies;

public class FilterShortagesByCategory(ShortageCategory category) : IShortageFilterStrategy
{
    public IEnumerable<Shortage> Filter(IEnumerable<Shortage> shortages)
    {
        return shortages.Where(shortage => shortage.ShortageCategory == category);
    }

    public string GetFilterInformation()
    {
        return $"Filtering by category: {category.ToString()}";
    }
}