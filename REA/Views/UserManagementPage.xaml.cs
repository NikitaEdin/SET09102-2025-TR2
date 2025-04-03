using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace REA.Views {
    public partial class UserManagementPage : ContentPage {
        // Dummy users
        private List<User> users;
        // Dummy roles
        private List<string> roles;
        // Current selected user
        private User selectedUser;

        public UserManagementPage() {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData() {
            users = new List<User> {
                new User { Id = 1, Name = "John Smith", Role = "User" },
                new User { Id = 2, Name = "Bruce Lee", Role = "Admin" },
                new User { Id = 3, Name = "Bob Ross ", Role = "Moderator" }
            };

            roles = new List<string> { "User", "Admin", "Moderator" };

            UsersListView.ItemsSource = users;
            RolesPicker.ItemsSource = roles;
        }

        private void OnUserSelected(object sender, SelectedItemChangedEventArgs e) {
            selectedUser = (User)e.SelectedItem;
            if (selectedUser != null) {
                RolesPicker.SelectedItem = selectedUser.Role;
                SaveButton.IsEnabled = true; 
            }
        }

        private void OnRoleSelected(object sender, EventArgs e) {
            if (selectedUser != null) {
                selectedUser.Role = RolesPicker.SelectedItem?.ToString();
            }
        }

        private void OnSaveClicked(object sender, EventArgs e) {
            if (selectedUser != null) {
                DisplayAlert("Success", $"{selectedUser.Name} is now a {selectedUser.Role}.", "OK");
            } else {
                DisplayAlert("Error", "Please select a user first.", "OK");
            }
        }
    }


    // Dummy User object for prototyping purposes
    public class User {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
    }
}
