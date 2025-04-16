using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.Tests.Services;
using REA.ViewModels;
using REA.DB;
using REA.Models;
using System.Collections.ObjectModel;
namespace REA.Tests.ViewModels
{
    public class ReportMalfunctioningSensorsViewModelTests
    {
        private List<Sensors> sensorsList;
        private List<Sensors> malfunctioningSensors;
        private List<Sensors> functioningSensors;

        [Fact]
        public async Task LoadSensorsTest_Valid()
        {
            // Arrange
            IDatabaseService fakeDb = new FakeDatabaseService();

            var sensors = await fakeDb.GetItemsAsync<Sensors>();

            sensorsList = new List<Sensors>(sensors);
            malfunctioningSensors = new List<Sensors>(sensors.Where(s=> !s.SensorOperational));
            functioningSensors = new List<Sensors>(sensors.Where(s => s.SensorOperational));

            // Act
            Assert.NotEmpty(sensors);
            Assert.NotEmpty(sensorsList);
            Assert.NotEmpty(malfunctioningSensors);
            Assert.NotEmpty(functioningSensors); 
            
        }

        [Fact]
        public async Task LoadSensorsTest_EmptyDB()
        {
            // Act
            var sensors = new List<Sensors>(); // Simulate the db being down by passing an empty list

            sensorsList = new List<Sensors>(sensors);
            malfunctioningSensors = new List<Sensors>(sensors.Where(s => !s.SensorOperational));
            functioningSensors = new List<Sensors>(sensors.Where(s => s.SensorOperational));

            // Assert
            Assert.Empty(sensorsList);
            Assert.Empty(malfunctioningSensors);
            Assert.Empty(functioningSensors);
        }

        [Fact]
        public async Task LoadSensorsTest_EmptyCollection()
        {
            // Arrange
            var sensors = new List<Sensors>
            {
                new Sensors { SensorId = 1, SiteId = 1, SensorType = "Air", SensorUrl = "https://airly.org/en/features/air-quality-sensors/", DeploymentDate = "2025-04-06", SensorOperational = true },
                new Sensors { SensorId = 5, SiteId = 2, SensorType = "Water", SensorUrl = "https://clearwatersensors.com/nitrate-sensor.html", DeploymentDate = "2023-01-01", SensorOperational = true }
            };

            // Act
            sensorsList = new List<Sensors>(sensors);
            malfunctioningSensors = new List<Sensors>(sensors.Where(s => !s.SensorOperational));
            functioningSensors = new List<Sensors>(sensors.Where(s => s.SensorOperational));

            // Assert
            Assert.NotEmpty(sensorsList);
            Assert.Empty(malfunctioningSensors); // This should be empty as all sensors are operational.
            Assert.NotEmpty(functioningSensors);
        }

        [Fact]
        public async Task CountSensorsTest_ValidAsync()
        {
            // Arrange
            ObservableCollection<Sensors> allSensors;
            ObservableCollection<Sensors> malfunctioningSensors;

            int expectedSensorCount = 3;
            int expectedSensorErrorCount = 1;

            IDatabaseService fakeDb = new FakeDatabaseService();

            var sensors =  await fakeDb.GetItemsAsync<Sensors>();
            var viewModel = new ReportMalfunctioningSensorsViewModel();

            allSensors = new ObservableCollection<Sensors>(sensors);
            malfunctioningSensors = new ObservableCollection<Sensors>(sensors.Where(s => !s.SensorOperational));

            // Act
            viewModel.CountSensors(allSensors, malfunctioningSensors);

            // Assert
            Assert.Equal(expectedSensorCount,allSensors.Count);
            Assert.Equal(expectedSensorErrorCount, malfunctioningSensors.Count);
        }

    }
}
