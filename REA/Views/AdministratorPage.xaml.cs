namespace REA.Views;

public partial class AdministratorPage : ContentPage
{
	public AdministratorPage()
	{
        InitializeComponent();
	}

    private async void OnManageUserAccessClicked(object sender, EventArgs e) {
        await Navigation.PushAsync(new UserManagementPage());
    }

    private async void OnStorageOverviewClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StorageOverviewPage());
    }
}