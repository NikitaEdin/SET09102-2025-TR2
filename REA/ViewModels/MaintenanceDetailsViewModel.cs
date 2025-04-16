using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Models;

namespace REA.ViewModels;

public class MaintenanceDetailsViewModel : ObservableObject, IQueryAttributable {
    // Maintenance object to hold the details of the selected maintenance
    private Maintenance _maintenance;

    // Properties to bind to the UI
    public string Name => _maintenance?.Name ?? string.Empty;
    public string ScheduledAt => _maintenance?.GetScheduledAtDateTime().ToString("g") ?? string.Empty;
    public string AssignedUser => _maintenance?.AssignedUser.ToString() ?? string.Empty;
    public string Type => _maintenance?.Type ?? string.Empty;

    // Navigation commands
    public ICommand BackCommand { get; }

    /// <summary>
    /// ViewModel responsible for displaying the details of a selected maintenance
    /// </summary>
    public MaintenanceDetailsViewModel() {
        BackCommand = new RelayCommand(Back);
    }

    /// <summary>
    /// Method to set the maintenance object from the navigation query
    /// </summary>
    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        if (query.ContainsKey("Maintenance")) {
            _maintenance = (Maintenance)query["Maintenance"];
            RefreshProperties();
        }
    }

    /// <summary>
    /// Method to refresh the properties of the ViewModel
    /// </summary>
    private void RefreshProperties() {
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(ScheduledAt));
        OnPropertyChanged(nameof(AssignedUser));
        OnPropertyChanged(nameof(Type));
    }

    /// <summary>
    /// Method to navigate back to the previous page
    /// </summary>
    private void Back() {
        Shell.Current.GoToAsync("..");
    }
}