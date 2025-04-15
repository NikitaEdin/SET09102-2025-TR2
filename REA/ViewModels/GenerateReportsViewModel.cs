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
        private async Task LoadMeasurements()
        {
            double? sum = 0;
            int count = 0;
            MeasurementFactory<AirMeasurement> airFactory = await MeasurementFactory<AirMeasurement>.CreateAsync<AirMeasurement>();
            MeasurementFactory<WaterMeasurement> waterFactory = await MeasurementFactory<WaterMeasurement>.CreateAsync<WaterMeasurement>();
            MeasurementFactory<WeatherMeasurement> weatherFactory = await MeasurementFactory<WeatherMeasurement>.CreateAsync<WeatherMeasurement>();

            ObservableCollection<AirMeasurement> airMeasurements = airFactory.GetMeasurements();
            ObservableCollection<WaterMeasurement> waterMeasurements = waterFactory.GetMeasurements();
            ObservableCollection<WeatherMeasurement> weatherMeasurements = weatherFactory.GetMeasurements();

        }

        private void CalculateAverage(ObservableCollection<WaterMeasurement> collection)
        {
            double? sum = 0;
            double? average = 0;
            int count = 0;
            
            foreach (WaterMeasurement item in collection)
            {
                sum += item.Nitrate;
                count++;

                Debug.WriteLine(item.ToString());

            }
            
            if (count > 0)
            {
                average = sum / count;
            }
            else
            {
                average = 0;
            }

            Debug.WriteLine("Average of Nitrate : " + average);
        }

    }
}
