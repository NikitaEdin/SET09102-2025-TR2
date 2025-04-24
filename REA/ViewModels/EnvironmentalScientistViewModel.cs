using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace REA.ViewModels;

public class EnvironmentalScientistViewModel : ObservableObject {
    // Navigation Commands

    public ICommand NavigateToReportsCommand {  get; }
    public ICommand NavigateToHistoricalDataCommand {  get; }
    public ICommand NavigateToAlertsCommand { get; }
    public ICommand NavigateToManageSensorCommand { get; }

    // Back command
    public ICommand NavigateToDashboardCommand { get; }

    public EnvironmentalScientistViewModel() {
        // Init navigation commands
        NavigateToReportsCommand = new Command(async () => await NavigateToReports());
        NavigateToHistoricalDataCommand = new Command(async () => await NavigateToHistoricalData());
        NavigateToAlertsCommand = new Command(async () => await NavigateToAlerts());
        NavigateToManageSensorCommand = new Command(async () => await NavigateToManageSensor());

        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
    }

    /// <summary>
    /// Navigate to sensor account and configuration settings - Rachael
    /// </summary>
    private async Task NavigateToManageSensor() {
        await Shell.Current.GoToAsync("ManageSensor");
    }

    /// <summary>
    /// Navigate to Historical Data of sensors - Nikita
    /// </summary>
    private async Task NavigateToHistoricalData() {
        await Shell.Current.GoToAsync("HistoricalData");
    }

    /// <summary>
    /// Navigate to interactive map to view sensors based on location - Ramsay
    /// </summary>
    private async Task NavigateToAlerts() {
        await Shell.Current.GoToAsync("AlertList");
    }

    /// <summary>
    /// Navigate to Environmetal Reports - Thomas
    /// </summary>
    private async Task NavigateToReports() {
        await Shell.Current.GoToAsync("EnvironmentalReports");
    }



    /// <summary> Navigates back to dashboard page </summary>
    private async Task NavigateToDashboard() {
        await Shell.Current.GoToAsync("//Dashboard");
    }

}