using REA.ViewModels; 
using REA.Utils;
using REA.Views;
using REA.Views.ReportMalfunctioningSensors;

namespace REA {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();

            /////// Routes for Subpages ///////
            // Admin routes
            Routing.RegisterRoute("UserManagement", typeof(UserManagementPage)); // Nikita
            Routing.RegisterRoute("UpdateSensor", typeof(UpdateSensorPage)); // Thomas
            // Routing.RegisterRoute("AuthConfig", typeof(CLASS)); // Ramsay
            // Routing.RegisterRoute("StorageManagement", typeof(CLASS)); // Rachael

            // Environmetal Scientist routes
            // Routing.RegisterRoute("Sensor Accounts", typeof(CLASS)); // Rachael
            Routing.RegisterRoute("HistoricalData", typeof(HistoricalDataPage)); // Nikita
            // Routing.RegisterRoute("Map", typeof(CLASS)); // Ramsay
            Routing.RegisterRoute("EnvironmentalReports", typeof(GenerateReportsPage)); // Thomas

            // Operations Manager routes
            Routing.RegisterRoute("MonitorSensors", typeof(MonitorSensorsPage)); // Nikita
            Routing.RegisterRoute("ManageMaintenance", typeof(ManageMaintenancePage)); // Ramsay
            // Routing.RegisterRoute("CollectedData", typeof(CLASS)); // Rachael
            Routing.RegisterRoute("SensorMalfunctions", typeof(ReportMalfunctioningSensorsPage)); // Thomas - Main Page
            Routing.RegisterRoute("SensorMalfunctionsReport", typeof(SensorErrorsPage)); // Thomas - sub-page of ReportMalfunctioningSensorsPage

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
