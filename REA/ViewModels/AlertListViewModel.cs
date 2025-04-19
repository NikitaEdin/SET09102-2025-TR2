using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.DB;
using REA.Models;
using REA.Views;

namespace REA.ViewModels;

public class AlertListViewModel : ObservableObject {
    // Commands
    public ICommand NavigateToAlertDetailsCommand { private set; get; }

    // Alert list to select from
    public ObservableCollection<Alert> Alerts { get; set; } = new();

    // Database instance
    private readonly IDatabaseService _db;

    /// <summary>
    /// ViewModel responsible for view all alerts
    /// </summary>
    public AlertListViewModel() : this(SQLiteDatabaseService.Instance) {
    }

    /// <summary>
    /// ViewModel responsible for viewing all alerts (with custom database)
    /// </summary>
    /// <param name="db"></param>
    public AlertListViewModel(IDatabaseService db) {
        _db = db;

        NavigateToAlertDetailsCommand = new Command<Alert>(async (alert) => await NavigateToAlertDetails(alert));
    }

    /// <summary>
    /// Load all alerts from the database. Should be called in OnAppearing of the page.
    /// </summary>
    public async Task LoadAlerts() {
        // clear the list before loading new items
        Alerts.Clear();

        // get all alerts from the database
        var alerts = await _db.GetItemsAsync<Alert>();

        // sort alerts descending by date
        alerts = alerts.OrderByDescending(a => a.GetTriggeredAtDateTime()).ToList();

        // add all alerts to the list
        foreach (var alert in alerts) {
            Alerts.Add(alert);
        }
        OnPropertyChanged(nameof(Alerts));
    }

    /// <summary>
    /// Navigate to the alert details page
    /// </summary>
    /// <param name="alert">Alert to provide details for</param>
    private async Task NavigateToAlertDetails(Alert alert) {
        var navQuery = new Dictionary<string, object> {
            { "Alert", alert }
        };

        await Shell.Current.GoToAsync("AlertDetails", navQuery);
    }
}