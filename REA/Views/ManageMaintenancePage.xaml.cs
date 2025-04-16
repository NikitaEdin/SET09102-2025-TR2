namespace REA.Views;

public partial class ManageMaintenancePage : ContentPage {
    public ManageMaintenancePage() {
        InitializeComponent();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await ViewModel.LoadMaintenance();
    }

    /// <summary>
    /// Handles the event when a maintenance item is selected from the list and forwards the selected maintenance to the ViewModel.
    /// </summary>
    private async void OnMaintenanceSelected(object sender, SelectedItemChangedEventArgs e) {
        if (e.SelectedItem != null) {
            var selectedMaintenance = (Models.Maintenance)e.SelectedItem;

            ViewModel.NavigateToMaintenanceDetailsCommand.Execute(selectedMaintenance);
        }
    }
}