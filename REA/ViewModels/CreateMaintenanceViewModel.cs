using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace REA.ViewModels;

public partial class CreateMaintenanceViewModel : ObservableObject {
    [ObservableProperty] private string name;

    [ObservableProperty] private DateTime scheduledDate;

    [ObservableProperty] private string assignedUser;

    [ObservableProperty] private string type;

    public ICommand CreateMaintenanceCommand { get; }

    public CreateMaintenanceViewModel() {
        ScheduledDate = DateTime.Now;

        CreateMaintenanceCommand = new RelayCommand(CreateMaintenance);
    }

    private async void CreateMaintenance() {
        var maintenance = new Models.Maintenance() {
            Name = name,
            ScheduledDate = scheduledDate,
            AssignedUser = assignedUser,
            Type = type
        };

        // TODO: Implement the logic to save the maintenance task

        await Shell.Current.Navigation.PopAsync();
    }
}