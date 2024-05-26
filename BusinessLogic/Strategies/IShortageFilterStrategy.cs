using Data.Model;

namespace BusinessLogic.Strategies;

public interface IShortageFilterStrategy
{
    IEnumerable<Shortage> Filter(IEnumerable<Shortage> shortages);
    string GetFilterInformation();
}