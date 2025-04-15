using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using REA.Utils;
using REA.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace REA.ViewModels
{
    public partial class GenerateReportsViewModel : ObservableObject
    {
        public GenerateReportsViewModel() 
        {
            LoadMeasurements();
        }
        public async Task LoadMeasurements()
        {
            MeasurementFactory<AirMeasurement> airFactory = await MeasurementFactory<AirMeasurement>.CreateAsync<AirMeasurement>();
            MeasurementFactory<WaterMeasurement> waterFactory = await MeasurementFactory<WaterMeasurement>.CreateAsync<WaterMeasurement>();
            MeasurementFactory<WeatherMeasurement> weatherFactory = await MeasurementFactory<WeatherMeasurement>.CreateAsync<WeatherMeasurement>();

            ObservableCollection<AirMeasurement> airMeasurements = airFactory.GetMeasurements();
            ObservableCollection<WaterMeasurement> waterMeasurements = waterFactory.GetMeasurements();
            ObservableCollection<WeatherMeasurement> weatherMeasurements = weatherFactory.GetMeasurements();

            foreach (WaterMeasurement item in waterMeasurements)
            {
                Debug.WriteLine(item.ToString());
            }
            
        }
        private void CalculateAverage()
        {
        }

    }
}
