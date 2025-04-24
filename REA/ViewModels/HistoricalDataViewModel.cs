using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REA.DB;
using REA.Models;

namespace REA.ViewModels {
    /// <summary>
    /// ViewModel backend for displaying different measurements (from sensors).
    /// </summary>
    /// 
    /// \author Nikita Lanetsky
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


        /// <summary>Command for selecting active measurement (by category)</summary>
        public IRelayCommand SelectCategoryCommand { get; }

        // DB service
        private readonly IDatabaseService _db;


        /// <summary>
        /// Initialises the ViewModel with default database service
        /// </summary>
        public HistoricalDataViewModel() : this(SQLiteDatabaseService.Instance) { }

        /// <summary>
        /// Initialises the ViewModel with specific database service (optional for service override)
        /// </summary>
        /// <param name="db">The database service to use -null to use default</param>
        public HistoricalDataViewModel(IDatabaseService? db = null) {
            _db = db ?? SQLiteDatabaseService.Instance;
            SelectCategoryCommand = new RelayCommand<string>(SelectCategory);
        }

        /// <summary>
        /// Loads all measurement records (air, water, weather) from database<br></br>
        /// The records are stored in lists to be used in the View object.
        /// </summary>
        public async Task PopulateRecords() {
            // Water
            var water = await _db.GetItemsAsync<WaterMeasurement>();
            WaterMeasurements = new ObservableCollection<WaterMeasurement>(water?.ToList() ?? new List<WaterMeasurement>());
            // Air
            var air = await _db.GetItemsAsync<AirMeasurement>();
            AirMeasurements = new ObservableCollection<AirMeasurement>(air?.ToList() ?? new List<AirMeasurement>());
            // Weather
            var weather = await _db.GetItemsAsync<WeatherMeasurement>();
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
