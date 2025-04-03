
namespace REA.Models {
    public class Sensor {

        public int Id { get; set; }
        public string SensorType { get; set; }
        public string SensorUrl { get; set; }
        public DateTime DeploymentDate { get; set; }
        public bool IsOperational { get; set; }
    }
}
