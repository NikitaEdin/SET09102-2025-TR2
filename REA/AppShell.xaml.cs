using REA.ViewModels;  // Assuming UserManager or other login-related logic is in this namespace
using REA.Utils;    // Assuming UserManager or similar service is here
using Microsoft.Maui.Controls;

namespace REA {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            BindingContext = new AppShellViewModel();

            // Subscribe to user changes (e.g., when the user logs in or out)
            UserManager.Instance.CurrentUserChanged += OnCurrentUserChanged;
        }

        // OnAppearing is called when the shell (app) is fully loaded
        protected override void OnAppearing() {
            base.OnAppearing();

            // Check if the user is logged in
            bool isLoggedIn = UserManager.Instance.CurrentUser != null;

            // Perform navigation based on login state
            if (isLoggedIn) {
                Shell.Current.GoToAsync("//Dashboard");  // Navigate to Dashboard if logged in
            } else {
                Shell.Current.GoToAsync("//Login");  // Navigate to Login if not logged in
            }
        }

        private void OnCurrentUserChanged(object sender, EventArgs e) {
            // Handle changes in the current user, such as login/logout.
            bool isLoggedIn = UserManager.Instance.CurrentUser != null;
            // You can perform any necessary actions here when the user state changes.
        }
    }
}
