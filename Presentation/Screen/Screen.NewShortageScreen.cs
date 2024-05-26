using Data.Model;
using static Presentation.Components.Components;

namespace Presentation.Screen;

public partial class Screen
{
    private void NewShortageScreen()
    {
        const string title = "New Shortage Screen";
        const string titleInputPrompt = "Input shortage title: ";
        const string nameInputPrompt = "Input shortage name: ";
        const string roomInputPrompt = "Select room";
        const string categoryInputPrompt = "Select category";
        const string priorityInputPrompt = "Input priority";
        const string alreadyExistsMessage = "Shortage already exists";
        const string createdMessage = "Shortage created";
        Console.Clear();
        Console.WriteLine(title);
        string shortageTitle = TextInput(titleInputPrompt);
        string shortageName = TextInput(nameInputPrompt);
        ShortageRoom shortageRoom = EnumSelection<ShortageRoom>(roomInputPrompt);
        ShortageCategory shortageCategory = EnumSelection<ShortageCategory>(categoryInputPrompt);
        byte shortagePriority = (byte)InputNumberWithinRange(priorityInputPrompt, 1, 10);

        Shortage newShortage = new Shortage
        {
            Title = shortageTitle,
            Name = shortageName,
            ShortageCategory = shortageCategory,
            ShortageRoom = shortageRoom,
            Priority = shortagePriority,
            CreatedOn = DateTime.Now,
            UserId = _user!.Id
        };
        bool successful = shortageService.AddShortage(newShortage);
        if (!successful)
        {
            ContinueMessage(alreadyExistsMessage);
        }
        else
        {
            ContinueMessage(createdMessage);
        }
    }
}