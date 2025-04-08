using REA.DB;
using SQLite;

namespace REA.Models {
    /// <summary>
    /// Metadata model holding record data of metadata attributes
    /// Author: Nikita Lanetsky.
    /// </summary>
    public class Metadata {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public string category { get; set; }

        [NotNull]
        public string quantity { get; set; }

        [NotNull]
        public string symbol { get; set; }

        [NotNull]
        public string unit { get; set; }

        public string unit_drescription { get; set; }

        public string measurement_freq { get; set; }

        public double? safe_level { get; set; }

        public string Sensor { get; set; }

        public string reference_url { get; set; }

        public int? Sensor_ID { get; set; }


        /// <summary>
        /// Retrieve all records from database of this type
        /// </summary>
        /// <returns>Return list of MetaData from DB</returns>
        public static async Task<List<Metadata>> GetAllMetadataAsync() {
            var items = await SQLiteDatabaseService.Instance.GetItemsAsync<Metadata>();
            return items?.ToList() ?? new List<Metadata>();
        }

        /// <summary>
        /// Override the base ToString to print all object attributes
        /// </summary>
        /// <returns>String containing all object attributes</returns>
        public override string ToString() {
            return $"ID: {ID}, " +
                   $"Category: {category}, " +
                   $"Quantity: {quantity}, " +
                   $"Symbol: {symbol}, " +
                   $"Unit: {unit}, " +
                   $"Unit Description: {(string.IsNullOrEmpty(unit_drescription) ? "null" : unit_drescription)}, " +
                   $"Measurement Frequency: {(string.IsNullOrEmpty(measurement_freq) ? "null" : measurement_freq)}, " +
                   $"Safe Level: {(safe_level.HasValue ? safe_level.Value.ToString("F2") : "null")}, " +
                   $"Sensor: {(string.IsNullOrEmpty(Sensor) ? "null" : Sensor)}, " +
                   $"Reference URL: {(string.IsNullOrEmpty(reference_url) ? "null" : reference_url)}, " +
                   $"Sensor ID: {(Sensor_ID.HasValue ? Sensor_ID.Value.ToString() : "null")}";
        }

    }
}
