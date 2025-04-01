using REA.ViewModels;

namespace REA.Views;

public partial class MonitorSensorsPage : ContentPage
{
	public MonitorSensorsPage()
	{
		InitializeComponent();
        BindingContext = new MonitorSensorsViewModel();
    }
}