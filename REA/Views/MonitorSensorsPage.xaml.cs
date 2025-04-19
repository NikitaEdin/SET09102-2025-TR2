using REA.ViewModels;

namespace REA.Views;

public partial class MonitorSensorsPage : ContentPage {
	public MonitorSensorsPage() {
		InitializeComponent();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await ViewModel.GetSensors();
    }
}