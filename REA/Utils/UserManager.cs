using REA.Models;
using REA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REA.Utils {
    public class UserManager {
        private static UserManager _instance;
        private User _currentUser;

        private UserManager() { }

        // Public property to access instance
        public static UserManager Instance => _instance ??= new UserManager();

        // Property to get/set current user
        public User CurrentUser {
            get => _currentUser;
            set {
                if (_currentUser != value) {
                    _currentUser = value;
                    OnCurrentUserChanged();


                    if (Application.Current.MainPage is Shell shell && shell.BindingContext is AppShellViewModel viewModel) {
                        viewModel.IsLoggedIn = true;
                    }
                }
            }
        }

        public event EventHandler CurrentUserChanged;

        private void OnCurrentUserChanged() {
            CurrentUserChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
