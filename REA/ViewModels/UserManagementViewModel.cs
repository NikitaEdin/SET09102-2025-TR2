using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.DB;
using REA.Models;
using System.Collections.ObjectModel;

namespace REA.ViewModels {
    /// <summary>
    /// ViewModel responsible for backend of displaying and updating user roles.
    /// Author: Nikita Lanetsky
    /// </summary>
    public partial class UserManagementViewModel : ObservableObject {

        // All users and available roles
        public ObservableCollection<User> Users { get; } = new();
        public ObservableCollection<Role> Roles { get; } = new();

        // Keep track of selected user/role
        [ObservableProperty]
        private User selectedUser;

        [ObservableProperty]
        private Role selectedRole;

        // DB service 
        private readonly IDatabaseService _db;

        // Overloading with parameterless constructor for XAML
        public UserManagementViewModel() : this(SQLiteDatabaseService.Instance) {}

        public UserManagementViewModel(IDatabaseService? db = null) {
            // Any DB passed? if not - get instance from SQLite service
            _db = db ?? SQLiteDatabaseService.Instance;
        }

        /// <summary>
        /// Loads data async from database
        /// </summary>
        public async Task LoadDataAsync() {
            // Users
            var users = await _db.GetItemsAsync<User>();
            Users.Clear();
            foreach (var user in users)
                Users.Add(user);

            // Roles
            var roles = await _db.GetItemsAsync<Role>();
            Roles.Clear();
            foreach (var role in roles)
                Roles.Add(role);
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveAsync() {
            // Both selected?
            if (SelectedUser != null && SelectedRole != null) {
                SelectedUser.RoleId = SelectedRole.RoleID;
                // Update
                await UpdateUserRoleAsync();
            }
        }

        /// <summary> Update user's role </summary>
        public async Task UpdateUserRoleAsync() {
            // Validate data
            if (SelectedRole == null || SelectedUser == null)
                throw new ArgumentNullException("One of the given elements are null.");

            // Update
            SelectedUser.RoleId = SelectedRole.RoleID;
            await _db.UpdateAsync(SelectedUser);
        }

        /// <summary> Can save only if user and role are selected, and new role is different than current </summary>
        private bool CanSave() {
            return SelectedUser != null &&  SelectedRole != null && SelectedUser.RoleId != SelectedRole.RoleID;
        }


        partial void OnSelectedUserChanged(User value) {
            if (value != null) {
                // Select the correct Role for the selected User
                SelectedRole = Roles.FirstOrDefault(r => r.RoleID == value.RoleId);
                SaveCommand.NotifyCanExecuteChanged();
            }
        }

        partial void OnSelectedRoleChanged(Role value) {
            SaveCommand.NotifyCanExecuteChanged();
        }

    }
}
