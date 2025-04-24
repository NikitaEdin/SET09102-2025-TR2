using REA.DB;
using SQLite;

namespace REA.Models {
    /// <summary>
    /// Represents a "Metadata" record for measured quantity or sensor attribute
    /// </summary>
    /// 
    /// \author Nikita Lanetsky
    public class Metadata {

        /// <summary>Unique identifier for the metadata entry</summary>
        [PrimaryKey, AutoIncrement]
        [Column("metadata_id")]
        public int ID { get; set; }

        /// <summary>Category of the metadata (e.g. air, water)</summary>
        [NotNull]
        public string Category { get; set; }

        /// <summary>Name of quantity being described</summary>

        [NotNull]
        public string Quantity { get; set; }

        /// <summary>Symbol representing the quantity</summary>
        [NotNull]
        public string Symbol { get; set; }

        /// <summary>Unit of measurement for quantity</summary>
        [NotNull]
        public string Unit { get; set; }

        /// <summary>Description of the unit of measurement</summary>
        public string Unit_desc { get; set; }

        /// <summary>Measurement frequency</summary>
        public string Measurement_freq { get; set; }

        /// <summary>Recommended safe level for the measurement</summary>
        public double? Safe_level { get; set; }

        /// <summary>Name of associated sensor</summary>
        public string Sensor { get; set; }

        /// <summary>Reference URL for additional info</summary>
        public string Reference_url { get; set; }

        /// <summary>Reference(ID) of associated sensor (if any)</summary>
        public int? Sensor_ID { get; set; }

        /// <summary>
        /// Returns a string representation of the record
        /// </summary>
        /// <returns>String containing all record's attributes</returns>
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
