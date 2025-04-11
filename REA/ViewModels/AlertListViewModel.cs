using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Models;
using REA.Views;

namespace REA.ViewModels;

public class AlertListViewModel : ObservableObject {
    public ICommand NavigateToAlertDetailsCommand { private set; get; }

    public ObservableCollection<Alert> Alerts { get; set; } = new();

    public AlertListViewModel() {
        NavigateToAlertDetailsCommand = new Command<Alert>(async (alert) => await NavigateToAlertDetails(alert));
    }

    public async Task LoadAlerts() {
        Alerts.Clear();

        var alerts = await Alert.GetAllAlertsAsync();

        foreach (var alert in alerts) {
            Alerts.Add(alert);
        }

        OnPropertyChanged(nameof(Alerts));
    }

    private async Task NavigateToAlertDetails(Alert alert) {
        var navQuery = new Dictionary<string, object> {
            { "Alert", alert }
        };

        await Shell.Current.GoToAsync("AlertDetails", navQuery);
    }
}