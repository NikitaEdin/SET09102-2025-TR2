using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.DB;
using REA.Models;

namespace REA.ViewModels;

public partial class CreateMaintenanceViewModel : ObservableObject {
    // Form values
    [ObservableProperty] public string name = string.Empty;
    [ObservableProperty] public DateTime scheduledDate = DateTime.Now;
    [ObservableProperty] public int assignedUser = -1;
    [ObservableProperty] public string type = string.Empty;

    // List of available users
    public ObservableCollection<User> AvailableUsers { get; set; } = new();

    // Command to commit the maintenance creation
    public ICommand CreateMaintenanceCommand { get; }

    // Database instance
    private readonly IDatabaseService _db;

    /// <summary>
    /// ViewModel responsible for creating a new maintenance
    /// </summary>
    public CreateMaintenanceViewModel() : this(SQLiteDatabaseService.Instance) {
    }

    /// <summary>
    /// ViewModel responsible for creating a new maintenance (with db dependency injection)
    /// </summary>
    public CreateMaintenanceViewModel(IDatabaseService db) {
        _db = db;
        CreateMaintenanceCommand = new AsyncRelayCommand(CreateMaintenance);
    }


    /// <summary>
    /// Load all available users from the database. Should be called in OnAppearing of the page.
    /// </summary>
    public async Task LoadUsers() {
        AvailableUsers.Clear();

        var users = await _db.GetItemsAsync<User>();

        foreach (var user in users) {
            AvailableUsers.Add(user);
        }

        // Notify the UI that the list of available users has changed
        OnPropertyChanged(nameof(AvailableUsers));
    }

    /// <summary>
    /// Set the selected user
    /// </summary>
    public void UserSelected(User user) {
        AssignedUser = user.UserID;
        OnPropertyChanged(nameof(AssignedUser));
    }

    /// <summary>
    /// Create a new maintenance and insert it into the database
    /// </summary>
    private async Task CreateMaintenance() {
        // Ensure all fields are filled
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Type) || AssignedUser == -1) {
            await Shell.Current.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }
        // Ensure the scheduled date is in the future
        if (ScheduledDate < DateTime.Now) {
            await Shell.Current.DisplayAlert("Error", "Scheduled date must be in the future", "OK");
            return;
        }

        // Instantiate a new maintenance object
        var maintenance = new Models.Maintenance() {
            Name = name,
            ScheduledDate = scheduledDate.ToString("yyyy-MM-d hh:mm:ss"),
            AssignedUser = assignedUser,
            Type = type
        };

        // Insert the maintenance into the database
        await _db.InsertAsync(maintenance);

        await Shell.Current.GoToAsync("..");
    }
}