namespace REA.Views;

public partial class CreateMaintenancePage : ContentPage {
    public CreateMaintenancePage() {
        InitializeComponent();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await ViewModel.LoadUsers();
    }

    /// <summary>
    /// Handles the event when a user is selected from the list and forwards the selected user to the ViewModel.
    /// </summary>
    private void OnUserSelected(object sender, SelectedItemChangedEventArgs e) {
        var selectedUser = (Models.User)e.SelectedItem;

        ViewModel.UserSelected(selectedUser);
    }
}