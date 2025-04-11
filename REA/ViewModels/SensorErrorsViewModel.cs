using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Models;
using REA.DB;
using CommunityToolkit.Mvvm.Input;


namespace REA.ViewModels
{
    public partial class SensorErrorsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Sensors> malfunctioningSensors;

        public SensorErrorsViewModel()
        {

        }

        public async Task LoadSensors()
        {
            Debug.WriteLine("LoadSensors method is being called...");
            // Get the sensors from the database
            var sensors = await SQLiteDatabaseService.Instance.GetItemsAsync<Sensors>();

            if (sensors != null && sensors.Count > 0)
            {
                // Take the database list and put them into collections 
                MalfunctioningSensors = new ObservableCollection<Sensors>(
                    sensors.Where(s => !s.SensorOperational));


            }
            else
            {
                Debug.WriteLine("Sensors table is Null");
            }

        }

        /// <summary>
        /// Command to navigate to operations page
        /// </summary>
        /// <returns>A Task to perform a navigation operation to the operations page</returns>
        [RelayCommand]
        public async Task NavigateToOperations()
        {
            await Shell.Current.GoToAsync("//Operations");
        }

    }
}
