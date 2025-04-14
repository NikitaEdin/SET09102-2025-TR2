using REA.Models;
using REA.ViewModels;


namespace REA.Tests {
    public class LoginViewModelTests {
        /// <summary>
        /// Test ValidateUser - correct credentials
        /// </summary>
        [Fact]
        public void ValidateUser_WithCorrectCredentials_ReturnsUser() {
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
        public void ValidateUser_WithIncorrectCredentials_ReturnsNull() {
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
    }
}
