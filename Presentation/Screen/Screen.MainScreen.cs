using BusinessLogic.Strategies;
using Data.Model;
using static Presentation.Components.Components;

namespace Presentation.Screen;

public partial class Screen
{
    private IShortageFilterStrategy? _shortageFilterStrategy;

    private void MainScreen()
    {
        while (_user is not null)
        {
            List<Shortage> shortages = shortageService.GetShortages(_user, _shortageFilterStrategy)
                .OrderByDescending(shortage => shortage.Priority).ToList();
            Console.Clear();
            Console.WriteLine("Main Screen");
            if (_shortageFilterStrategy is not null)
            {
                Console.WriteLine(_shortageFilterStrategy.GetFilterInformation());
            }

            ShortageTable(shortages);
            MainScreenChoices choice = EnumSelection<MainScreenChoices>("Action");
            switch (choice)
            {
                case MainScreenChoices.AddNewShortage:
                    NewShortageScreen();
                    break;
                case MainScreenChoices.DeleteShortage:
                    DeleteShortageScreen(shortages);
                    break;
                case MainScreenChoices.FilterShortages:
                    ShortageFilterSelectionScreen();
                    break;
                case MainScreenChoices.RemoveFilter:
                    _shortageFilterStrategy = null;
                    break;
                case MainScreenChoices.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private enum MainScreenChoices
    {
        AddNewShortage,
        DeleteShortage,
        FilterShortages,
        RemoveFilter,
        Exit
    }
}