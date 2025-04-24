
using SQLite;
namespace REA.Models {
    /// <summary>
    /// Represents a record of water quality measurements
    /// </summary>
    /// 
    /// \author Nikita Lanetsky
    [Table("WaterMeasurements")]
    public class WaterMeasurement {

        /// <summary>Unique identifier for  water measurement entry</summary>
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int WaterMeasurementId { get; set; }

        /// <summary>Date and time of the measurement</summary>
        public string Datetime { get; set; }

        /// <summary>Nitrate concentration</summary>
        public double? Nitrate { get; set; }

        /// <summary>Nitrite concentration</summary>
        public double? Nitrite { get; set; }

        /// <summary>Phosphate concentration</summary>
        public double? Phosphate { get; set; }

        /// <summary>Electrical conductivity</summary>
        public double? EC { get; set; }

        /// <summary>Reference to the Metadata by its ID</summary>
        public int? Metadata { get; set; }


        /// <summary>
        /// Returns a string representation of the record
        /// </summary>
        /// <returns>String containing all record's attributes</returns>
        public override string ToString() {
            return $"ID: {WaterMeasurementId}, " +
                   $"DateTime: {Datetime}, " +
                   $"Nitrate: {(Nitrate.HasValue ? Nitrate.Value.ToString("F2") : "null")}, " +
                   $"Nitrite: {(Nitrite.HasValue ? Nitrite.Value.ToString("F2") : "null")}, " +
                   $"Phosphate: {(Phosphate.HasValue ? Phosphate.Value.ToString("F2") : "null")}, " +
                   $"EC: {(EC.HasValue ? EC.Value.ToString("F2") : "null")}, " +
                   $"Metadata ID: {(Metadata.HasValue ? Metadata.Value.ToString() : "null")}";
        }
    }
}
