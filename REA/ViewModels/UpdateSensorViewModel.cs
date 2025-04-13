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

namespace REA.ViewModels
{
    public partial class UpdateSensorViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Configuration> waterSensorType;
        [ObservableProperty]
        private ObservableCollection<Configuration> airSensorType;
        [ObservableProperty]
        private ObservableCollection<Configuration> weatherSensorType;

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

        public UpdateSensorViewModel()
        {
            LoadConfigs();
        }

        public async Task LoadConfigs()
        {
            // Call the factory
            ConfigFactory factory = await ConfigFactory.CreateAsync();

            ObservableCollection<Configuration> configs = factory.GetConfigurations();

            if (configs != null)
            {
                // Air
                AirSensorType = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrogen dioxide" || c.Type == "Sulphur dioxide" || c.Type == "Particulate matter"));
                //NitrogenDioxide = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrogen dioxide"));

                WaterSensorType = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Nitrate" || c.Type == "Phosphate" || c.Type == "Escherichia coli" || c.Type == "Intestinal enterococci"));
                WeatherSensorType = new ObservableCollection<Configuration>(configs.Where(c => c.Type == "Air Temperature" || c.Type == "Humidity" || c.Type == "Wind speed" || c.Type == "Wind Direction"));
                Debug.WriteLine(configs);

            }
            else
            {
                Debug.WriteLine("UNABLE TO POPULATE ");
            }

            SensorTypes = new ObservableCollection<string> { "Air", "Water", "Weather" };

        }

        public async Task UpdateConfig()
        {
            if (SensorTypes != null)
            {
                if (SensorMinValue != null)
                {

                }
            }
        }
    }
}
