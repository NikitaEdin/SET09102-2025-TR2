using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.DB;
using REA.Models;
using REA.ViewModels;
using REA.Tests.Services;

namespace REA.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the UpdateSensorViewModel
    /// Author: Thomas Smith
    /// </summary>
    public class UpdateSensorTests
    {
        private readonly IDatabaseService fakeDb;
        private UpdateSensorViewModel viewModel;

        public UpdateSensorTests() 
        { 
            viewModel = new UpdateSensorViewModel();
            fakeDb = new FakeDatabaseService();
        }
    }
}
