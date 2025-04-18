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
        [ObservableProperty]
        private ObservableCollection<AirMeasurement> airMeasurements;
        [ObservableProperty]
        private ObservableCollection<WaterMeasurement> waterMeasurements;
        [ObservableProperty]
        private ObservableCollection<WeatherMeasurement> weatherMeasurements;

        // Air
        [ObservableProperty]
        private ObservableCollection<double> nitrogenDioxide;
        [ObservableProperty]
        private ObservableCollection<double> sulphurDioxide;
        [ObservableProperty]
        private ObservableCollection<double> pm2_5;
        [ObservableProperty]
        private ObservableCollection<double> pm10;

        // Water
        [ObservableProperty]
        private ObservableCollection<double> nitrate1;
        [ObservableProperty]
        private ObservableCollection<double> nitrate2;
        [ObservableProperty]
        private ObservableCollection<double> phosphate;
        [ObservableProperty]
        private ObservableCollection<double> ec;

        // Weather
        [ObservableProperty]
        private ObservableCollection<double> temperature2m;
        [ObservableProperty]
        private ObservableCollection<int> relativeHumidity2m;
        [ObservableProperty]
        private ObservableCollection<double> windSpeed10m;
        [ObservableProperty]
        private ObservableCollection<int> windDirection10m;


        [ObservableProperty]
        private ObservableCollection<string> selectedCollection;

        [ObservableProperty]
        private ObservableCollection<Object> selectedMeasurement;

        public GenerateReportsViewModel() 
        {
            LoadMeasurements();
        }
        private async Task LoadMeasurements()
        {
            
            MeasurementFactory<AirMeasurement> airFactory = await MeasurementFactory<AirMeasurement>.CreateAsync<AirMeasurement>();
            MeasurementFactory<WaterMeasurement> waterFactory = await MeasurementFactory<WaterMeasurement>.CreateAsync<WaterMeasurement>();
            MeasurementFactory<WeatherMeasurement> weatherFactory = await MeasurementFactory<WeatherMeasurement>.CreateAsync<WeatherMeasurement>();

            var AirMeasurements = airFactory.GetMeasurements();
            var WaterMeasurements = waterFactory.GetMeasurements();
            var WeatherMeasurements = weatherFactory.GetMeasurements();

            // Air
            NitrogenDioxide = new ObservableCollection<double>(AirMeasurements.Select(a => a.NitrogenDioxide ?? 0));
            SulphurDioxide = new ObservableCollection<double>(AirMeasurements.Select(a => a.SulphurDioxide ?? 0));
            Pm2_5 = new ObservableCollection<double>(AirMeasurements.Select(a => a.PM2_5 ?? 0));
            Pm10 = new ObservableCollection<double>(AirMeasurements.Select(a =>a.PM10 ?? 0));

            // Water
            Nitrate1 = new ObservableCollection<double>(WaterMeasurements.Select(a => a.Nitrite ?? 0));
            Nitrate2 = new ObservableCollection<double>(WaterMeasurements.Select(a => a.Nitrate ?? 0));
            Phosphate = new ObservableCollection<double>(WaterMeasurements.Select(a => a.Phosphate ?? 0));
            ec = new ObservableCollection<double>(WaterMeasurements.Select(a => a.EC ?? 0));

            // Weather
            temperature2m = new ObservableCollection<double>(WeatherMeasurements.Select(a => a.Temperature2m ?? 0));
            relativeHumidity2m = new ObservableCollection<int>(WeatherMeasurements.Select(a => a.RelativeHumidity2m ?? 0));
            windSpeed10m = new ObservableCollection<double>(WeatherMeasurements.Select(a => a.WindSpeed10m ?? 0));
            windDirection10m = new ObservableCollection<int>(WeatherMeasurements.Select(a => a.WindDirection10m ?? 0));

        }

        private double CalculateAverage<T>(ObservableCollection<T> collection, string propertyName)
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


            return average;
        }

        [RelayCommand]
        private void SelectCollection(string userSelection)
        {
            if (userSelection == "AirMeasurements")
            {
                SelectedMeasurement = new ObservableCollection<object>(AirMeasurements);
            }
            else if (userSelection == "WaterMeasurements")
            {
                SelectedMeasurement = new ObservableCollection<object>(WaterMeasurements);
            }
            else if (userSelection == "WeatherMeasurements")
            {
                SelectedMeasurement = new ObservableCollection<object>(WeatherMeasurements);
            }
        }

    }
}
