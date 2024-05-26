using Data.Model;

namespace BusinessLogic.Strategies;

public class FilterShortagesByRoom(ShortageRoom shortageRoom) : IShortageFilterStrategy
{
    public IEnumerable<Shortage> Filter(IEnumerable<Shortage> shortages)
    {
        return shortages.Where(shortage => shortage.ShortageRoom == shortageRoom);
    }

    public string GetFilterInformation()
    {
        return $"Filtering by room: {shortageRoom.ToString()}";
    }
}