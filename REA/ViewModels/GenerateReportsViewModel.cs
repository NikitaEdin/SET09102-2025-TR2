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
            
            MeasurementFactory<AirMeasurement> airFactory = await MeasurementFactory<AirMeasurement>.CreateAsync<AirMeasurement>();
            MeasurementFactory<WaterMeasurement> waterFactory = await MeasurementFactory<WaterMeasurement>.CreateAsync<WaterMeasurement>();
            MeasurementFactory<WeatherMeasurement> weatherFactory = await MeasurementFactory<WeatherMeasurement>.CreateAsync<WeatherMeasurement>();

            ObservableCollection<AirMeasurement> airMeasurements = airFactory.GetMeasurements();
            ObservableCollection<WaterMeasurement> waterMeasurements = waterFactory.GetMeasurements();
            ObservableCollection<WeatherMeasurement> weatherMeasurements = weatherFactory.GetMeasurements();
            CalculateAverage<WaterMeasurement>(waterMeasurements, "Nitrate");

        }

        private void CalculateAverage<T>(ObservableCollection<T> collection, string propertyName)
        {
            double sum = 0;
            double average = 0;
            int count = 0;
            
            foreach (T item in collection)
            {
                var prop = typeof(T).GetProperty(propertyName);

                if (prop != null)
                {
                    double value = (double)prop.GetValue(item);
                    sum += value;
                    count++;
                }
               

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
