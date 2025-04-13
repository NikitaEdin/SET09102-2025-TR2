using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Utils;
using REA.Models;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using REA.DB;
using static Microsoft.Maui.ApplicationModel.Permissions;
using CommunityToolkit.Mvvm.Input;

namespace REA.ViewModels
{
    public partial class UpdateSensorViewModel : ObservableObject
    {
        // AIR
        [ObservableProperty]
        private ObservableCollection<Configuration> nitrogenDioxide;
        [ObservableProperty]
        private ObservableCollection<Configuration> sulphurDioxide;
        [ObservableProperty]
        private ObservableCollection<Configuration> particulateMatter;

        // WATER
        [ObservableProperty]
        private ObservableCollection<Configuration> nitrate;
        [ObservableProperty]
        private ObservableCollection<Configuration> phosphate;
        [ObservableProperty]
        private ObservableCollection<Configuration> escherichiaColi;
        [ObservableProperty]
        private ObservableCollection<Configuration> intestinalEnterococci;


        // WEATHER
        [ObservableProperty]
        private ObservableCollection<Configuration> airTemperature;
        [ObservableProperty]
        private ObservableCollection<Configuration> humidity;
        [ObservableProperty]
        private ObservableCollection<Configuration> windSpeed;
        [ObservableProperty]
        private ObservableCollection<Configuration> windDirection;

        // Drop down of the different sensor types
        [ObservableProperty]
        private ObservableCollection<string> sensorTypes;

        // Selected item binding
        [ObservableProperty]
        private string selectedSensorType;

        // Used to show a coresponding collection based on the selection
        [ObservableProperty]
        private ObservableCollection<Configuration> selectedSensorCollection;


        // User inputs
        [ObservableProperty]
        private string sensorMinValue;
        [ObservableProperty]
        private string sensorMaxValue;
        [ObservableProperty]
        private string sensorMesFreq;
        [ObservableProperty]
        private string sensorFirmware;

        /// <summary>
        /// Constructor
        /// </summary>
        public UpdateSensorViewModel()
        {
            LoadConfigs();
        }

        /// <summary>
        /// This method loads the configs and all the initalisation for the config
        /// </summary>
        /// <returns>Populated collections for Air, Water, Weather</returns>
        public async Task LoadConfigs()
        {
            // Call the factory
            ConfigFactory factory = await ConfigFactory.CreateAsync();

            ObservableCollection<Configuration> configs = factory.GetConfigurations();

            SensorTypes = new ObservableCollection<string> { "Nitrogen dioxide", "Sulphur dioxide", "Particulate matter", "Nitrate", "Phosphate", "Escherichia coli", "Intestinal enterococci", "Air Temperature", "Humidity", "Wind speed", "Wind Direction" };

            if (configs != null)
            {
                // Air
                NitrogenDioxide = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrogen dioxide"));
                SulphurDioxide = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Sulphur dioxide"));
                ParticulateMatter = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Particulate matter"));

                // Water
                Nitrate = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrate"));
                Phosphate = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Phosphate"));
                EscherichiaColi = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Escherichia coli"));
                IntestinalEnterococci = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Intestinal enterococci"));


                // Weather
                AirTemperature = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Air Temperature"));
                Humidity = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Humidity"));
                WindSpeed = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Wind speed"));
                WindDirection = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Wind Direction"));


                Debug.WriteLine(configs);

            }
            else
            {
                Debug.WriteLine("UNABLE TO POPULATE ");
            }

        }

        // Called when the user selects a sensor type to update the UI
        private void LoadSelectedSensorCollection()
        {
            switch (SelectedSensorType)
            {
                case "Nitrogen dioxide":
                    SelectedSensorCollection = NitrogenDioxide;
                    break;
                case "Sulphur dioxide":
                    SelectedSensorCollection = SulphurDioxide;
                    break;
                case "Particulate matter":
                    SelectedSensorCollection = ParticulateMatter;
                    break;
                default:
                    SelectedSensorCollection = new ObservableCollection<Configuration>();
                    break;
            }
        }


        // Make this command in future 
        public async Task UpdateConfig()
        {
            if (SelectedSensorCollection == null || SelectedSensorCollection.Count == 0)
                return;

            foreach (var item in SelectedSensorCollection)
            {
                
                item.MinMeasurement = SensorMinValue;
                item.MaxMeasurement = SensorMaxValue;
                item.Firmware = SensorFirmware;

                await SQLiteDatabaseService.Instance.UpdateAsync(item);
            }
        }

        // When the dropdown is selected load the method
        partial void OnSelectedSensorTypeChanged(string value)
        {
            LoadSelectedSensorCollection(); 
        }


    }
}
