using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.Models;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests.ViewModels
{
    /// <summary>
    /// Unit testing for ManageMaintenanceViewModel
    /// Author: Ramsay Foy
    /// </summary>
    public class ManageMaintenanceViewModelTests
    {

        /// <summary>
        /// Test retrieval of all maintenance records from mocked database and ensure they are sorted correctly
        /// </summary>
        [Fact]
        public async Task LoadMaintenanceTest_Valid()
        {
            // Create a fake database service and initialize the ViewModel
            var fakeDb = new FakeDatabaseService();
            var vm = new ManageMaintenanceViewModel(fakeDb);

            // Load maintenance records from the fake database
            await vm.LoadMaintenance();

            // Check if the maintenance list is not empty
            Assert.NotEmpty(vm.MaintenanceList);

            // Check if the maintenance list is sorted correctly
            var firstMaintenance = vm.MaintenanceList.First();
            var lastMaintenance = vm.MaintenanceList.Last();

            var firstScheduledDate = firstMaintenance.GetScheduledAtDateTime();
            var lastScheduledDate = lastMaintenance.GetScheduledAtDateTime();

            Assert.True(firstScheduledDate >= lastScheduledDate, "Maintenance list is not sorted correctly.");
        }
    }
}
