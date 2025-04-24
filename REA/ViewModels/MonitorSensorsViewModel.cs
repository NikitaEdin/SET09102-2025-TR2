using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.DB;
using REA.Models;

namespace REA.ViewModels {
    /// <summary>
    /// ViewModel responsible for backend for displaying all sensors and their details.
    /// </summary>
    ///
    /// \author Nikita Lanetsky
    public partial class MonitorSensorsViewModel : ObservableObject {

        // Selected sensor (if any)
        [ObservableProperty]
        private Sensors selectedSensor;

        /// <summary>Collection of available sensors to display</summary>
        [ObservableProperty]
        public ObservableCollection<Sensors> sensors;

        // DB service
        private readonly IDatabaseService _db;

        /// <summary>
        /// Initialises the ViewModel with default database service
        /// </summary>
        public MonitorSensorsViewModel() : this(SQLiteDatabaseService.Instance) { }

        /// <summary>
        /// Initialises the ViewModel with specific database service (optional for service override)
        /// </summary>
        /// <param name="db">The database service to use -null to use default</param>
        public MonitorSensorsViewModel(IDatabaseService? db = null) {
            _db = db ?? SQLiteDatabaseService.Instance;
        }

        /// <summary>
        /// Retrieves all sensors from database and populates the Sensors collection.
        /// </summary>
        public async Task GetSensors() {
            // Get all sensors from database
            Sensors = new ObservableCollection<Sensors>(await _db.GetItemsAsync<Sensors>());
        }

        // Set the selected sensor
        [RelayCommand]
        private void SelectSensor(Sensors sensor) {
            SelectedSensor = sensor;
        }
    }
}
