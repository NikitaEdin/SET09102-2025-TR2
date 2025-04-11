using REA.ViewModels;
namespace REA.Views.ReportMalfunctioningSensors;

public partial class SensorErrorsPage : ContentPage
{
    private SensorErrorsViewModel viewModel;
    public SensorErrorsPage()
	{
		InitializeComponent();
        viewModel = new SensorErrorsViewModel();
        BindingContext = viewModel; // Connects the ui Binding to the viewModel
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadSensors();

    }
}