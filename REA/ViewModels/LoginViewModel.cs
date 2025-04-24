using REA.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Utils;
using REA.DB;

namespace REA.ViewModels {
    public partial class LoginViewModel : ObservableObject {

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        public ICommand LoginCommand { get; }

        public LoginViewModel() {
            LoginCommand = new RelayCommand(Login);
        }

        private async void Login() {
            // Fetch users from DB
            var usersFromDb = await SQLiteDatabaseService.Instance.GetItemsAsync<User>();
            var validUser = ValidateUser(usersFromDb, Username, Password);

            if (validUser != null) {
                // Valid user found in the database
                ErrorMessage = string.Empty;
                UserManager.Instance.CurrentUser = validUser;

                // Navigate to the dashboard
                await Shell.Current.GoToAsync("//Dashboard");
            } else {
                // Invalid credentials
                ErrorMessage = "Invalid username or password";
            }
        }

        /// <summary>
        /// Validates given user credentials within a given list of available users
        /// </summary>
        /// <param name="users">List of available users</param>
        /// <param name="username">New username to authenticate with</param>
        /// <param name="password">New password to authenticate with</param>
        /// <returns>Valid user (if found)</returns>
        public User ValidateUser(IEnumerable<User> users, string username, string password) {
            return users.FirstOrDefault(user => user.Username == username && user.Password == password);
        }

    }
}
