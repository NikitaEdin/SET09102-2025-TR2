using REA.ViewModels;

namespace REA.Views;

public partial class ReportMalfunctioningSensorsPage : ContentPage
{
    private ReportMalfunctioningSensorsViewModel viewModel;

	public ReportMalfunctioningSensorsPage()
	{
		InitializeComponent();
        viewModel = new ReportMalfunctioningSensorsViewModel();
        BindingContext = viewModel; // Connects the ui Binding to the viewModel
	}
    /// <summary>
    /// On page load use the method in the view model to load the sensors
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadSensors();

    }
}