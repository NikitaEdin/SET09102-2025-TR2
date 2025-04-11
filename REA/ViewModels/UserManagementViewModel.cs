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


        public UserManagementViewModel() {
            // Load users and roles async from database
            LoadDataAsync();
        }

        /// <summary>
        /// Loads data async from database
        /// </summary>
        private async void LoadDataAsync() {
            // Users
            var users = await User.GetAllUsersAsync();
            Users.Clear();
            foreach (var user in users)
                Users.Add(user);

            // Roles
            var roles = await Role.GetAllRolesAsync();
            Roles.Clear();
            foreach (var role in roles)
                Roles.Add(role);
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        private async Task SaveAsync() {
            // Both selected?
            if (SelectedUser != null && SelectedRole != null) {
                SelectedUser.RoleId = SelectedRole.RoleID.ToString();

                // Valid - Update, Invalid - Insert
                if (SelectedUser.UserID > 0) {
                    var result = await SQLiteDatabaseService.Instance.UpdateAsync(SelectedUser);
                } else {
                    var result = await SQLiteDatabaseService.Instance.InsertAsync(SelectedUser);
                }

                // Update list from lastest DB commit
                LoadDataAsync(); 
            }
        }

        /// <summary> Can save only if user and role are selected, and new role is different than current </summary>
        private bool CanSave() {
            return SelectedUser != null &&  SelectedRole != null && SelectedUser.RoleId != SelectedRole.RoleID.ToString();
        }


        partial void OnSelectedUserChanged(User value) {
            if (value != null) {
                // Select the correct Role for the selected User
                SelectedRole = Roles.FirstOrDefault(r => r.RoleID.ToString() == value.RoleId);
                SaveCommand.NotifyCanExecuteChanged();
            }
        }

        partial void OnSelectedRoleChanged(Role value) {
            SaveCommand.NotifyCanExecuteChanged();
        }

    }
}
