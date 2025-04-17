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

            AirMeasurements = airFactory.GetMeasurements();
            WaterMeasurements = waterFactory.GetMeasurements();
            WeatherMeasurements = weatherFactory.GetMeasurements();

            // Testing

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
            if (userSelection == "AirMeasurements");
        }

    }
}
