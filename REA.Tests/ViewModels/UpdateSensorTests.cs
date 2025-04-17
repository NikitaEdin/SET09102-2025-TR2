using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REA.DB;
using REA.Models;
using REA.ViewModels;
using REA.Tests.Services;
using REA.Utils;
using Windows.Security.Cryptography.Core;
using System.Collections.ObjectModel;

namespace REA.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the UpdateSensorViewModel
    /// Author: Thomas Smith
    /// </summary>
    public class UpdateSensorTests
    {


        /// <summary>
        /// Test LoadConfig to populate collections with the mocked database.
        /// Currently does not use the method from the view model as the view model currently depends on the database
        /// </summary>
        [Fact]
        public async Task LoadConfigsTest_Valid()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new UpdateSensorViewModel(fakeDb);

            // Act
            await viewModel.LoadConfigs();

            // Assert

            // Air
            Assert.NotNull(viewModel.NitrogenDioxide);
            Assert.NotNull(viewModel.SulphurDioxide);
            Assert.NotNull(viewModel.ParticulateMatter);

            // Water
            Assert.NotNull(viewModel.Nitrate);
            Assert.NotNull(viewModel.Phosphate);
            Assert.NotNull(viewModel.EscherichiaColi);
            Assert.NotNull(viewModel.IntestinalEnterococci);

            // Weather
            Assert.NotNull(viewModel.AirTemperature);
            Assert.NotNull(viewModel.Humidity);
            Assert.NotNull(viewModel.WindSpeed);
            Assert.NotNull(viewModel.WindDirection);
        }

        /// <summary>
        /// Test LoadConfigs with an an empty database
        /// </summary>
        [Fact]
        public async Task LoadConfigsTest_EmptyDB()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();

            fakeDb.SetItems(new List<Configuration>()); // Populate with an empty list

            var viewModel = new UpdateSensorViewModel(fakeDb);

            // Act
            await viewModel.LoadConfigs();

            // Assert
            
            // Air
            Assert.Empty(viewModel.NitrogenDioxide);
            Assert.Empty(viewModel.SulphurDioxide);
            Assert.Empty(viewModel.ParticulateMatter);

            // Water
            Assert.Empty(viewModel.Nitrate);
            Assert.Empty(viewModel.Phosphate);
            Assert.Empty(viewModel.EscherichiaColi);
            Assert.Empty(viewModel.IntestinalEnterococci);

            // Weather
            Assert.Empty(viewModel.AirTemperature);
            Assert.Empty(viewModel.Humidity);
            Assert.Empty(viewModel.WindSpeed);
            Assert.Empty(viewModel.WindDirection);
        }

        /// <summary>
        /// Test the normal case of converting a string to a float
        /// </summary>
        [Fact]
        public void ConvertStringToFloatTest_Valid()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new UpdateSensorViewModel(fakeDb);

            float convertedFloat;
            string input = "0.2";

            // Act
            convertedFloat = viewModel.ConvertStringToFloat(input);

            // Assert
            Assert.IsType<float>(convertedFloat); 
        }

        /// <summary>
        /// Test the case if the method can handle incorrect formats for the input and handle the error with the try catch.
        /// </summary>
        [Fact]
        public void ConvertStringToFloatTest_Invalid() 
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new UpdateSensorViewModel(fakeDb);

            float convertedFloat;
            string input = "Hello World";

            // Act
            convertedFloat = viewModel.ConvertStringToFloat(input);

            // Assert
            Assert.IsType<float>(convertedFloat);
            Assert.Equal(0,convertedFloat); 
        }

        /// <summary>
        /// Test case to check if the method can handle null values 
        /// </summary>
        [Fact]
        public void ConvertStringToFloatTest_Null()
        {
            // Arrange
            var fakeDb = new FakeDatabaseService();
            var viewModel = new UpdateSensorViewModel(fakeDb);

            float convertedFloat;
            string input = null;

            // Act
            convertedFloat = viewModel.ConvertStringToFloat(input);

            // Assert
            Assert.NotNull(convertedFloat);
            Assert.Equal(0, convertedFloat); 
        }

    }
}
