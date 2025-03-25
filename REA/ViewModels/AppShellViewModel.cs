using CommunityToolkit.Mvvm.ComponentModel;
using REA.Utils; 

namespace REA.ViewModels {
    public class AppShellViewModel : ObservableObject {
        
        private bool _isLoggedIn;

        
        public bool IsLoggedIn {
            get => _isLoggedIn;
            set => SetProperty(ref _isLoggedIn, value);
        }

        public AppShellViewModel() {
            // Subscribe to user changes 
            UserManager.Instance.CurrentUserChanged += OnCurrentUserChanged;

            // Initial state based on whether the user is logged in or not
            IsLoggedIn = UserManager.Instance.CurrentUser != null;
        }

        private void OnCurrentUserChanged(object sender, EventArgs e) {
            // Update IsLoggedIn based on current user
            IsLoggedIn = UserManager.Instance.CurrentUser != null;
        }
    }
}
