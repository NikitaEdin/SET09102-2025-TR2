using REA.DB;
using SQLite;

namespace REA.Models
{
    /// <summary>
    /// Weather Measurement model representing weather data.
    /// Author: Rachael Banks
    /// </summary>
    [Table("weather_measurements")]
    public class WeatherMeasurement {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public string? date_time { get; set; }

        public double? temperature_2m { get; set; }

        public double? relative_humidity_2m { get; set; }

        public double? wind_speed_10m { get; set; }

        public double? wind_direction_10m { get; set; }

        public int? metadata { get; set; }  // Foreign key to Metadata table

        /// <summary>
        /// Retrieves all weather measurements from the local SQLite database.
        /// </summary>
        public static async Task<List<WeatherMeasurement>> GetAllAsync() {
            return await SQLiteDatabaseService.Instance.GetItemsAsync<WeatherMeasurement>() ?? new List<WeatherMeasurement>();
        }

        /// <summary>
        /// Returns a string representation of the weather measurement object.
        /// </summary>
        public override string ToString() {
            return $"ID: {ID}, " +
                   $"Datetime: {date_time}, " +
                   $"Temperature: {(temperature_2m?.ToString("F1") ?? "null")}°C, " +
                   $"Humidity: {(relative_humidity_2m?.ToString("F1") ?? "null")}%, " +
                   $"Wind Speed: {(wind_speed_10m?.ToString("F1") ?? "null")} m/s, " +
                   $"Wind Direction: {(wind_direction_10m?.ToString("F1") ?? "null")}°, " +
                   $"Metadata ID: {(metadata?.ToString() ?? "null")}";
        }
    }
}
