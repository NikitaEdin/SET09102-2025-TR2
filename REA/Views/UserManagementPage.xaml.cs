using REA.ViewModels;

namespace REA.Views {
    public partial class UserManagementPage : ContentPage {
        
        public UserManagementPage() {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            base.OnAppearing();
            await ViewModel.LoadDataAsync();
        }
    }
}
