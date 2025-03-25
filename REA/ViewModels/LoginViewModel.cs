using REA.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Utils;
using REA.Views;

namespace REA.ViewModels {
    public partial class LoginViewModel : ObservableObject {
        private readonly User _validUser = new User { Username = "admin", Password = "123" };

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
            if (Username == _validUser.Username && Password == _validUser.Password) {
                ErrorMessage = string.Empty;
                UserManager.Instance.CurrentUser = _validUser;


                await Shell.Current.GoToAsync("//Dashboard");
            } else {
                ErrorMessage = "Invalid username or password";
            }
        }
    }
}
