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
using CommunityToolkit.Mvvm.Input;

namespace REA.ViewModels
{
    public partial class GenerateReportsViewModel : ObservableObject
    {
        // Hold the measurements in a collection
        private ObservableCollection<AirMeasurement> airMeasurements;
        private ObservableCollection<WaterMeasurement> waterMeasurements;
        private ObservableCollection<WeatherMeasurement> weatherMeasurements;

        // Air
        [ObservableProperty]
        private double nitrogenDioxide;
        [ObservableProperty]
        private double sulphurDioxide;
        [ObservableProperty]
        private double pm2_5;
        [ObservableProperty]
        private double pm10;

        // Water
        [ObservableProperty]
        private double nitrate1;
        [ObservableProperty]
        private double nitrate2;
        [ObservableProperty]
        private double phosphate;
        [ObservableProperty]
        private double ec;

        // Weather
        [ObservableProperty]
        private double temperature2m;
        [ObservableProperty]
        private double relativeHumidity2m;
        [ObservableProperty]
        private double windSpeed10m;
        [ObservableProperty]
        private double windDirection10m;

        public GenerateReportsViewModel() 
        {
            LoadMeasurements();
        }
        private async Task LoadMeasurements()
        {
            // Initalise the factory for each of the measurement types
            MeasurementFactory<AirMeasurement> airFactory = await MeasurementFactory<AirMeasurement>.CreateAsync<AirMeasurement>();
            MeasurementFactory<WaterMeasurement> waterFactory = await MeasurementFactory<WaterMeasurement>.CreateAsync<WaterMeasurement>();
            MeasurementFactory<WeatherMeasurement> weatherFactory = await MeasurementFactory<WeatherMeasurement>.CreateAsync<WeatherMeasurement>();

            //  Populate the collection with measurements
            airMeasurements = airFactory.GetMeasurements();
            waterMeasurements = waterFactory.GetMeasurements();
            weatherMeasurements = weatherFactory.GetMeasurements();

            // Air
            var NitrogenDioxideValues = new ObservableCollection<double>(airMeasurements.Select(a => a.NitrogenDioxide ?? 0));
            var SulphurDioxideValues = new ObservableCollection<double>(airMeasurements.Select(a => a.SulphurDioxide ?? 0));
            var Pm2_5Values = new ObservableCollection<double>(airMeasurements.Select(a => a.PM2_5 ?? 0));
            var Pm10Values = new ObservableCollection<double>(airMeasurements.Select(a =>a.PM10 ?? 0));

            // Calculate the mean of the measurements for Air
            NitrogenDioxide = CalculateAverage(NitrogenDioxideValues);
            SulphurDioxide = CalculateAverage(SulphurDioxideValues);
            Pm2_5 = CalculateAverage(Pm2_5Values);
            Pm10 = CalculateAverage(Pm10Values);

            // Water
            var Nitrate1Values = new ObservableCollection<double>(waterMeasurements.Select(a => a.Nitrite ?? 0));
            var Nitrate2Values = new ObservableCollection<double>(waterMeasurements.Select(a => a.Nitrate ?? 0));
            var PhosphateValues = new ObservableCollection<double>(waterMeasurements.Select(a => a.Phosphate ?? 0));
            var ecValues = new ObservableCollection<double>(waterMeasurements.Select(a => a.EC ?? 0));

            // Calculate the mean of the measurements for Water
            Nitrate1 = CalculateAverage(Nitrate1Values);
            Nitrate2 = CalculateAverage(Nitrate2Values);
            Phosphate = CalculateAverage(PhosphateValues);
            Ec = CalculateAverage(ecValues);

            // Weather
            var Temperature2mValues = new ObservableCollection<double>(weatherMeasurements.Select(a => a.Temperature2m ?? 0));
            var RelativeHumidity2mValues = new ObservableCollection<int>(weatherMeasurements.Select(a => a.RelativeHumidity2m ?? 0));
            var WindSpeed10mValues = new ObservableCollection<double>(weatherMeasurements.Select(a => a.WindSpeed10m ?? 0));
            var WindDirection10mValues = new ObservableCollection<int>(weatherMeasurements.Select(a => a.WindDirection10m ?? 0));

            // Calculate the mean of the measurements for Weather
            Temperature2m = CalculateAverage(Temperature2mValues);
            RelativeHumidity2m = CalculateAverage(RelativeHumidity2mValues);
            WindSpeed10m = CalculateAverage(WindSpeed10mValues);
            WindDirection10m = CalculateAverage(WindDirection10mValues);
        }

        /// <summary>
        /// Generic method to allow the calculation of averages by providing a collection of values and returning an average
        /// </summary>
        /// <typeparam name="T"> Accept generic type to allow the calculation of int,float,double etc</typeparam>
        /// <param name="collection"> This is the collection thats passed in to calculate it's average</param>
        /// <returns>Returns the average of the values of a collection</returns>
        private double CalculateAverage<T>(ObservableCollection<T> collection)
        {
            double sum = 0;
            double average = 0;
            int count = 0;
            
            foreach (T value in collection)
            {
                try
                {
                    double numericValue = Convert.ToDouble(value);
                    sum += numericValue;
                    count++;
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Not a numeric value: { value}");
                }
               
            }
            
            if (count > 0)
            {
                average = sum / count;
            }
            else
            {
                average = 0;
            }

            return average;
        }

    }
}
