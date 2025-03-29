using REA.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Utils;
using REA.DB;
using System.Collections.ObjectModel;

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
            var validUser = usersFromDb.FirstOrDefault(user => user.Username == Username && user.Password == Password);

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
       
    }
}
