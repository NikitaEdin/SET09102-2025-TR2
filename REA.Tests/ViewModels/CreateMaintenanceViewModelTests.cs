﻿using System;
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
    public class CreateMaintenanceViewModelTests
    {
        [Fact]
        public async Task SelectedUserTest_Valid()
        {
            var fakeDb = new FakeDatabaseService();
            var vm = new CreateMaintenanceViewModel();

            var users = await fakeDb.GetItemsAsync<User>();
            Assert.NotEmpty(users);

            var selectedUser = users.FirstOrDefault();
            Assert.NotNull(selectedUser);

            vm.UserSelected(selectedUser);

            Assert.Equal(selectedUser.UserID, vm.AssignedUser);
        }
    }
}
