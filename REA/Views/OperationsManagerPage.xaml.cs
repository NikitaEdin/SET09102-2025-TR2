namespace REA.Views;

public partial class OperationsManagerPage : ContentPage
{
	public OperationsManagerPage()
	{
		InitializeComponent();
	}

	private async void OnManageMaintenanceClicked(object sender, EventArgs e) {
		await Navigation.PushAsync(new ManageMaintenancePage());
	}
}