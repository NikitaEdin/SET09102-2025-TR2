
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [ObservableProperty]
        private int sensorCount;
        [ObservableProperty]
        private int sensorErrorCount;


        public ReportMalfunctioningSensorsViewModel()
        { 
        }


        /// <summary>
        /// Get sensors from the database and put them into appropriate collections.
        /// </summary>
        public async Task LoadSensors()
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

                CountSensors(SensorsList, MalfunctioningSensors);

            }
            else
            {
                SensorsList = new ObservableCollection<Sensors>();
                MalfunctioningSensors = new ObservableCollection<Sensors>();
                FunctioningSensors = new ObservableCollection<Sensors>();

            }

        }

        /// <summary>
        ///  Counts how many sensors and how many malfunctioning sensors
        /// </summary>
        /// <param name="allSensors"> Collection full of all sensors.</param>
        /// <param name="errorSensors">Collection with the list of malfunctioning sensors.</param>
        public void CountSensors(ObservableCollection<Sensors> allSensors, ObservableCollection<Sensors> errorSensors)
        {
            SensorCount = allSensors.Count;
            SensorErrorCount = errorSensors.Count;
        }


        /// <summary>
        /// Command to navigate to operations page
        /// </summary>
        /// <returns>A Task to perform a navigation operation to the operations page</returns>
        [RelayCommand]
        private async Task NavigateToOperations()
        {
            await Shell.Current.GoToAsync("//Operations");
        }

        /// <summary>
        /// Command to navigate to Sensors errors page
        /// </summary>
        /// <returns>Task to peform a navigation operation to the error sensors page</returns>
        [RelayCommand]
        private async Task NavigateToSensorErrors()
        {
            await Shell.Current.GoToAsync("SensorMalfunctionsReport");
        }

     
    }
}
