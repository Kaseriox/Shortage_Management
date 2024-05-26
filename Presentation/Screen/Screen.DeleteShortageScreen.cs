using Data.Model;
using static Presentation.Components.Components;

namespace Presentation.Screen;

public partial class Screen
{
    public void DeleteShortageScreen(List<Shortage> shortages)
    {
        const string instructions = "Which shortage to delete?";
        const string noShortagesMessage = "There are no shortages to delete";
        const string notExistMessage = "Selected shortage doesn't exist";
        const string deletedMessage = "Shortage deleted";
        const string deletedFailedMessage = "Shortage doesn't belong to you";
        if (shortages.Count < 1)
        {
            ContinueMessage(noShortagesMessage);
            return;
        }

        Console.Clear();
        ShortageTable(shortages);
        int choice = InputNumberWithinRange(instructions, 1, shortages.Count) - 1;
        Shortage? shortageToDelete = shortages.ElementAtOrDefault(choice);
        if (shortageToDelete is null)
        {
            ContinueMessage(notExistMessage);
            return;
        }

        bool deleted = shortageService.DeleteShortage(_user!, shortageToDelete);
        ContinueMessage(deleted ? deletedMessage : deletedFailedMessage);
    }
}