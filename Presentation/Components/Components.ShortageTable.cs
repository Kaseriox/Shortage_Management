using Data.Model;

namespace Presentation.Components;

public static partial class Components
{
    public static void ShortageTable(IEnumerable<Shortage> shortages)
    {
        const int separatorLength = 120;
        Separator(separatorLength);
        Console.WriteLine("|{0,5}| {1,-20} | {2,-20} | {3,-15} | {4,-12} | {5,-15} | {6,-8}  |",
            "No.", "Title", "Name", "Room", "Category", "Priority", "Created On");
        Separator(separatorLength);
        int i = 1;
        foreach (Shortage shortage in shortages)
        {
            Console.WriteLine(
                "|{0,5}| {1,-20} | {2,-20} | {3,-15} | {4,-12} | {5,-15} | {6,-8}  |",
                i.ToString(),
                shortage.Title, shortage.Name, shortage.ShortageRoom, shortage.ShortageCategory,
                shortage.Priority, shortage.CreatedOn.ToShortDateString());
            i++;
        }

        Separator(separatorLength);
    }

    private static void Separator(int length)
    {
        Console.WriteLine(new string('-', length));
    }
}