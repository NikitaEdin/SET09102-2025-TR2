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
        [Fact]
        public async Task LoadSensorsTest_Valid()
        {
            // Arrange
            List<Sensors> sensorsList;
            List<Sensors> malfunctioningSensors;
            List<Sensors> functioningSensors;
           

            var viewModel = new ReportMalfunctioningSensorsViewModel();

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
        public async Task LoadSensorsTest_Invalid()
        {
            // Arrange
            List<Sensors> sensorsList;
            List<Sensors> malfunctioningSensors;
            List<Sensors> functioningSensors;


            var viewModel = new ReportMalfunctioningSensorsViewModel();

            IDatabaseService fakeDb = new FakeDatabaseService();

            var sensors = await fakeDb.GetItemsAsync<Sensors>();

            sensorsList = new List<Sensors>(); // This is an empty list to test the logic for handling the case if the database returns nothing
            malfunctioningSensors = new List<Sensors>(sensors.Where(s => !s.SensorOperational));
            functioningSensors = new List<Sensors>(sensors.Where(s => s.SensorOperational));

            // Act
            Assert.NotEmpty(sensors);
            Assert.NotEmpty(sensorsList);
            Assert.NotEmpty(malfunctioningSensors);
            Assert.NotEmpty(functioningSensors);
        }

    }
}
