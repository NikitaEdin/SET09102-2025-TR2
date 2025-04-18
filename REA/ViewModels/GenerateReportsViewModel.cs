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
        private ObservableCollection<int> relativeHumidity2m;
        [ObservableProperty]
        private double windSpeed10m;
        [ObservableProperty]
        private int windDirection10m;

        public GenerateReportsViewModel() 
        {
            LoadMeasurements();
        }
        private async Task LoadMeasurements()
        {
            
            MeasurementFactory<AirMeasurement> airFactory = await MeasurementFactory<AirMeasurement>.CreateAsync<AirMeasurement>();
            MeasurementFactory<WaterMeasurement> waterFactory = await MeasurementFactory<WaterMeasurement>.CreateAsync<WaterMeasurement>();
            MeasurementFactory<WeatherMeasurement> weatherFactory = await MeasurementFactory<WeatherMeasurement>.CreateAsync<WeatherMeasurement>();

            AirMeasurements = airFactory.GetMeasurements();
            WaterMeasurements = waterFactory.GetMeasurements();
            WeatherMeasurements = weatherFactory.GetMeasurements();

            // Air
            var NitrogenDioxideValues = new ObservableCollection<double>(AirMeasurements.Select(a => a.NitrogenDioxide ?? 0));
            var SulphurDioxideValues = new ObservableCollection<double>(AirMeasurements.Select(a => a.SulphurDioxide ?? 0));
            var Pm2_5Values = new ObservableCollection<double>(AirMeasurements.Select(a => a.PM2_5 ?? 0));
            var Pm10Values = new ObservableCollection<double>(AirMeasurements.Select(a =>a.PM10 ?? 0));

            NitrogenDioxide = CalculateAverage(NitrogenDioxideValues);
            SulphurDioxide = CalculateAverage(SulphurDioxideValues);
            Pm2_5 = CalculateAverage(Pm2_5Values);
            Pm10 = CalculateAverage(Pm10Values);

            // Water
            var Nitrate1Values = new ObservableCollection<double>(WaterMeasurements.Select(a => a.Nitrite ?? 0));
            var Nitrate2Values = new ObservableCollection<double>(WaterMeasurements.Select(a => a.Nitrate ?? 0));
            var PhosphateValues = new ObservableCollection<double>(WaterMeasurements.Select(a => a.Phosphate ?? 0));
            var ecValues = new ObservableCollection<double>(WaterMeasurements.Select(a => a.EC ?? 0));

            Nitrate1 = CalculateAverage(Nitrate1Values);
            Nitrate2 = CalculateAverage(Nitrate2Values);
            Phosphate = CalculateAverage(PhosphateValues);
            Ec = CalculateAverage(ecValues);

            // Weather
            var Temperature2mValues = new ObservableCollection<double>(WeatherMeasurements.Select(a => a.Temperature2m ?? 0));
            var RelativeHumidity2mValues = new ObservableCollection<int>(WeatherMeasurements.Select(a => a.RelativeHumidity2m ?? 0));
            var WindSpeed10mValues = new ObservableCollection<double>(WeatherMeasurements.Select(a => a.WindSpeed10m ?? 0));
            var WindDirection10mValues = new ObservableCollection<int>(WeatherMeasurements.Select(a => a.WindDirection10m ?? 0));

            Temperature2m = CalculateAverage(Temperature2mValues);
            //This is an int need to convert it RelativeHumidity2m = CalculateAverage(RelativeHumidity2mValues);
            WindSpeed10m = CalculateAverage(WindSpeed10mValues);
           // This is an int need to convert WindDirection10m = CalculateAverage(WindDirection10mValues
        }

        private double CalculateAverage(ObservableCollection<double> collection)
        {
            double sum = 0;
            double average = 0;
            int count = 0;
            
            foreach (double value in collection)
            {
                sum += value;
                count++;
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

    }
}
