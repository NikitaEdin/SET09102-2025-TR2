using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace REA.Utils;

public class NavigationCommands : ObservableObject
{
    public ICommand NavigateToDashboardCommand { get; }
    public NavigationCommands()
	{
        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());

    }

    private async Task NavigateToDashboard()
    {
        await Shell.Current.GoToAsync("//Dashboard");
    }
}