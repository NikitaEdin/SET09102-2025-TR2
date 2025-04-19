using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.ViewModels;

namespace REA.Tests.ViewModels {
    /// <summary>
    /// Unit testing for AlertDetailsViewModel
    /// Author: Ramsay Foy
    /// </summary>
    public class AlertDetailsViewModelTests {
        /// <summary>
        /// Test applying query attributes to the ViewModel and ensure properties are set correctly
        /// </summary>
        [Fact]
        public void ApplyQueryAttributesTest_Valid() {
            // Create a new instance of the ViewModel
            var vm = new AlertDetailsViewModel();

            // Create a fake alert to test with
            var fakeAlert = new REA.Models.Alert {
                Metadata_ID = 1,
                Message = "Test Alert",
                TriggeredAt = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
            };

            var queryAttributes = new Dictionary<string, object> {
                { "Alert", fakeAlert }
            };

            // Apply the query attributes to the ViewModel
            vm.ApplyQueryAttributes(queryAttributes);

            // Check if the properties are set correctly
            Assert.Equal(fakeAlert.Metadata_ID.ToString(), vm.Metadata);
            Assert.Equal(fakeAlert.Message, vm.Message);
            Assert.Equal(fakeAlert.GetTriggeredAtDateTime().ToString("g"), vm.TriggeredAt);
        }
    }
}
