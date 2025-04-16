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
    [ObservableProperty] private string name;
    [ObservableProperty] private DateTime scheduledDate;
    [ObservableProperty] private int assignedUser;
    [ObservableProperty] private string type;

    // List of available users
    public ObservableCollection<User> AvailableUsers { get; set; } = new();

    // Command to commit the maintenance creation
    public ICommand CreateMaintenanceCommand { get; }

    /// <summary>
    /// ViewModel responsible for creating a new maintenance
    /// </summary>
    public CreateMaintenanceViewModel() {
        ScheduledDate = DateTime.Now;

        CreateMaintenanceCommand = new RelayCommand(CreateMaintenance);
    }

    /// <summary>
    /// Load all available users from the database. Should be called in OnAppearing of the page.
    /// </summary>
    public async Task LoadUsers() {
        AvailableUsers.Clear();

        var users = await User.GetAllUsersAsync();

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
    private async void CreateMaintenance() {
        // Instantiate a new maintenance object
        var maintenance = new Models.Maintenance() {
            Name = name,
            ScheduledDate = scheduledDate.ToString("yyyy-MM-d hh:mm:ss"),
            AssignedUser = assignedUser,
            Type = type
        };

        // Insert the maintenance into the database
        await SQLiteDatabaseService.Instance.InsertAsync(maintenance);

        await Shell.Current.GoToAsync("..");
    }
}