using REA.DB;
using REA.Models;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests.ViewModels {
    /// <summary>
    /// Unit tests for HistoricalData ViewModel
    /// Author: Nikita Lanetsky
    /// </summary>
    public class HistoricalDataViewModelTests {

        /// <summary>
        /// Tests the population of records in the VM and compares with the actual database data (if any)
        /// </summary>
        [Fact]
        public async Task Populate_HistoricalData() {
            // Arrange
            IDatabaseService fakeDb = new FakeDatabaseService();
            var vm = new HistoricalDataViewModel(fakeDb);

            var airMeasurements = await fakeDb.GetItemsAsync<AirMeasurement>();
            var waterMeasurements = await fakeDb.GetItemsAsync<WaterMeasurement>();
            var weatherMeasurements = await fakeDb.GetItemsAsync<WeatherMeasurement>();

            // Act
            await vm.PopulateRecords();

            // Assert - Air
            Assert.Equal(airMeasurements.Count, vm.AirMeasurements.Count);
            for (int i = 0; i < airMeasurements.Count; i++) {
                Assert.Equal(airMeasurements[i].AirMeasurementsId, vm.AirMeasurements[i].AirMeasurementsId);
            }

            // Assert - Water
            Assert.Equal(waterMeasurements.Count, vm.WaterMeasurements.Count);
            for (int i = 0; i < waterMeasurements.Count; i++) {
                Assert.Equal(waterMeasurements[i].WaterMeasurementId, vm.WaterMeasurements[i].WaterMeasurementId);
            }

            // Assert - Weather
            Assert.Equal(weatherMeasurements.Count, vm.WeatherMeasurements.Count);
            for (int i = 0; i < weatherMeasurements.Count; i++) {
                Assert.Equal(weatherMeasurements[i].WeatherMeasurementsId, vm.WeatherMeasurements[i].WeatherMeasurementsId);
            }
        }
    }
}
