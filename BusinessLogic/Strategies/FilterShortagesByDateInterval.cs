using System.Globalization;
using Data.Model;

namespace BusinessLogic.Strategies;

public class FilterShortagesByDateInterval(DateTime from, DateTime to) : IShortageFilterStrategy
{
    public IEnumerable<Shortage> Filter(IEnumerable<Shortage> shortages)
    {
        return shortages.Where(shortage => shortage.CreatedOn >= from && shortage.CreatedOn <= to);
    }

    public string GetFilterInformation()
    {
        return
            $"Filtering based on date from {from.ToString(CultureInfo.CurrentCulture)} to {to.ToString(CultureInfo.CurrentCulture)}";
    }
}