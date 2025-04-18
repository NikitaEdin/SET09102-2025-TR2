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
        private readonly IDatabaseService _db;
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


        // User inputs - these are strings for the Binding
        [ObservableProperty]
        private string sensorMinValue;
        [ObservableProperty]
        private string sensorMaxValue;
        [ObservableProperty]
        private string sensorMesFreq;
        [ObservableProperty]
        private string sensorFirmware;

        /// <summary>
        /// Default Constructuor
        /// </summary>
        public UpdateSensorViewModel()
        {

        }

        /// <summary>
        /// Dependency injection for the database in the constructor
        /// </summary>
        /// <param name="db"> pass in the database either fakeDb or SQLiteDatabaseService</param>
        public UpdateSensorViewModel(IDatabaseService db)
        {
            _db = db;
        }

        /// <summary>
        /// This method loads the configs and all the initalisation for the config
        /// </summary>
        /// <returns>Populated collections for Air, Water, Weather</returns>
        public async Task LoadConfigs()
        {
            // Call the factory
            var factory = await ConfigFactory.CreateAsync(_db);

            var configs = factory.GetConfigurations();

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


            }

        }

        // Called when the user selects a sensor type to update the UI
        /// <summary>
        /// This method is to show relevant collections based on what the user has selected to update.
        /// </summary>
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
                case "Nitrate":
                    SelectedSensorCollection = Nitrate;
                break;
                case "Phosphate":
                    SelectedSensorCollection = Phosphate;
                    break;
                case "Escherichia coli":
                    SelectedSensorCollection = EscherichiaColi;
                    break;
                case "Intestinal enterococci":
                    SelectedSensorCollection = IntestinalEnterococci;
                    break;
                case "Air Temperature":
                    SelectedSensorCollection = AirTemperature;
                    break;
                case "Humidity":
                    SelectedSensorCollection = Humidity;
                    break;
                case "Wind speed":
                    SelectedSensorCollection = WindSpeed;
                    break;
                case "Wind Direction":
                    SelectedSensorCollection = WindDirection;
                    break;


                default:
                    SelectedSensorCollection = new ObservableCollection<Configuration>();
                    break;
            }
        }


        /// <summary>
        /// This is a command on a button that updates the database 
        /// </summary>
        /// <returns>Updates the database based on user input </returns>
        [RelayCommand]
        private async Task UpdateConfig()
        {
            if (SelectedSensorCollection == null || SelectedSensorCollection.Count == 0)
                return;

            if (string.IsNullOrWhiteSpace(sensorMinValue) || string.IsNullOrWhiteSpace(sensorMaxValue) || string.IsNullOrWhiteSpace(sensorFirmware)) return;

            float minValue = ConvertStringToFloat(sensorMinValue);
            float maxValue = ConvertStringToFloat(sensorMaxValue);
            float firmware = ConvertStringToFloat(sensorFirmware);

            foreach (var item in SelectedSensorCollection)
            {
                item.MinMeasurement = minValue;
                item.MaxMeasurement = maxValue;
                item.Firmware = firmware;

                await _db.UpdateAsync(item);

                // Trigger IPropertyChanged to update the ui 
                SelectedSensorCollection = new ObservableCollection<Configuration>(SelectedSensorCollection);
            }
        }

        /// <summary>
        /// This method converts strings to float
        /// </summary>
        /// <param name="input">The string to be converted to float</param>
        /// <returns>returns a float from the string input</returns>
        public float ConvertStringToFloat(string input)
        {
            float convertedFloat = 0f;
            try
            {
                convertedFloat = float.Parse(input);
            }
            catch (FormatException)
            {
                Debug.WriteLine("Invalid format");
                convertedFloat = 0f;
            }
            catch (ArgumentNullException)
            {
                Debug.WriteLine("Null Value Provided");
                convertedFloat = 0f;
            }
            return convertedFloat;
        }

        // When the dropdown is selected load the method
        partial void OnSelectedSensorTypeChanged(string value)
        {
            LoadSelectedSensorCollection(); 
        }


    }
}
