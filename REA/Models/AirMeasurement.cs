﻿using REA.Models;
using SQLite;

namespace REA.Models {
    /// <summary>
    /// Table for air measurements
    /// Author: Rachael
    /// </summary>
    [Table("AirMeasurements")]
    public class AirMeasurement {
        [PrimaryKey, AutoIncrement]
        [Column("air_measurements_id")]
        public int AirMeasurementsId { get; set; }

        [Column("date_time"),NotNull]
        public string DateTime { get; set; }

        [Column("nitrogen_dioxide")]
        public double? NitrogenDioxide { get; set; }

        [Column("sulphur_dioxide")]
        public double? SulphurDioxide { get; set; }

        [Column("pm2_5")]
        public double? PM2_5 { get; set; }

        [Column("pm10")]
        public double? PM10 { get; set; }

        [Column("metadata")]
        public int? Metadata { get; set; }
    }
}
