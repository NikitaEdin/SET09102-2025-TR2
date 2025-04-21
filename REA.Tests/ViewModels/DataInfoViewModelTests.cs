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
    public class DataInfoViewModelTests {
        /// <summary>
        /// Test the view models function to fetch all user role counts from the database
        /// </summary>
        [Fact]
        public async Task LoadUserRoleCountsTest_Valid() {
            // Create view model
            var fakeDb = new FakeDatabaseService();
            var vm = new DataInfoViewModel(fakeDb);

            // Load user role counts
            await vm.LoadUserRoleCounts();

            // Assert that the list of role counts is not empty
            Assert.NotEmpty(vm.RoleCounts);


            // Get all users & roles from the database
            var users = await fakeDb.GetItemsAsync<User>();
            var roles = await fakeDb.GetItemsAsync<Role>();

            // Get the role counts
            var groupedUsers = users.GroupBy(u => u.RoleId)
                .Select(g => new Tuple<Role, int>(
                    roles.FirstOrDefault(r => r.RoleID == g.Key),
                    g.Count()))
                .ToList();

            // Assert that the role counts match
            Assert.Equal(groupedUsers.Count, vm.RoleCounts.Count);

            // Assert that the role counts match the expected values
            for (int i = 0; i < groupedUsers.Count; i++) {
                Assert.Equal(groupedUsers[i].Item1.RoleID, vm.RoleCounts[i].Item1.RoleID);
                Assert.Equal(groupedUsers[i].Item2, vm.RoleCounts[i].Item2);
            }
        }
    }
}
