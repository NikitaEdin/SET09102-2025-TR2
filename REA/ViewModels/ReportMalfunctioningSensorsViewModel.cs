
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.DB;
using REA.Models;

namespace REA.ViewModels
{
    public partial class ReportMalfunctioningSensorsViewModel : ObservableObject
    {
        // Initialise collections for the sensors
        [ObservableProperty]
        private ObservableCollection<Sensors> sensorsList;
        [ObservableProperty]
        private ObservableCollection<Sensors> malfunctioningSensors;
        [ObservableProperty]
        private ObservableCollection<Sensors> functioningSensors;
        
        public ReportMalfunctioningSensorsViewModel()
        {
            // Call the sensor method
            LoadSensors();
        }

        private async void LoadSensors()
        {
            Debug.WriteLine("LoadSensors method is being called...");
            // Get the sensors from the database
            var sensors = await SQLiteDatabaseService.Instance.GetItemsAsync<Sensors>();
          
            if (sensors != null && sensors.Count > 0){
                // Take the database list and put them into collections 
                SensorsList = new ObservableCollection<Sensors>(sensors);

                MalfunctioningSensors = new ObservableCollection<Sensors>(
                    sensors.Where(s => !s.SensorOperational));

                FunctioningSensors = new ObservableCollection<Sensors>(
                    sensors.Where(s => s.SensorOperational));

                // Debug
                foreach (var sensor in SensorsList)
                {
                    Debug.WriteLine($"ID: {sensor.SensorId}, Type: {sensor.SensorType}, URL: {sensor.SensorUrl}, Operational: {sensor.SensorOperational}");
                }

            }
            else
            {
                Debug.WriteLine("Sensors table is Null");
            }

        }


    }
}
