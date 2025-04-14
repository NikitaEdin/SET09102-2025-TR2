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
            var water = await SQLiteDatabaseService.Instance.GetItemsAsync<WaterMeasurement>();
            WaterMeasurements = new ObservableCollection<WaterMeasurement>(water?.ToList() ?? new List<WaterMeasurement>());
            // Air
            var air = await SQLiteDatabaseService.Instance.GetItemsAsync<AirMeasurement>();
            AirMeasurements = new ObservableCollection<AirMeasurement>(air?.ToList() ?? new List<AirMeasurement>());
            // Weather
            var weather = await SQLiteDatabaseService.Instance.GetItemsAsync<WeatherMeasurement>();
            WeatherMeasurements = new ObservableCollection<WeatherMeasurement>(weather?.ToList() ?? new List<WeatherMeasurement>());
        }


        // Category selection
        private void SelectCategory(string category) {
            IsAirQualityVisible = category == "AirQuality";
            IsWaterQualityVisible = category == "WaterQuality";
            IsWeatherVisible = category == "Weather";
        }
    }
}
