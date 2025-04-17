using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.DB;
using REA.Models;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests.ViewModels
{
    /// <summary>
    /// Unit testing for CreateMaintenanceViewModel
    /// Author: Ramsay Foy
    /// </summary>
    public class CreateMaintenanceViewModelTests {
        /// <summary>
        /// Test applying the selected user to the AssignedUser property and check if it is set correctly
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SelectedUserTest_Valid() {
            // Create view model
            var fakeDb = new FakeDatabaseService();
            var vm = new CreateMaintenanceViewModel(fakeDb);

            // Get users from the fake database for testing, not representative of view model logic
            var users = await fakeDb.GetItemsAsync<User>();
            Assert.NotEmpty(users);

            var selectedUser = users.FirstOrDefault();
            Assert.NotNull(selectedUser);

            // Select the user
            vm.UserSelected(selectedUser);

            // Assert it's correct
            Assert.Equal(selectedUser.UserID, vm.AssignedUser);
        }

        /// <summary>
        /// Test the view models function to fetch all users from the database
        /// </summary>
        [Fact]
        public async Task LoadUsersTest_Valid() {
            // Create view model
            var fakeDb = new FakeDatabaseService();
            var vm = new CreateMaintenanceViewModel(fakeDb);

            // Load users
            await vm.LoadUsers();

            // Assert that the list of available users is not empty
            Assert.NotEmpty(vm.AvailableUsers);
        }

        /// <summary>
        /// Test the create maintenance command with valid data
        /// </summary>
        [Fact]
        public async Task CreateMaintenanceTest_Valid() {
            // Create view model
            var fakeDb = new FakeDatabaseService();
            var vm = new CreateMaintenanceViewModel(fakeDb);

            // Set up the maintenance data
            vm.Name = "Test Maintenance";
            vm.ScheduledDate = DateTime.Now.AddDays(1);
            vm.AssignedUser = 1; // Assuming user with ID 1 exists
            vm.Type = "Check";

            // Execute the command
            vm.CreateMaintenanceCommand.Execute(null);

            // Assert that the maintenance was created successfully
            var maintenances = await fakeDb.GetItemsAsync<Maintenance>();
            Assert.NotEmpty(maintenances);

            var createdMaintenance = maintenances.FirstOrDefault(m => m.Name == vm.Name);
            Assert.NotNull(createdMaintenance);
        }

        /// <summary>
        /// Test the create maintenance command with invalid data
        /// </summary>
        [Fact]
        public async Task CreateMaintenanceTest_Invalid() {
            // Create view model
            var fakeDb = new FakeDatabaseService();
            var vm = new CreateMaintenanceViewModel(fakeDb);
            // Set up the maintenance data with invalid values

            vm.Name = "";
            vm.ScheduledDate = DateTime.Now.AddDays(-1); // Past date
            vm.AssignedUser = 0; // No user selected
            vm.Type = null;

            // Execute the command
            vm.CreateMaintenanceCommand.Execute(null);

            // Assert that no maintenance was created
            var maintenances = await fakeDb.GetItemsAsync<Maintenance>();
            var createdMaintenance = maintenances.FirstOrDefault(m => m.Name == vm.Name);
            Assert.Null(createdMaintenance);
        }
    }
}
