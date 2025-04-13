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

namespace REA.ViewModels
{
    public partial class UpdateSensorViewModel : ObservableObject
    {
        // AIR
        [ObservableProperty]
        private ObservableCollection<Configuration> airSensorType;
        [ObservableProperty]
        private ObservableCollection<Configuration> nitrogenDioxide;
        [ObservableProperty]
        private ObservableCollection<Configuration> sulphurDioxide;
        [ObservableProperty]
        private ObservableCollection<Configuration> particulateMatter;

        // WATER
        [ObservableProperty]
        private ObservableCollection<Configuration> waterSensorType;
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
        private ObservableCollection<Configuration> weatherSensorType;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task LoadConfigs()
        {
            // Call the factory
            ConfigFactory factory = await ConfigFactory.CreateAsync();

            ObservableCollection<Configuration> configs = factory.GetConfigurations();

            if (configs != null)
            {
                // Air
                AirSensorType = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrogen dioxide" || c.Type == "Sulphur dioxide" || c.Type == "Particulate matter"));

                NitrogenDioxide = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrogen dioxide"));
                SulphurDioxide = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Sulphur dioxide"));
                ParticulateMatter = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Particulate matter"));

                // Water
                WaterSensorType = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrate" || c.Type == "Phosphate" || c.Type == "Escherichia coli" || c.Type == "Intestinal enterococci"));

                Nitrate = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrate"));
                Phosphate = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Phosphate"));
                EscherichiaColi = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Escherichia coli"));
                IntestinalEnterococci = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Intestinal enterococci"));


                // Weather
                WeatherSensorType = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Air Temperature" || c.Type == "Humidity" || c.Type == "Wind speed" || c.Type == "Wind Direction"));

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

            SensorTypes = new ObservableCollection<string> { "Nitrogen dioxide","Sulphur dioxide", "Particulate matter", "Nitrate", "Phosphate" , "Escherichia coli" , "Intestinal enterococci", "Air Temperature", "Humidity", "Wind speed", "Wind Direction" };

        }

        public async Task UpdateConfig()
        {
           foreach (var sensorType in SensorTypes) {

                switch (sensorType)
                {
                    case "Nitrogen dioxide":
                        await SQLiteDatabaseService.Instance.UpdateAsync(NitrogenDioxide.Where(t => t.Type == "Nitrogen dioxide"));
                        break;

                    case "Sulphur dioxide":
                        await SQLiteDatabaseService.Instance.UpdateAsync(SulphurDioxide.Where(t => t.Type == "Sulphur dioxide"));
                        break;

                    case "Particulate matter":
                        await SQLiteDatabaseService.Instance.UpdateAsync(ParticulateMatter.Where(t => t.Type == "Particulate matter"));
                        break;
                }
            }


        }
    }
}
