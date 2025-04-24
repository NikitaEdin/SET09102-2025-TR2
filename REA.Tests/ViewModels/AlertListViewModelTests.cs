using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests.ViewModels {
    /// <summary>
    /// Unit testing for AlertListViewModel
    /// Author: Ramsay Foy
    /// </summary>
    public class AlertListViewModelTests {
        /// <summary>
        /// Test retrieval of all alerts from mocked database and ensure they are sorted correctly
        /// </summary>
        [Fact]
        public async Task LoadAlertsTest_Valid() {
            // Create a fake database service and initialize the ViewModel
            var fakeDb = new FakeDatabaseService();
            var vm = new AlertListViewModel(fakeDb);

            // Load alerts from the fake database
            await vm.LoadAlerts();

            // Check if the alert list is not empty
            Assert.NotEmpty(vm.Alerts);

            // Check if the alert list is sorted correctly
            var firstAlert = vm.Alerts.First();
            var lastAlert = vm.Alerts.Last();
            var firstTriggeredDate = firstAlert.GetTriggeredAtDateTime();
            var lastTriggeredDate = lastAlert.GetTriggeredAtDateTime();
            Assert.True(firstTriggeredDate >= lastTriggeredDate, "Alert list is not sorted correctly.");
        }
    }
}
