using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace REA.ViewModels;

public class OperationsManagerViewModel : ObservableObject
{
	public ICommand NavigateToDashboardCommand {get;}
	public ICommand NavigateToSensorMalfunctionsCommand {get;}
	public OperationsManagerViewModel()
	{
		NavigateToDashboardCommand = new Command(async () => await NavigateToDashboard());
        NavigateToSensorMalfunctionsCommand = new Command(async () => await NavigateToSensorMalfunctions());
    }

	private async Task NavigateToDashboard()
	{
		await Shell.Current.GoToAsync("//Dashboard");
	}
	private async Task NavigateToSensorMalfunctions()
	{
		await Shell.Current.GoToAsync("SensorMalfunctions");
	}
}