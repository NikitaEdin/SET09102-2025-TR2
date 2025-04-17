using REA.ViewModels;
using REA.DB;
namespace REA.Views;

public partial class UpdateSensorPage : ContentPage
{
    private UpdateSensorViewModel viewModel;
    public UpdateSensorPage()
	{
		InitializeComponent();
        viewModel = new UpdateSensorViewModel(SQLiteDatabaseService.Instance);
        BindingContext = viewModel; // Connects the ui Binding to the viewModel
    }

    /// <summary>
    /// On page load use the method in the view model to load the sensors
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadConfigs();

    }
}