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
using __XamlGeneratedCode__;
using REA.Utils;


namespace REA.ViewModels
{
    /// <summary>
    /// Author: Thomas Smith
    /// Backend for the view "SensorsErrorPage" which displays to the user the sensor malfunction count and the list of non-functional sensors
    /// </summary>
    public partial class SensorErrorsViewModel : ObservableObject
    {
        private readonly IDatabaseService _db;
        [ObservableProperty]
        private ObservableCollection<Sensors> malfunctioningSensors;

        /// <summary>
        /// Default Constructuor
        /// </summary>
        public SensorErrorsViewModel()
        {

        }
        /// <summary>
        /// Dependency injection for the database in the constructor
        /// </summary>
        /// <param name="db"> pass in the database either fakeDb or SQLiteDatabaseService</param>
        public SensorErrorsViewModel(IDatabaseService db)
        {
            _db = db;
        }

        /// <summary>
        /// Populates the ObservableCollection with the malfunctioning sensors
        /// </summary>
        public async Task LoadSensors()
        {
            Debug.WriteLine("LoadSensors method is being called...");
            // Get the sensors from the database
            var factory = await Factory<Sensors>.CreateAsync<Sensors>(_db);
            var sensors = factory.GetCollection();

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
