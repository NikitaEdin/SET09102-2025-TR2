using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Models;

namespace REA.ViewModels;

[QueryProperty(nameof(Alert), "Alert")]
public class AlertDetailsViewModel : ObservableObject, IQueryAttributable {
    private Alert _alert;

    public string Metadata => _alert?.Metadata.ToString() ?? string.Empty;
    public string Message => _alert?.Message ?? string.Empty;
    public string TriggeredAt => _alert?.TriggeredAt.ToString("g") ?? string.Empty;

    public ICommand BackCommand { get; }

    public AlertDetailsViewModel() {
        BackCommand = new RelayCommand(BackToAlerts);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        if (query.ContainsKey("Alert")) {
            _alert = (Alert)query["Alert"];
            RefreshProperties();
        }
    }

    private void RefreshProperties() {
        OnPropertyChanged(nameof(Metadata));
        OnPropertyChanged(nameof(Message));
        OnPropertyChanged(nameof(TriggeredAt));
    }

    private void BackToAlerts() {
        Shell.Current.GoToAsync("..");
    }
}