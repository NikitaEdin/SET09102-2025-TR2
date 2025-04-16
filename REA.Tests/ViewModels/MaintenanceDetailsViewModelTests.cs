using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.Models;
using REA.ViewModels;

namespace REA.Tests.ViewModels
{
    public class MaintenanceDetailsViewModelTests
    {
        [Fact]
        public void ApplyQueryAttributesTest_Valid()
        {
            var vm = new MaintenanceDetailsViewModel();

            var scheduledDate = DateTime.Now;
            var maintenance = new Maintenance()
            {
                Name = "Sensor Calibration",
                ScheduledDate = scheduledDate.ToString("yyyy-MM-dd hh:mm:ss"),
                AssignedUser = 2,
                Type = "Calibration"
            };

            var query = new Dictionary<string, object>
            {
                { "Maintenance", maintenance }
            };

            vm.ApplyQueryAttributes(query);

            Assert.Equal("Sensor Calibration", vm.Name);
            Assert.Equal(maintenance.GetScheduledAtDateTime().ToString("g"), vm.ScheduledAt);
            Assert.Equal("2", vm.AssignedUser);
            Assert.Equal("Calibration", vm.Type);
        }
    }
}
