﻿using REA.ViewModels; 
using REA.Utils;
using REA.Views;

namespace REA {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();

            /////// Routes for Subpages ///////
            // Admin routes
            Routing.RegisterRoute("UserManagement", typeof(UserManagementPage)); // Nikita
            Routing.RegisterRoute("UpdateSensor", typeof(UpdateSensorPage)); // Thomas
            // Routing.RegisterRoute("AuthConfig", typeof(CLASS)); // Ramsay
            Routing.RegisterRoute("StorageManagement", typeof(StorageManagementPage)); // Rachael

            // Environmetal Scientist routes
            Routing.RegisterRoute("HistoricalData", typeof(HistoricalDataPage)); // Nikita
            // Routing.RegisterRoute("Map", typeof(CLASS)); // Ramsay
            Routing.RegisterRoute("EnvironmentalReports", typeof(GenerateReportsPage)); // Thomas
            Routing.RegisterRoute("ManageSensor", typeof(ManageSensorPage)); // Rachael

            // Operations Manager routes
            Routing.RegisterRoute("MonitorSensors", typeof(MonitorSensorsPage)); // Nikita
            Routing.RegisterRoute("ManageMaintenance", typeof(ManageMaintenancePage)); // Ramsay
            // Routing.RegisterRoute("CollectedData", typeof(CLASS));

            BindingContext = new AppShellViewModel();

            // Sub to user changes
            UserManager.Instance.CurrentUserChanged += OnCurrentUserChanged;
        }

        // Auto navigate based on isLoggedIn 
        protected override void OnAppearing() {
            base.OnAppearing();

            // Is user logged in
            bool isLoggedIn = UserManager.Instance.CurrentUser != null;

            // Navigation based login state
            if (isLoggedIn) {
                Current.GoToAsync("//Dashboard"); 
            } else {
                Current.GoToAsync("//Login");
            }
        }

        // Track if current user is logged in
        private void OnCurrentUserChanged(object sender, EventArgs e) {
            bool isLoggedIn = UserManager.Instance.CurrentUser != null;
        }
    }
}
