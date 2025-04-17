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
    /// Unit testing for MaintenanceDetailsViewModel
    /// Author: Ramsay Foy
    /// </summary>
    public class MaintenanceDetailsViewModelTests
    {
        /// <summary>
        /// Test applying query attributes to the view model and ensure virtual fields resolve correctly
        /// </summary>
        [Fact]
        public void ApplyQueryAttributesTest_Valid()
        {
            // Create a fake database service and initialize the ViewModel
            var fakeDb = new FakeDatabaseService();
            var vm = new MaintenanceDetailsViewModel(fakeDb);

            // Create a maintenance object with test data
            var scheduledDate = DateTime.Now;
            var maintenance = new Maintenance()
            {
                Name = "Sensor Calibration",
                ScheduledDate = scheduledDate.ToString("yyyy-MM-dd hh:mm:ss"),
                AssignedUser = 2,
                Type = "Calibration"
            };

            // Create a dictionary to simulate the query attributes
            var query = new Dictionary<string, object>
            {
                { "Maintenance", maintenance }
            };

            vm.ApplyQueryAttributes(query);

            // Check if the properties are set correctly
            Assert.Equal(maintenance.Name, vm.Name);
            Assert.Equal(maintenance.GetScheduledAtDateTime().ToString("g"), vm.ScheduledAt);
            Assert.Equal(maintenance.AssignedUser.ToString(), vm.AssignedUser);
            Assert.Equal(maintenance.Type, vm.Type);
        }
    }
}
