using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Models;

namespace REA.ViewModels;

[QueryProperty(nameof(Alert), "Alert")]
public class AlertDetailsViewModel : ObservableObject, IQueryAttributable {
    // Alert to display details for
    private Alert _alert;

    // Proxy properties for the alert, correct format for display
    public string Metadata => _alert?.Metadata_ID.ToString() ?? string.Empty;
    public string Message => _alert?.Message ?? string.Empty;
    public string TriggeredAt => _alert?.GetTriggeredAtDateTime().ToString("g") ?? string.Empty;

    // Commands
    public ICommand BackCommand { get; }

    /// <summary>
    /// ViewModel responsible for displaying the details of a selected alert
    /// </summary>
    public AlertDetailsViewModel() {
        BackCommand = new RelayCommand(BackToAlerts);
    }

    /// <summary>
    /// Apply the query attributes to the view model. This is called when the page is navigated to with a query string.
    /// </summary>
    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        if (query.ContainsKey("Alert")) {
            _alert = (Alert)query["Alert"];
            RefreshProperties();
        }
    }

    /// <summary>
    /// Refresh the properties of the view model for the UI to react
    /// </summary>
    private void RefreshProperties() {
        OnPropertyChanged(nameof(Metadata));
        OnPropertyChanged(nameof(Message));
        OnPropertyChanged(nameof(TriggeredAt));
    }

    /// <summary>
    /// Navigate back to the alerts page
    /// </summary>
    private void BackToAlerts() {
        Shell.Current.GoToAsync("..");
    }
}