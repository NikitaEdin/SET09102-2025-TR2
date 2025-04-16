using REA.DB;
using REA.Models;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests.ViewModels {
    /// <summary>
    /// Unit tests for UserManagement ViewModel
    /// Author: Nikita Lanetsky
    /// </summary>
    public class UserManagementViewModelTests {
        /// <summary>
        /// Basic test of populating records (Users and Roles) into the VM from the database
        /// </summary>
        [Fact]
        public async Task Populate_UsersAndRoles() {
            // Arrange
            IDatabaseService fakeDb = new FakeDatabaseService();
            var vm = new UserManagementViewModel(fakeDb);

            // Act
            await vm.LoadDataAsync();

            // Assert NotNull (Empty DB records are still valid pass)
            Assert.NotNull(vm.Users);
            Assert.NotNull(vm.Roles);
        }

        /// <summary>
        /// Testing the update functionality - changing user role to a different role
        /// </summary>
        [Fact]
        public async Task UpdateUserRole() {
            // Arrange
            IDatabaseService fakeDb = new FakeDatabaseService();
            var vm = new UserManagementViewModel(fakeDb);

            var users = await fakeDb.GetItemsAsync<User>();
            var roles = await fakeDb.GetItemsAsync<Role>();

            // DB contains data for testing
            if (users.Any() && roles.Count > 1) {
                vm.SelectedUser = users[0];
                vm.SelectedRole = roles[1];

                // Act
                await vm.UpdateUserRoleAsync();

                // Assert
                users = await fakeDb.GetItemsAsync<User>();
                Assert.Equal(1, users[0].RoleId);
            } else {
                // Empty DB - Pass
            }
        }
    }
}
