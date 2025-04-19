using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.Models;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests.ViewModels {
    /// <summary>
    /// Unit testing for DataInfoViewModel
    /// Author: Ramsay Foy
    /// </summary>
    public class EditRoleViewModelTests {
        /// <summary>
        /// Test that applying query attributes sets the role correctly
        /// </summary>
        [Fact]
        public void ApplyQueryAttributesTest_Valid() {
            // Create view model & fake db
            var fakeDb = new FakeDatabaseService();
            var vm = new EditRoleViewModel(fakeDb);

            // Create a role to edit
            var role = new Role {
                RoleID = 1,
                Title = "Admin",
                Power = 5
            };

            // Create & apply query attributes
            var query = new Dictionary<string, object> {
                { "Role", role }
            };

            vm.ApplyQueryAttributes(query);

            // Assert that the role is set correctly
            Assert.Equal(role.Title, vm.Title);
            Assert.Equal(role.Power, vm.Power);
        }

        /// <summary>
        /// Test the CanExecute method on the EditRoleCommand with valid input
        /// </summary>
        [Fact]
        public async void CanExecuteTest_Valid() {
            // Create view model & fake db
            var fakeDb = new FakeDatabaseService();
            var vm = new EditRoleViewModel(fakeDb);

            // Get a role to edit
            var roles = await fakeDb.GetItemsAsync<Role>();
            var role = roles.FirstOrDefault(r => r.RoleID == 1);

            // Create & apply query attributes
            var query = new Dictionary<string, object> {
                { "Role", role }
            };

            vm.ApplyQueryAttributes(query);

            // Set the power to a valid value
            vm.Power = 10;

            // Assert that the command can execute
            Assert.True(vm.EditRoleCommand.CanExecute(null));
        }

        /// <summary>
        /// Test the CanExecute method on the EditRoleCommand with invalid input
        /// </summary>
        [Fact]
        public async void CanExecuteTest_Invalid() {
            // Create view model & fake db
            var fakeDb = new FakeDatabaseService();
            var vm = new EditRoleViewModel(fakeDb);

            // Get a role to edit
            var roles = await fakeDb.GetItemsAsync<Role>();
            var role = roles.FirstOrDefault(r => r.RoleID == 1);

            // Create & apply query attributes
            var query = new Dictionary<string, object> {
                { "Role", role }
            };

            vm.ApplyQueryAttributes(query);

            // Set the power to an invalid value
            vm.Power = 0;

            // Assert that the command can execute
            Assert.False(vm.EditRoleCommand.CanExecute(null));
        }

        /// <summary>
        /// Test the EditRole method with valid input
        /// </summary>
        [Fact]
        public async void EditRoleTest_Valid() {
            // Create view model & fake db
            var fakeDb = new FakeDatabaseService();
            var vm = new EditRoleViewModel(fakeDb);

            // Get a role to edit
            var roles = await fakeDb.GetItemsAsync<Role>();
            var role = roles.FirstOrDefault(r => r.RoleID == 1);

            // Create & apply query attributes
            var query = new Dictionary<string, object> {
                { "Role", role }
            };

            vm.ApplyQueryAttributes(query);

            // Set the power to a valid value
            vm.Power = 10;

            // Execute the command
            vm.EditRoleCommand.Execute(null);

            // Assert that the role was updated in the database
            roles = await fakeDb.GetItemsAsync<Role>();
            var updatedRole = roles.FirstOrDefault(r => r.RoleID == role.RoleID);

            Assert.NotNull(updatedRole);
            Assert.Equal(role.RoleID, updatedRole.RoleID);
            Assert.Equal(role.Title, updatedRole.Title);
            Assert.Equal(10, updatedRole.Power);
        }
    }
}
