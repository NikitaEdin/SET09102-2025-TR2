using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace REA.ViewModels;

public class EnvironmentalScientistViewModel : ObservableObject
{
	public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToReportsCommand {  get; }
    public ICommand NavigateToHistoricalDataCommand {  get; }
    public ICommand NavigateToManageSensorCommand { get; }



    public EnvironmentalScientistViewModel()
	{
        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
        NavigateToReportsCommand = new Command(async () => await NavigateToReports());
        NavigateToHistoricalDataCommand = new Command(async () => await NavigateToHistoricalData());
        NavigateToManageSensorCommand = new Command(async () => await NavigateToManageSensor());
    }
    private async Task NavigateToDashboard()
    {
        await Shell.Current.GoToAsync("//Dashboard");
    }

    private async Task NavigateToReports()
    {
        await Shell.Current.GoToAsync("EnvironmentalReports");
    }

    private async Task NavigateToHistoricalData() {
        await Shell.Current.GoToAsync("HistoricalData");
    }

    private async Task NavigateToManageSensor()
    {
        await Shell.Current.GoToAsync("ManageSensor");
    }
}