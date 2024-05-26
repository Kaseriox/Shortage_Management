namespace Data.Model;

public record Shortage
{
    private readonly byte _priority;
    public required string Title { get; init; }
    public required string Name { get; init; }
    public required ShortageRoom ShortageRoom { get; init; }
    public required ShortageCategory ShortageCategory { get; init; }
    public required byte Priority
    {
        get => _priority;
        init
        {
            if (value is < 1 or > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 10");
            }

            _priority = value;
        }
    }
    public required DateTime CreatedOn { get; init; }
    public required Guid UserId { get; init; }
}

public enum ShortageRoom
{
    MeetingRoom,
    Kitchen,
    Bathroom
}

public enum ShortageCategory
{
    Electronics,
    Food,
    Other
}