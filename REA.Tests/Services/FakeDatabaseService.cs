using REA.DB;
using REA.Models;

namespace REA.Tests.Services {
    /// <summary>
    /// Mock/Fake database - simulating the real database interface with dummy records for each table.
    /// Author: Nikita Lanetsky
    /// </summary>
    public class FakeDatabaseService : IDatabaseService {
        //////// Simulating database content using lists ////////

        // Users and roles
        public List<User> Users { get; set; } = new List<User> {
            new User { UserID = 0, Username = "admin", Password = "123", RoleId = 0 },
            new User { UserID = 1, Username = "operations", Password = "123", RoleId = 1 },
            new User { UserID = 2, Username = "env_sci", Password = "123", RoleId = 2}
        };

        public List<Role> Roles { get; set; } = new List<Role> {
            new Role { RoleID = 0, Title = "Administrator", Power = 90 },
            new Role { RoleID = 1, Title = "Operations Manager", Power = 70 },
            new Role { RoleID = 2, Title = "Environmental Scientist", Power = 60 }
        };

        // Measurements
        public List<AirMeasurement> AirMeasurements { get; set; } = new List<AirMeasurement>  {
            new AirMeasurement { AirMeasurementsId = 0, DateTime = "2025-02-01 01:00:00", NitrogenDioxide = 26.3925, SulphurDioxide = 1.59654, PM2_5 = 5.094, PM10 = 8.3, Metadata = null },
            new AirMeasurement { AirMeasurementsId = 1, DateTime = "2025-02-01 02:00:00", NitrogenDioxide = 22.5675, SulphurDioxide = 1.33045, PM2_5 = 5.094, PM10 = 7.9, Metadata = null }
        };

        public List<WaterMeasurement> WaterMeasurements { get; set; } = new List<WaterMeasurement> {
            new WaterMeasurement { WaterMeasurementId = 0, Datetime = "01/02/2025 01:00:00", Nitrate = 26.33, Nitrite = 1.33, Phosphate = 0.07, EC = 0, Metadata = null },
            new WaterMeasurement { WaterMeasurementId = 1, Datetime = "01/02/2025 02:00:00", Nitrate = 23.4, Nitrite = 1.52, Phosphate = 0.06, EC = 0, Metadata = null }
        };

        public List<WeatherMeasurement> WeatherMeasurements { get; set; } = new List<WeatherMeasurement> {
            new WeatherMeasurement { WeatherMeasurementsId = 0, DateTime = "01/02/2025 00:00:00", Temperature2m = 0.6, RelativeHumidity2m = 98, WindSpeed10m = 1.18, WindDirection10m = 78, Metadata = null },
            new WeatherMeasurement { WeatherMeasurementsId = 1, DateTime = "01/02/2025 01:00:00", Temperature2m = 2.4, RelativeHumidity2m = 96, WindSpeed10m = 0.93, WindDirection10m = 106, Metadata = null }
        };

        // Sites
        public List<Sites> Sites { get; set; } = new List<Sites> {
            new Sites { siteID = 0, siteName = "Edinburgh Nicolson Street", latitude = 55.94476f, longitude = -3.183991f, evelvation = 0, timezone = "", utcOffset = 0, type = "Urban Traffic", zone = "Central Scotland", agglomeration = "Edinburgh Urban Area", localAuthority = "Edinburgh" },
            new Sites { siteID = 1, siteName = "Glencorse B",               latitude = 55.86111111f, longitude = 3.25388889f, evelvation = 0, timezone = "", utcOffset = 0, type = "Water Quality", zone = "", agglomeration = "", localAuthority = "" },
            new Sites { siteID = 2, siteName = "",                          latitude = 55.008785f, longitude = -3.5856323f, evelvation = 8, timezone = "", utcOffset = 0, type = "Weather", zone = "", agglomeration = "", localAuthority = "" }
        };

        // Sensors
        public List<Sensors> Sensors { get; set; } = new List<Sensors> {
            new Sensors { SensorId = 0, SiteId = 1, SensorType = "Air", SensorUrl = "https://airly.org/en/features/air-quality-sensors/", DeploymentDate = "2025-04-06", SensorOperational = true },
            new Sensors { SensorId = 1, SiteId = 2, SensorType = "Water", SensorUrl = "https://clearwatersensors.com/nitrate-sensor.html", DeploymentDate = "2023-01-01", SensorOperational = true },
            new Sensors { SensorId = 2, SiteId = 3, SensorType = "Weather", SensorUrl = "https://www.alliot.co.uk/product/netvox-outdoor-temperature-and-humidity-sensor/", DeploymentDate = "2024-08-12", SensorOperational = true }
        };

        // Configuration
        public List<Configuration> Configurations { get; set; } = new List<Configuration> {
            new Configuration { SensorId = 0, MinMeasurement = 0.1f, MaxMeasurement = 199, Type = "Nitrogen dioxide", Firmware = 0.1f },
            new Configuration { SensorId = 1, MinMeasurement = 0.1f, MaxMeasurement = 2, Type = "Nitrate", Firmware = 0.1f },
            new Configuration { SensorId = 2, MinMeasurement = 0.1f, MaxMeasurement = 184, Type = "Air Temperature", Firmware = 0.1f }
        };

        // Metadata
        public List<Metadata> MetadataList { get; set; } = new List<Metadata> {
            new Metadata { ID = 0, Category = "Air quality", Quantity = "Nitrogen dioxide", Symbol = "NO2", Unit = "ug/m3", Unit_desc = "microgrammes per cubic metre", Measurement_freq = "Hourly", Safe_level = 200, Reference_url = "https://uk-air.defra.gov.uk/air-pollution/daqi?view=more-info&pollutant=no2#pollutant", Sensor = "Airly", Sensor_ID = null },
            new Metadata { ID = 1, Category = "Water quality", Quantity = "Nitrite", Symbol = "-NO3", Unit = "mg/l", Unit_desc = "milligrammes per litre", Measurement_freq = "Hourly", Safe_level = 3, Reference_url = "https://cdn.who.int/media/docs/default-source/wash-documents/water-safety-and-quality/chemical-fact-sheets-2022/nitrate-and-nitrite-fact-sheet-2022.pdf?sfvrsn=a65406e9_2&download=true", Sensor = "ClearWater", Sensor_ID = null },
            new Metadata { ID = 2, Category = "Weather", Quantity = "Air temperature", Symbol = "T", Unit = "C", Unit_desc = "Degrees Celcius", Measurement_freq = "Hourly", Safe_level = 0, Reference_url = "", Sensor = "Netvox R712", Sensor_ID = null }
        };

        // Alerts
        public List<Alert> Alerts { get; set; } = new List<Alert> {
            new Alert { Id = 0, Metadata_ID = 1, Message = "Sensor reading breached threshold with value 2123. Please review.", TriggeredAt = "2024-04-09 16:37:00" },
            new Alert { Id = 1, Metadata_ID = 2, Message = "Sensor failed to get readings for 10 minutes", TriggeredAt = "2024-05-10 20:41:00" },
            new Alert { Id = 2, Metadata_ID = 3, Message = "Sensor reading breached threshold with value 1233", TriggeredAt = "2024-04-10 16:40:00" }
        };


        // Dictionary mapping type to a class
        private readonly Dictionary<Type, object> _dataSets;
        public FakeDatabaseService() {
            _dataSets = new Dictionary<Type, object> {
                { typeof(User), Users },
                { typeof(Role), Roles },
                { typeof(AirMeasurement), AirMeasurements },
                { typeof(WaterMeasurement), WaterMeasurements },
                { typeof(WeatherMeasurement), WeatherMeasurements },
                { typeof(Sites), Sites },
                { typeof(Sensors), Sensors },
                { typeof(Configuration), Configurations },
                { typeof(Metadata), MetadataList },
                { typeof(Alert), Alerts }
            };
        }


        /// <summary> Fake insert logic - returns 1 </summary>
        public Task<int> InsertAsync<T>(T item) {
            // Get the correct list based on the given generic <T>
            if (_dataSets.TryGetValue(typeof(T), out var listObj) && listObj is IList<T> list) {
                // If found - add the items to it
                list.Add(item);
                return Task.FromResult(1);
            }

            return Task.FromResult(1);
        }
        

        public Task<List<T>> GetItemsAsync<T>() where T : new() {
            // Get the correct list based on available mapped types
            if (_dataSets.TryGetValue(typeof(T), out var list)) {
                return Task.FromResult(list as List<T> ?? new List<T>());
            }

            return Task.FromResult(new List<T>());
        }

        /// <summary> Fake success result </summary>
        public Task<int> UpdateAsync<T>(T item) => Task.FromResult(1);

        /// <summary> Fake success result </summary>
        public Task<int> DeleteAsync<T>(T item) => Task.FromResult(1); 
        

        /// <summary>  No operation for testing </summary>
        public Task CreateTableAsync<T>() where T : new() => Task.CompletedTask; 
        
    }
}
