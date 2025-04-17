using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.DB;
using REA.Models;

namespace REA.ViewModels {
    /// <summary>
    /// ViewModel responsible for backend for displaying all sensors and their details.
    /// Author: Nikita Lanetsky
    /// </summary>
    public partial class MonitorSensorsViewModel : ObservableObject {

        // Selected sensor (if any)
        [ObservableProperty]
        private Sensors selectedSensor;

        // List of available sensors
        [ObservableProperty]
        public ObservableCollection<Sensors> sensors;

        // DB service
        private readonly IDatabaseService _db;

        public MonitorSensorsViewModel() : this(SQLiteDatabaseService.Instance) { }

        public MonitorSensorsViewModel(IDatabaseService? db = null) {
            _db = db ?? SQLiteDatabaseService.Instance;
        }

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
