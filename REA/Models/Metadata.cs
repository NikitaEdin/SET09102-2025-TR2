using SQLite;

namespace REA.Models {
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
    }
}
