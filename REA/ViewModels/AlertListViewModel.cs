using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Models;
using REA.Views;

namespace REA.ViewModels;

public class AlertListViewModel : ObservableObject {
    public ICommand NavigateToAlertDetailsCommand { private set; get; }

    public ObservableCollection<Alert> Alerts { get; set; } = new ObservableCollection<Alert>();

    public AlertListViewModel() {
        NavigateToAlertDetailsCommand = new Command<Alert>(async (alert) => await NavigateToAlertDetails(alert));

        // Sample data for alerts until database is implemented
        Alerts.Add(new Alert {
            Metadata = "Sensor 1",
            Message = "High temperature detected",
            TriggeredAt = DateTime.Now
        });
        Alerts.Add(new Alert {
            Metadata = "Sensor 2",
            Message = "Low battery",
            TriggeredAt = DateTime.Now.AddMinutes(-30)
        });
        Alerts.Add(new Alert {
            Metadata = "Sensor 3",
            Message = "Network connectivity issue",
            TriggeredAt = DateTime.Now.AddHours(-1)
        });
    }

    private async Task NavigateToAlertDetails(Alert alert) {
        var navQuery = new Dictionary<string, object> {
            { "Alert", alert }
        };

        await Shell.Current.GoToAsync("AlertDetails", navQuery);
    }
}