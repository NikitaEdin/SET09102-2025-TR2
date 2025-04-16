using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.Models;
using REA.Tests.Services;

namespace REA.Tests.ViewModels
{
    public class ManageMaintenanceViewModelTests
    {

        [Fact]
        public async Task LoadMaintenanceTest_Valid()
        {
            var fakeDb = new FakeDatabaseService();

            var maintenance = await fakeDb.GetItemsAsync<Maintenance>();

            Assert.NotEmpty(maintenance);

            maintenance = maintenance.OrderByDescending(m => m.GetScheduledAtDateTime()).ToList();

            // Check if the maintenance is sorted correctly
            Assert.NotEmpty(maintenance);
            Assert.Equal(3, maintenance.Count);
            Assert.Equal("Sensor Firmware Update", maintenance[0].Name);
            Assert.Equal("Sensor Replacement", maintenance[1].Name);
            Assert.Equal("Sensor Calibration", maintenance[2].Name);
        }
    }
}
