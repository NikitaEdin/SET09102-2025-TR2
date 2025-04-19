using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.DB;
using REA.Models;

namespace REA.ViewModels;

public partial class EditRoleViewModel : ObservableObject, IQueryAttributable {
    // Role to edit
    private Role _role;

    // Form fields
    [ObservableProperty] private int power = 0;

    // Proxied properties
    public string Title => _role?.Title ?? string.Empty;

    // Commands
    public ICommand EditRoleCommand { get; }
    public ICommand BackCommand { get; }

    // Database instance
    private readonly IDatabaseService _db;

    /// <summary>
    /// ViewModel responsible for editing a role
    /// </summary>
    public EditRoleViewModel() : this(SQLiteDatabaseService.Instance) {
    }

    /// <summary>
    /// ViewModel responsible for editing a role (with db dependency injection)
    /// </summary>
    public EditRoleViewModel(IDatabaseService db) {
        _db = db;

        EditRoleCommand = new Command(async () => await EditRole(), () => CanSave());
        BackCommand = new Command(async () => await GoBack());
    }

    /// <summary>
    /// Set the role to edit
    /// </summary>
    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        Debug.WriteLine(query);

        if (query.ContainsKey("Role")) {
            _role = query["Role"] as Role;
            Power = _role.Power;

            RefreshProperties();
        }
    }

    /// <summary>
    /// Refresh the properties to notify the UI of changes
    /// </summary>
    private void RefreshProperties() {
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(Power));
    }

    /// <summary>
    /// Edit the role in the database
    /// </summary>
    private async Task EditRole() {
        // Update the role in the database
        _role.Power = Power;
        await _db.UpdateAsync(_role);

        Shell.Current.DisplayAlert("Success", "Role updated successfully", "OK");
    }

    private bool CanSave() {
        // Check if the role is valid
        return _role != null && !string.IsNullOrEmpty(_role.Title) && Power > 0;
    }

    /// <summary>
    /// Go back to the previous page
    /// </summary>
    private async Task GoBack() {
        await Shell.Current.GoToAsync("..");
    }
}