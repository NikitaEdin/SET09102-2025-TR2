using REA.DB;
using REA.Models;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests.ViewModels {
    /// <summary>
    /// Unit tests for MonitorSensors ViewModel
    /// Author: Nikita Lanetsky
    /// </summary>
    public class MonitorSensorsViewModelTests {


        /// <summary>
        /// Tests the population of records in the vm and compares with the actual database data (if any)
        /// </summary>
        [Fact]
        public async Task Populate_Sensors() {
            // Arrange
            IDatabaseService fakeDb = new FakeDatabaseService();
            var vm = new MonitorSensorsViewModel(fakeDb);
            var expectedSensors = await fakeDb.GetItemsAsync<Sensors>();

            // Act
            await vm.GetSensors();

            // Assert NotNull (empty db records are still valid pass)
            Assert.NotNull(vm.Sensors);

            // Assert data structure
            Assert.Equal(expectedSensors.Count, vm.Sensors.Count);
            if (expectedSensors != null && expectedSensors.Count > 0 && expectedSensors.Count == vm.Sensors.Count) {
                for (int i = 0; i < expectedSensors.Count; i++) {
                    Assert.Equal(expectedSensors[i].SiteId, vm.Sensors[i].SiteId);
                }
            }

        }
    }
}
