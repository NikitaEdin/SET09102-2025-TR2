using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.DB;
using REA.Models;

namespace REA.ViewModels {
    /// <summary>
    /// ViewModel backend for displaying different measurements (from sensors).
    /// Author: Nikita Lanetsky
    /// </summary>
    public partial class HistoricalDataViewModel : ObservableObject {

        // Data categories
        [ObservableProperty]
        private ObservableCollection<AirMeasurement> airMeasurements; 

        [ObservableProperty]
        private ObservableCollection<WaterMeasurement> waterMeasurements;

        [ObservableProperty]
        private ObservableCollection<WeatherMeasurement> weatherMeasurements;

        // Control visibility of categories
        [ObservableProperty]
        private bool isAirQualityVisible;

        [ObservableProperty]
        private bool isWaterQualityVisible;

        [ObservableProperty]
        private bool isWeatherVisible;


        // Switching categories
        public IRelayCommand SelectCategoryCommand { get; }


        public HistoricalDataViewModel() {
            SelectCategoryCommand = new RelayCommand<string>(SelectCategory);

            // Populate lists
            populateRecords();
        }

        public async void populateRecords() {
            // Water
            WaterMeasurements = new ObservableCollection<WaterMeasurement>(await SQLiteDatabaseService.Instance.GetItemsAsync<WaterMeasurement>());
            // Air
            AirMeasurements = new ObservableCollection<AirMeasurement>(await SQLiteDatabaseService.Instance.GetItemsAsync<AirMeasurement>());
            // Weather
            WeatherMeasurements = new ObservableCollection<WeatherMeasurement>(await SQLiteDatabaseService.Instance.GetItemsAsync<WeatherMeasurement>());
        }


        // Category selection
        private void SelectCategory(string category) {
            IsAirQualityVisible = category == "AirQuality";
            IsWaterQualityVisible = category == "WaterQuality";
            IsWeatherVisible = category == "Weather";
        }
    }
}
