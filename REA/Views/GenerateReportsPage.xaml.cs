namespace REA.Views;
using REA.ViewModels;
using REA.Models;
using REA.DB;
public partial class GenerateReportsPage : ContentPage
{
	private GenerateReportsViewModel viewModel;
	public GenerateReportsPage()
	{
		InitializeComponent();
		viewModel = new GenerateReportsViewModel(SQLiteDatabaseService.Instance);
		BindingContext = viewModel; // Connects the ui binding to the viewModel
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.LoadMeasurements();
    }
}