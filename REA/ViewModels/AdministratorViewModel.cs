using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace REA.ViewModels;

public partial class AdministratorViewModel : ObservableObject
{
    public ICommand NavigateToDashboardCommand { get; }

    public AdministratorViewModel()
    {
        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
    }

    private async Task NavigateToDashboard()
    {
        await Shell.Current.GoToAsync("//Dashboard");
    }

}

