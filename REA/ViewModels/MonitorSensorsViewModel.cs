using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.Models;
using System.Collections.ObjectModel;

namespace REA.ViewModels {
    public partial class MonitorSensorsViewModel : ObservableObject {

        [ObservableProperty]
        private Sensor selectedSensor;

        public ObservableCollection<Sensor> Sensors { get; set; }

        public MonitorSensorsViewModel() {
            Sensors = new ObservableCollection<Sensor>
            {
                new Sensor { Id = 1, SensorType = "Temperature", SensorUrl = "http://temp-sensor.com", DeploymentDate = DateTime.Now.AddDays(-10), IsOperational = true },
                new Sensor { Id = 2, SensorType = "Pressure", SensorUrl = "http://pressure-sensor.com", DeploymentDate = DateTime.Now.AddDays(-20), IsOperational = false },
                new Sensor { Id = 3, SensorType = "Humidity", SensorUrl = "http://humidity-sensor.com", DeploymentDate = DateTime.Now.AddDays(-30), IsOperational = true }
            };
        }

        [RelayCommand]
        private void SelectSensor(Sensor sensor) {
            SelectedSensor = sensor;
        }
    }
}
