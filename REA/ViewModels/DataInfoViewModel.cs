using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.DB;
using REA.Models;

namespace REA.ViewModels;

public partial class DataInfoViewModel : ObservableObject {
    // Properties for user role counts
    [ObservableProperty] private ObservableCollection<Tuple<Role, int>> roleCounts = new();

    // Commands
    public ICommand NavigateToUserManagementCommand { get; }
    public ICommand NavigateToEditRoleCommand { get; }

    // Database instance
    private readonly IDatabaseService _db;

    /// <summary>
    /// ViewModel responsible for displaying the details about the security & privacy of the data
    /// </summary>
    public DataInfoViewModel() : this(SQLiteDatabaseService.Instance) {
    }

    /// <summary>
    /// ViewModel responsible for displaying the details about the security & privacy of the data
    /// </summary>
    public DataInfoViewModel(IDatabaseService db) {
        _db = db;

        NavigateToUserManagementCommand = new Command(NavigateToUserManagement);
        NavigateToEditRoleCommand = new Command<Role>(NavigateToEditRole);
    }

    /// <summary>
    /// Load the user role counts from the database. Should be called in OnAppearing of the page.
    /// </summary>
    public async Task LoadUserRoleCounts() {
        // Get all users & roles from the database
        var users = await _db.GetItemsAsync<User>();
        var roles = await _db.GetItemsAsync<Role>();

        // Get the role counts
        var groupedUsers = users.GroupBy(u => u.RoleId)
            .Select(g => new Tuple<Role, int>(
                roles.FirstOrDefault(r => r.RoleID == g.Key),
                g.Count()))
            .ToList();

        // Clear the existing role counts
        this.RoleCounts.Clear();

        // Add the new role counts to the list
        foreach (var item in groupedUsers) {
            this.RoleCounts.Add(item);
        }

        // Notify the UI that the role counts have changed
        OnPropertyChanged(nameof(RoleCounts));
    }

    /// <summary>
    /// Navigate to the user management page
    /// </summary>
    private async void NavigateToUserManagement() {
        await Shell.Current.GoToAsync("UserManagement");
    }

    /// <summary>
    /// Navigate to the edit role page
    /// </summary>
    private async void NavigateToEditRole(Role role) {
        var navQuery = new Dictionary<string, object> {
            { "Role", role }
        };

        await Shell.Current.GoToAsync("EditRole", navQuery);
    }
}