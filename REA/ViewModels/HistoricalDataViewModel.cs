using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace REA.ViewModels
{
    public partial class HistoricalDataViewModel : ObservableObject {

        // Data categories
        [ObservableProperty]
        private ObservableCollection<AirQualityData> airQualityRecords;

        [ObservableProperty]
        private ObservableCollection<WaterQualityData> waterQualityRecords;

        [ObservableProperty]
        private ObservableCollection<WeatherData> weatherRecords;

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

            // Load dummy data for testing purposes
            LoadDummyData();
        }

        private void LoadDummyData() {
            AirQualityRecords = new ObservableCollection<AirQualityData>
            {
                new AirQualityData { Date = DateTime.Now.AddDays(-1), NitrogenDioxide = 30, SulphurDioxide = 20, PM25 = 12, PM10 = 25 },
                new AirQualityData { Date = DateTime.Now.AddDays(-2), NitrogenDioxide = 28, SulphurDioxide = 18, PM25 = 14, PM10 = 22 }
            };

            WaterQualityRecords = new ObservableCollection<WaterQualityData>
            {
                new WaterQualityData { Date = DateTime.Now.AddDays(-1), Nitrate = 5.2, Nitrite = 0.8, Phosphate = 1.3, EC = 450 },
                new WaterQualityData { Date = DateTime.Now.AddDays(-2), Nitrate = 5.5, Nitrite = 0.7, Phosphate = 1.5, EC = 460 }
            };

            WeatherRecords = new ObservableCollection<WeatherData>
            {
                new WeatherData { Date = DateTime.Now.AddDays(-1), Temperature = 22.5, RelativeHumidity = 60, WindSpeed = 15, WindDirection = "N" },
                new WeatherData { Date = DateTime.Now.AddDays(-2), Temperature = 21.0, RelativeHumidity = 58, WindSpeed = 10, WindDirection = "NE" }
            };
        }

        // Category selection
        private void SelectCategory(string category) {
            IsAirQualityVisible = category == "AirQuality";
            IsWaterQualityVisible = category == "WaterQuality";
            IsWeatherVisible = category == "Weather";
        }


    }


    //////// Dummy objects for prototyping until database is implemented ////////

    // Air Quality 
    public class AirQualityData {
        public DateTime Date { get; set; }
        public double NitrogenDioxide { get; set; }
        public double SulphurDioxide { get; set; }
        public double PM25 { get; set; }
        public double PM10 { get; set; }
    }

    // Water Quality
    public class WaterQualityData {
        public DateTime Date { get; set; }
        public double Nitrate { get; set; }
        public double Nitrite { get; set; }
        public double Phosphate { get; set; }
        public double EC { get; set; }
    }

    // Weather Data
    public class WeatherData {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double RelativeHumidity { get; set; }
        public double WindSpeed { get; set; }
        public string WindDirection { get; set; }
    }
}
