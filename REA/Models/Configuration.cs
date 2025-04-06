
namespace REA.Models
{
    public class Configuration
    {
        public int configID { get; set; }
        public int sensorID { get; set; }
        public float minMeasurement { get; set; }
        public float maxMeasurement { get; set; }
        public string type { get; set; }
        public float firmware { get; set; }

    }
}
