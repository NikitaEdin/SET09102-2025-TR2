

using System.ComponentModel.DataAnnotations;
using SQLite;
namespace REA.Models
{
    [Table("Sensors")]
    public class Sensors
    {
        [PrimaryKey, AutoIncrement]
        [Column("sensor_id")]
        public int SensorId {  get; set; }
        [Column("site_id")]
        public int SiteId { get; set; }
        [Column("sensor_type")]
        public string SensorType { get; set; }
        [Column("sensor_url")]
        public string SensorUrl { get; set; }
        [Column("deployment_date")]
        public string DeploymentDate { get; set; }
        [Column("sensor_operational")]
        public bool SensorOperational { get; set; }

    }
}
