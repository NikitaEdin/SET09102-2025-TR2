using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Views;

namespace REA.ViewModels;

public class OperationsManagerViewModel : ObservableObject {
    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToSensorMalfunctionsCommand { get; }
    public ICommand NavigateToManageMaintenanceCommand { get; }

    public OperationsManagerViewModel() {
        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
        NavigateToSensorMalfunctionsCommand = new Command(async () => await NavigateToSensorMalfunctions());
        NavigateToManageMaintenanceCommand = new Command(async () => await NavigatoToManageMaintenance());
    }

    private async Task NavigateToDashboard() {
        await Shell.Current.GoToAsync("//Dashboard");
    }

    private async Task NavigateToSensorMalfunctions() {
        await Shell.Current.GoToAsync("SensorMalfunctions");
    }

    private async Task NavigatoToManageMaintenance() {
        await Shell.Current.Navigation.PushAsync(new ManageMaintenancePage());
    }
}