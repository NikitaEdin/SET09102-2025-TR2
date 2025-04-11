using REA.DB;
using SQLite;

namespace REA.Models {
    /// <summary>
    /// Metadata model holding record data of metadata attributes
    /// Author: Nikita Lanetsky.
    /// </summary>
    public class Metadata {
        [PrimaryKey, AutoIncrement]
        [Column("metadata_id")]
        public int ID { get; set; }

        [NotNull]
        public string Category { get; set; }

        [NotNull]
        public string Quantity { get; set; }

        [NotNull]
        public string Symbol { get; set; }

        [NotNull]
        public string Unit { get; set; }

        public string Unit_desc { get; set; }

        public string Measurement_freq { get; set; }

        public double? Safe_level { get; set; }

        public string Sensor { get; set; }

        public string Reference_url { get; set; }

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
                   $"Category: {Category}, " +
                   $"Quantity: {Quantity}, " +
                   $"Symbol: {Symbol}, " +
                   $"Unit: {Unit}, " +
                   $"Unit Description: {(string.IsNullOrEmpty(Unit_desc) ? "null" : Unit_desc)}, " +
                   $"Measurement Frequency: {(string.IsNullOrEmpty(Measurement_freq) ? "null" : Measurement_freq)}, " +
                   $"Safe Level: {(Safe_level.HasValue ? Safe_level.Value.ToString("F2") : "null")}, " +
                   $"Sensor: {(string.IsNullOrEmpty(Sensor) ? "null" : Sensor)}, " +
                   $"Reference URL: {(string.IsNullOrEmpty(Reference_url) ? "null" : Reference_url)}, " +
                   $"Sensor ID: {(Sensor_ID.HasValue ? Sensor_ID.Value.ToString() : "null")}";
        }

    }
}
