using REA.DB;
using REA.Models;
using REA.Tests.Services;
using REA.ViewModels;

namespace REA.Tests {
    /// <summary>
    /// Unit testing for Login Viewmodel back - authentication
    /// Author: Nikita Lanetsky
    /// </summary>
    public class LoginViewModelTests {
        /// <summary>
        /// Test ValidateUser - correct credentials
        /// </summary>
        [Fact]
        public void ValidateUser_Correct() {
            // Arrange (vm and dummy user)
            var vm = new LoginViewModel();
            var users = new List<User> {
                new User { Username = "admin", Password = "123" }
            };

            // Act
            var result = vm.ValidateUser(users, "admin", "123");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("admin", result.Username);
        }

        /// <summary>
        /// Test ValidateUser - incorrect credentials
        /// </summary>
        [Fact]
        public void ValidateUser_Incorrect() {
            // Arrange (vm and dummy user)
            var vm = new LoginViewModel();
            var users = new List<User> {
                new User { Username = "admin", Password = "123" }
            };

            // Act
            var result = vm.ValidateUser(users, "john", "smith");

            // Assert
            Assert.Null(result);
        }


        /// <summary>
        /// Test retrieval of all users from mocked database
        /// </summary>
        [Fact]
        public async Task Test_GetAllUsers() {
            IDatabaseService fakeDb = new FakeDatabaseService();
            var users = await fakeDb.GetItemsAsync<User>();

            // Assert
            if (users.Any()) {
                Assert.NotEmpty(users);
                Assert.Contains(users, u => u.Username == users.First().Username);
            } else {
                Assert.NotNull(users);
            }
        }


        /// <summary>
        /// Test ValidateUser with mocked database - correct credentials
        /// </summary>
        [Fact]
        public async Task ValidateUser_Correct_DB() {
            // Arrange (vm and dummy user)
            var vm = new LoginViewModel();
            IDatabaseService fakeDB = new FakeDatabaseService();
            var users = await fakeDB.GetItemsAsync<User>();

            // Assert integrity only if DB has data
            if (users.Any()) {
                // Act
                var result = vm.ValidateUser(users, users.First().Username, users.First().Password);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(users.First().Username, result.Username);
            }
        }

        /// <summary>
        /// Test ValidateUser with mocked database - incorrect credentials
        /// </summary>
        [Fact]
        public async void ValidateUser_Incorrect_DB() {
            // Arrange (vm and dummy user)
            var vm = new LoginViewModel();
            IDatabaseService fakeDB = new FakeDatabaseService();
            var users = await fakeDB.GetItemsAsync<User>();

            // Act
            var result = vm.ValidateUser(users, "john", "smith");

            // Assert
            Assert.Null(result);
        }
    }
}
