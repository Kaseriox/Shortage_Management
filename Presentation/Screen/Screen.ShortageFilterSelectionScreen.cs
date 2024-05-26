using BusinessLogic.Strategies;
using Data.Model;
using static Presentation.Components.Components;

namespace Presentation.Screen;

public partial class Screen
{
    public void ShortageFilterSelectionScreen()
    {
        const string prompt = "Select by what to filter: ";
        const string titleInputPrompt = "Input title: ";
        const string shortageSelectionPrompt = "Select category: ";
        const string roomSelectionPrompt = "Select room: ";
        Console.Clear();
        FilterChoices choice = EnumSelection<FilterChoices>(prompt);
        switch (choice)
        {
            case FilterChoices.Title:
                string title = TextInput(titleInputPrompt);
                _shortageFilterStrategy = new FilterShortagesByTitle(title);
                break;
            case FilterChoices.Category:
                ShortageCategory shortageCategory = EnumSelection<ShortageCategory>(shortageSelectionPrompt);
                _shortageFilterStrategy = new FilterShortagesByCategory(shortageCategory);
                break;
            case FilterChoices.Room:
                ShortageRoom shortageRoom = EnumSelection<ShortageRoom>(roomSelectionPrompt);
                _shortageFilterStrategy = new FilterShortagesByRoom(shortageRoom);
                break;
            case FilterChoices.CreatedOn:
                (DateTime from, DateTime to) = DateRangeInput();
                _shortageFilterStrategy = new FilterShortagesByDateInterval(from, to);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private enum FilterChoices
    {
        Title,
        Category,
        Room,
        CreatedOn
    }
}