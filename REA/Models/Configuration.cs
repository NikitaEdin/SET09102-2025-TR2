
using System.ComponentModel.DataAnnotations;
using SQLite;
namespace REA.Models
{
    /// <summary>
    /// Configuration Model 
    /// Author: Thomas Smith
    /// Last Updated: Thomas Smith: 10/04/25
    /// </summary>
    [Table("Configuration")]
    public class Configuration
    {
        [PrimaryKey,AutoIncrement]
        [Column("config_id")]
        public int ConfigId { get; set; }
        [Column("sensor_id")]
        public int SensorId { get; set; }
        [Column("min_measurement")]
        public string MinMeasurement { get; set; }
        [Column("max_measurement")]
        public string MaxMeasurement { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("firmware")]
        public string Firmware { get; set; }

    }
}
