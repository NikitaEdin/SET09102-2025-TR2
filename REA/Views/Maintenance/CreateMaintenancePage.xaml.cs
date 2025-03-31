namespace REA.Views.Maintenance;

public partial class CreateMaintenancePage : ContentPage {
    // Dummy users
    private List<User> users;

    public CreateMaintenancePage() {
        InitializeComponent();

        users = new List<User> {
            new User { Id = 1, Name = "John Smith", Role = "User" },
            new User { Id = 2, Name = "Bruce Lee", Role = "Admin" },
            new User { Id = 3, Name = "Bob Ross ", Role = "Moderator" }
        };

        UsersListView.ItemsSource = users;
    }

    private void OnUserSelected(object sender, SelectedItemChangedEventArgs e) {
        User selectedUser = (User)e.SelectedItem;

        if (selectedUser != null) {
            CreateMaintenance.AssignedUser = selectedUser.Name;
        }
    }
}