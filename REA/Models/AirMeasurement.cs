using REA.DB;
using SQLite;

namespace REA.Models
{
    /// <summary>
    /// Air Measurement model representing air quality data.
    /// Author: Rachael Banks
    /// </summary>
    [Table("air_measurements")]
    public class AirMeasurement
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public string? date_time { get; set; }

        public double? Nitrogen_Dioxide { get; set; }

        public double? Sulphur_Dioxide { get; set; }

        public double? PM2_5 { get; set; }

        public double? PM10 { get; set; }

        public int? metadata { get; set; }  // Foreign key to Metadata table

        /// <summary>
        /// Retrieves all air measurements from the local SQLite database.
        /// </summary>
        public static async Task<List<AirMeasurement>> GetAllAsync() {
            return await SQLiteDatabaseService.Instance.GetItemsAsync<AirMeasurement>() ?? new List<AirMeasurement>();
        }

        /// <summary>
        /// Returns a string of the air measurement object.
        /// </summary>
        public override string ToString() {
            return $"ID: {ID}, " +
                   $"Datetime: {date_time}, " +
                   $"NO₂: {(Nitrogen_Dioxide?.ToString("F2") ?? "null")} µg/m³, " +
                   $"SO₂: {(Sulphur_Dioxide?.ToString("F2") ?? "null")} µg/m³, " +
                   $"PM2.5: {(PM2_5?.ToString("F2") ?? "null")} µg/m³, " +
                   $"PM10: {(PM10?.ToString("F2") ?? "null")} µg/m³, " +
                   $"Metadata ID: {(metadata?.ToString() ?? "null")}";
        }
    }
}
