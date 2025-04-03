using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace REA.ViewModels;

public partial class AdministratorViewModel : ObservableObject
{
    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToUpdateSensorCommand { get; }

    public AdministratorViewModel()
    {
        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
        NavigateToUpdateSensorCommand = new Command(async () => await NavigateToUpdateSensor());
    }

    private async Task NavigateToDashboard()
    {
        await Shell.Current.GoToAsync("//Dashboard");
    }

    private async Task NavigateToUpdateSensor()
    {
        await Shell.Current.GoToAsync("UpdateSensor");
    }

}

