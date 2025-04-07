using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Views;

namespace REA.ViewModels;
public class OperationsManagerViewModel : ObservableObject {    
    // Navigation Commands
	public ICommand NavigateToSensorMalfunctionsCommand {get;}
	public ICommand NavigateToMonitorSensorsCommand { get; }
    public ICommand NavigateToManageMaintenanceCommand { get; }
	public ICommand NavigateToCollectedDataCommand { get; }

    // Back command
    public ICommand NavigateToDashboardCommand {get;}

    public OperationsManagerViewModel() {
        // Init navigation commands
        NavigateToSensorMalfunctionsCommand = new Command(async () => await NavigateToSensorMalfunctions());
		NavigateToMonitorSensorsCommand = new Command(async () => await NavigateToMonitorSensors());
        NavigateToManageMaintenanceCommand = new Command(async () => await NavigatoToManageMaintenance());
        NavigateToCollectedDataCommand = new Command(async () => await NavigateToCollectedData());

        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
    }

    /// <summary>
    /// Navigate to Monitor Sensor page - Nikita
    /// </summary>
    private async Task NavigateToMonitorSensors() {
        await Shell.Current.GoToAsync("MonitorSensors");
    }

    /// <summary>
    /// Navigate to Manage Maintenance - Ramsay
    /// </summary>
    private async Task NavigatoToManageMaintenance() {
        await Shell.Current.GoToAsync("ManageMaintenance");
    }

    /// <summary>
    /// Navigate to Collected Data - Rachael
    /// </summary>
    private async Task NavigateToCollectedData() {
        await Shell.Current.DisplayAlert("Feature Unavailable", "This feature is not yet implemented.", "OK");
        //await Shell.Current.GoToAsync("CollectedData");
    }

    /// <summary>
    /// Navigate to Sensor Malfunctions page - Thomas
    /// </summary>
    private async Task NavigateToSensorMalfunctions() {
		await Shell.Current.GoToAsync("SensorMalfunctions");
	}


    // Navigate back to dashboard
    private async Task NavigateToDashboard() {
        await Shell.Current.GoToAsync("//Dashboard");
    }
}