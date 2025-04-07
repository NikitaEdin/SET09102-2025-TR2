
using System.ComponentModel.DataAnnotations;
using SQLite;
namespace REA.Models
{
    [Table("Configuration")]
    public class Configuration
    {
        [PrimaryKey,AutoIncrement]
        [Column("config_id")]
        public int ConfigId { get; set; }
        [Column("sensor_id")]
        public int SensorId { get; set; }
        [Column("min_measurement")]
        public float MinMeasurement { get; set; }
        [Column("max_measurement")]
        public float MaxMeasurement { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("firmware")]
        public float Firmware { get; set; }

    }
}
