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
using System.Collections.ObjectModel;

namespace REA.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the GenerateReportsViewModel
    /// Author: Thomas Smith
    /// </summary>
    public class GenerateReportsViewModelTests
    {
        /// <summary>
        /// Test LoadMeasurements to populate collections with the mocked database
        /// </summary>
        [Fact]
        public async Task LoadMeasurementsTest_Valid()
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

        /// <summary>
        /// Test LoadMeasurements with an empty list to simulate an empty db with no entries
        /// </summary>
        [Fact]
        public async Task LoadMeasurementsTest_EmptyDB()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new GenerateReportsViewModel(fakeDb);

            // Populate with an empty list for each of the models
            fakeDb.SetItems(new List<AirMeasurement>());
            fakeDb.SetItems(new List<WaterMeasurement>());
            fakeDb.SetItems(new List<WeatherMeasurement>());

            // Act
            await viewModel.LoadMeasurements();

            // Assert
            Assert.Empty(viewModel.airMeasurements);
            Assert.Empty(viewModel.waterMeasurements);
            Assert.Empty(viewModel.weatherMeasurements);
        }

        /// <summary>
        /// Tests CalculateAverage with double values in a collection to return the average
        /// </summary>
        [Fact]
        public void CalculateAverageTest_Valid()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new GenerateReportsViewModel(fakeDb);

            var collection = new ObservableCollection<double>();
            collection.Add(10.00);
            collection.Add(20.55);

            // Act
            var collectionAverage = viewModel.CalculateAverage(collection);

            // Assert
            Assert.NotEqual(0, collectionAverage);

        }
        /// <summary>
        /// Tests CalculateAverage with a string value to test its robustness 
        /// </summary>
        [Fact]
        public void CalculateAverageTest_Invalid()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new GenerateReportsViewModel(fakeDb);

            var collection = new ObservableCollection<string>();
            collection.Add("Hello");

            // Act
            var collectionAverage = viewModel.CalculateAverage(collection);

            // Assert
            Assert.Equal(0, collectionAverage);

        }
    }
}
