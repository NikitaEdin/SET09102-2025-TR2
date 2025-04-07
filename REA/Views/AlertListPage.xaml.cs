using REA.Models;

namespace REA.Views;

public partial class AlertListPage : ContentPage {
    public AlertListPage() {
        InitializeComponent();

        AlertListView.ItemsSource = ViewModel.Alerts;
    }

    private void OnAlertSelected(object sender, SelectedItemChangedEventArgs e) {
        if (e.SelectedItem != null) {
            Alert selectedAlert = (Alert)e.SelectedItem;

            ViewModel.NavigateToAlertDetailsCommand.Execute(selectedAlert);
        }
    }
}