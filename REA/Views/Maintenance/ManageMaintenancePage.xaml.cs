using REA.Views.Maintenance;

namespace REA.Views;

public partial class ManageMaintenancePage : ContentPage {
    private List<Models.Maintenance> maintenanceList;

    public ManageMaintenancePage() {
        InitializeComponent();

        maintenanceList = new List<Models.Maintenance>() {
            new Models.Maintenance {
                Name = "Maintenance 1", ScheduledDate = DateTime.Now.AddDays(1), AssignedUser = "John Smith",
                Type = "Update"
            },
            new Models.Maintenance {
                Name = "Maintenance 2", ScheduledDate = DateTime.Now.AddDays(2), AssignedUser = "Bruce Lee",
                Type = "Update"
            },
            new Models.Maintenance {
                Name = "Maintenance 3", ScheduledDate = DateTime.Now.AddDays(3), AssignedUser = "Bob Ross",
                Type = "Check"
            }
        };

        MaintenanceListView.ItemsSource = maintenanceList;
    }

    private async void OnMaintenanceSelected(object sender, SelectedItemChangedEventArgs e) {
        if (e.SelectedItem != null) {
            var selectedMaintenance = (Models.Maintenance)e.SelectedItem;

            await Navigation.PushAsync(new MaintenanceDetailPage(selectedMaintenance));
        }
    }
}