using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Models;
using REA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace REA.ViewModels {
    public partial class DashboardViewModel : ObservableObject {

        public ICommand NavigateToAdminCommand { get; }
        public ICommand NavigateToOperationsCommand { get; }
        public ICommand NavigateToEnvironmentalCommand { get; }

        private User _currentUser;

        public User CurrentUser {
            get => _currentUser;
            set {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        private string welcomeMessage = "Welcome to the Dashboard!";

        public ICommand LogoutCommand { get; }

        public DashboardViewModel() {

            NavigateToAdminCommand = new Command(async () => await NavigateToAdminPage());
            NavigateToEnvironmentalCommand = new Command(async () => await NavigateToEnvironmentalPage());
            NavigateToOperationsCommand = new Command(async () => await NavigateToOperationsPage());

            LogoutCommand = new RelayCommand(Logout);
            CurrentUser = UserManager.Instance.CurrentUser;
        }

        private async void Logout() {
            await Shell.Current.GoToAsync("//Login");
        }

        // Method to go to Admin route which is set in the app shell
        private async Task NavigateToAdminPage() {
            await Shell.Current.GoToAsync("//Admin");
        }

        private async Task NavigateToOperationsPage()
        {
            await Shell.Current.GoToAsync("//Operations");
        }

        private async Task NavigateToEnvironmentalPage()
        {
            await Shell.Current.GoToAsync("//Environmental");
        }
    }

}
