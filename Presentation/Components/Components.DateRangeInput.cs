namespace Presentation.Components;

public static partial class Components
{
    public static (DateTime from, DateTime to) DateRangeInput()
    {
        while (true)
        {
            DateTime from = DateInput("Please enter a from date (MM/DD/YYYY):");
            DateTime to = DateInput("Please enter a to date (MM/DD/YYYY):");
            if (from < to)
            {
                return (from, to);
            }

            Console.WriteLine("Invalid input. \"From\" date cannot be later than \"to\" date");
        }
    }
}