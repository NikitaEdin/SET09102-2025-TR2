
using REA.DB;
using SQLite;
namespace REA.Models {
    /// <summary>
    /// Water Measurement Model holding record data of water related attributes
    /// Author: Nikita Lanetsky.
    /// </summary>
    [Table("WaterMeasurements")]
    public class WaterMeasurement {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        public string Datetime { get; set; }

        public double? Nitrate { get; set; }

        public double? Nitrite { get; set; }

        public double? Phosphate { get; set; }

        public double? EC { get; set; }

        public int? Metadata { get; set; } // Metadata table

        /// <summary>
        /// Retrieve all records from database of this type
        /// </summary>
        /// <returns>Return list of WaterMeasurements from DB</returns>
        public static async Task<List<WaterMeasurement>> GetAllWaterMeasurementsAsync() {
            var items = await SQLiteDatabaseService.Instance.GetItemsAsync<WaterMeasurement>();
            return items?.ToList() ?? new List<WaterMeasurement>();
        }

        /// <summary>
        /// Override the base ToString to print all object attributes
        /// </summary>
        /// <returns>String containing all object attributes</returns>
        public override string ToString() {
            return $"ID: {ID}, " +
                   $"DateTime: {Datetime}, " +
                   $"Nitrate: {(Nitrate.HasValue ? Nitrate.Value.ToString("F2") : "null")}, " +
                   $"Nitrite: {(Nitrite.HasValue ? Nitrite.Value.ToString("F2") : "null")}, " +
                   $"Phosphate: {(Phosphate.HasValue ? Phosphate.Value.ToString("F2") : "null")}, " +
                   $"EC: {(EC.HasValue ? EC.Value.ToString("F2") : "null")}, " +
                   $"Metadata ID: {(Metadata.HasValue ? Metadata.Value.ToString() : "null")}";
        }
    }
}
