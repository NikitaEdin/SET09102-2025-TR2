using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.DB;
using REA.Models;
using REA.ViewModels;
using REA.Utils;
using REA.Tests.Services;

namespace REA.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the GenerateReportsViewModel
    /// Author: Thomas Smith
    /// </summary>
    public class GenerateReportsViewModelTests
    {
        [Fact]
        public async Task LoadMeasurements_Valid()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new GenerateReportsViewModel(fakeDb);

            // Act
            await viewModel.LoadMeasurements();

            // Assert
            Assert.NotEmpty(viewModel.airMeasurements);
            Assert.NotEmpty(viewModel.waterMeasurements);
            Assert.NotEmpty(viewModel.weatherMeasurements);
        }
    }
}
