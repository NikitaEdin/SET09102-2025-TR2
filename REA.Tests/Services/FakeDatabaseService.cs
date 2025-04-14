using REA.DB;
using REA.Models;

namespace REA.Tests.Services {
    public class FakeDatabaseService : IDatabaseService {
        //////// Simulating database content using lists ////////

        // Users and roles
        public List<User> Users { get; set; } = new List<User> {
            new User { Username = "admin", Password = "123" },
            new User { Username = "operations", Password = "123" },
            new User { Username = "env_sci", Password = "123" }
        };

        public List<Role> Roles { get; set; } = new List<Role> {
            new Role { Title = "Administrator", Power = 90 },
            new Role { Title = "Operations Manager", Power = 70 },
            new Role { Title = "Environmental Scientist", Power = 60 }
        };

        // Measurements
        public List<AirMeasurement> AirMeasurements { get; set; } = new List<AirMeasurement>  {
            new AirMeasurement { DateTime = "2025-02-01 01:00:00", NitrogenDioxide = 26.3925, SulphurDioxide = 1.59654, PM2_5 = 5.094, PM10 = 8.3, Metadata = null },
            new AirMeasurement { DateTime = "2025-02-01 02:00:00", NitrogenDioxide = 22.5675, SulphurDioxide = 1.33045, PM2_5 = 5.094, PM10 = 7.9, Metadata = null }
        };

        public List<WaterMeasurement> WaterMeasurements { get; set; } = new List<WaterMeasurement> {
            new WaterMeasurement { Datetime = "01/02/2025 01:00:00", Nitrate = 26.33, Nitrite = 1.33, Phosphate = 0.07, EC = 0, Metadata = null },
            new WaterMeasurement { Datetime = "01/02/2025 02:00:00", Nitrate = 23.4, Nitrite = 1.52, Phosphate = 0.06, EC = 0, Metadata = null }
        };

        public List<WeatherMeasurement> WeatherMeasurements { get; set; } = new List<WeatherMeasurement> {
            new WeatherMeasurement { DateTime = "01/02/2025 00:00:00", Temperature2m = 0.6, RelativeHumidity2m = 98, WindSpeed10m = 1.18, WindDirection10m = 78, Metadata = null },
            new WeatherMeasurement { DateTime = "01/02/2025 01:00:00", Temperature2m = 2.4, RelativeHumidity2m = 96, WindSpeed10m = 0.93, WindDirection10m = 106, Metadata = null }
        };

      

        /// <summary> Fake insert logic - returns 1 </summary>
        public Task<int> InsertAsync<T>(T item) => Task.FromResult(1);
        

        public Task<List<T>> GetItemsAsync<T>() where T : new() {
            if (typeof(T) == typeof(User)) {
                // Return Users
                return Task.FromResult(Users as List<T>);
            } else if (typeof(T) == typeof(Role)) {
                // Return Roles
                return Task.FromResult(Roles as List<T>);
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
