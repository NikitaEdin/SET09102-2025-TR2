using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Models;

namespace REA.ViewModels;

public class ManageMaintenanceViewModel : ObservableObject {
    // Navigation commands
    public ICommand NavigateToMaintenanceDetailsCommand { private set; get; }
    public ICommand NavigateToCreateMaintenanceCommand { private set; get; }

    // Maintenance list to select from
    public ObservableCollection<Maintenance> MaintenanceList { get; set; } = new();

    /// <summary>
    /// ViewModel responsible for viewing all maintenance
    /// </summary>
    public ManageMaintenanceViewModel() {
        NavigateToMaintenanceDetailsCommand =
            new Command<Maintenance>(async (maintenance) => await NavigateToMaintenanceDetails(maintenance));
        NavigateToCreateMaintenanceCommand = new Command(async () => await NavigateToCreateMaintenance());
    }

    /// <summary>
    /// Load all maintenance from the database. Should be called in OnAppearing of the page.
    /// </summary>
    public async Task LoadMaintenance() {
        // clear the list of maintenance so theres no duplicates
        MaintenanceList.Clear();

        var maintenance = await Maintenance.GetAllMaintenanceAsync();

        // sort maintenance descending by date
        maintenance = maintenance.OrderByDescending(m => m.GetScheduledAtDateTime()).ToList();

        // add all maintenance to the list
        foreach (var item in maintenance) {
            MaintenanceList.Add(item);
        }

        OnPropertyChanged(nameof(MaintenanceList));
    }

    /// <summary>
    /// Navigate to the maintenance details page
    /// </summary>
    /// <param name="maintenance"></param>
    public async Task NavigateToMaintenanceDetails(Maintenance maintenance) {
        var navQuery = new Dictionary<string, object> {
            { "Maintenance", maintenance }
        };

        await Shell.Current.GoToAsync("MaintenanceDetails", navQuery);
    }

    /// <summary>
    /// Navigate to the create maintenance page
    /// </summary>
    public async Task NavigateToCreateMaintenance() {
        await Shell.Current.GoToAsync("CreateMaintenance");
    }
}