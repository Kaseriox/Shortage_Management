using Data.Model;

namespace Tests.Generators;

public static class ShortageGenerator
{
    public static List<Shortage> GenerateShortages(int count)
    {
        List<Shortage> shortages = [];
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            Shortage shortage = new Shortage
            {
                Title = $"Shortage Title {i + 1}",
                Name = $"Shortage Name {i + 1}",
                ShortageRoom = (ShortageRoom)random.Next(Enum.GetValues(typeof(ShortageRoom)).Length),
                ShortageCategory = (ShortageCategory)random.Next(Enum.GetValues(typeof(ShortageCategory)).Length),
                Priority = (byte)random.Next(1, 11),
                CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)),
                UserId = Guid.NewGuid()
            };

            shortages.Add(shortage);
        }

        return shortages;
    }
}