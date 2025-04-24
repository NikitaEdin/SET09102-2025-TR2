namespace REA.Views;

public partial class HistoricalDataPage : ContentPage
{
	public HistoricalDataPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing() {
		base.OnAppearing();
		await ViewModel.PopulateRecords();
    }
}