using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace REA.ViewModels;

public partial class AdministratorViewModel : ObservableObject {
    // Navigation Commands
    public ICommand NavigateToUpdateSensorCommand { get; }
    public ICommand NavigateToManageUserAccessCommand { get; }
    public ICommand NavigateToStorageManagementCommand { get; }
    public ICommand NavigateToAuthConfigCommand { get; }

    // Back command
    public ICommand NavigateToDashboardCommand { get; }

    public AdministratorViewModel() {
        // Init navigation commands
        NavigateToUpdateSensorCommand = new Command(async () => await NavigateToUpdateSensor());
        NavigateToManageUserAccessCommand = new Command(async () => await NavigateToManageUserAccess());
        NavigateToStorageManagementCommand = new Command(async () => await NavigateToStorageManagement());
        NavigateToAuthConfigCommand = new Command(async () => await NavigateToAuthConfig());

        NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
    }
    
    /// <summary>
    /// Navigate to Update Sensor view - Thomas
    /// </summary>
    private async Task NavigateToUpdateSensor() {
        await Shell.Current.GoToAsync("UpdateSensor");
    }

    /// <summary>
    /// Navigate to Manage User Access (roles) - Nikita
    /// </summary>
    private async Task NavigateToManageUserAccess() {
        await Shell.Current.GoToAsync("UserManagement");
    }

    /// <summary>
    /// Navigate to Storage Management - Rachael
    /// </summary>
    private async Task NavigateToStorageManagement() {
        await Shell.Current.DisplayAlert("Feature Unavailable", "This feature is not yet implemented.", "OK");
        //await Shell.Current.GoToAsync("StorageManagement");
    }

    /// <summary>
    /// Manage to Authorisaion Configuration - Ramsay
    /// </summary>
    /// <returns></returns>
    private async Task NavigateToAuthConfig() {
        await Shell.Current.DisplayAlert("Feature Unavailable", "This feature is not yet implemented.", "OK");
        //await Shell.Current.GoToAsync("AuthConfig");
    }


    /// <summary> Navigates back to dashboard page </summary>
    private async Task NavigateToDashboard() {
        await Shell.Current.GoToAsync("//Dashboard");
    }
}

