using SQLite;

namespace REA.Models {
    /// <summary>
    /// Table for weather measurements
    /// Author: Rachael
    /// </summary>
    [Table("WeatherMeasurements")]
    public class WeatherMeasurements {
        [PrimaryKey, AutoIncrement]
        [Column("weather_measurements_id")]
        public int WeatherMeasurementsId { get; set; }

        [Column("date_time"), NotNull]
        public required string DateTime { get; set; }

        [Column("temperature_2m")]
        public double? Temperature2m { get; set; }

        [Column("relative_humidity_2m")]
        public int? RelativeHumidity2m { get; set; }

        [Column("wind_speed_10m")]
        public double? WindSpeed10m { get; set; }

        [Column("wind_direction_10m")]
        public int? WindDirection10m { get; set; }

        [Column("metadata")]
        public int? Metadata { get; set; }  // Foreign key to Metadata table
    }
}
