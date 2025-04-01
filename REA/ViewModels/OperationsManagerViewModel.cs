using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Views;

namespace REA.ViewModels;

public class OperationsManagerViewModel : ObservableObject
{
	public ICommand NavigateToDashboardCommand {get;}
	public ICommand NavigateToSensorMalfunctionsCommand {get;}
	public ICommand NavigateToMonitorSensorsCommand { get; }

    public OperationsManagerViewModel()
	{
		NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
        NavigateToSensorMalfunctionsCommand = new Command(async () => await NavigateToSensorMalfunctions());
		NavigateToMonitorSensorsCommand = new Command(async () => await NavigateToMonitorSensors());
    }

	private async Task NavigateToDashboard()
	{
		await Shell.Current.GoToAsync("//Dashboard");
	}
	private async Task NavigateToSensorMalfunctions()
	{
		await Shell.Current.GoToAsync("SensorMalfunctions");
	}

    private async Task NavigateToMonitorSensors() {
        await Shell.Current.GoToAsync("MonitorSensors");
    }
}