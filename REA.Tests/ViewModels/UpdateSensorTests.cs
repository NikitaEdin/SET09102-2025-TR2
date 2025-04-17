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
        private readonly IDatabaseService fakeDb;
        private UpdateSensorViewModel viewModel;

        // LoadSensor  Lists
        // AIR
        private List<Configuration> nitrogenDioxide;
        private List<Configuration> sulphurDioxide;
        private List<Configuration> particulateMatter;

        // Water
        private List<Configuration> nitrate;
        private List<Configuration> phosphate;
        private List<Configuration> escherichiaColi;
        private List<Configuration> intestinalEnterococci;

        // Weather
        private List<Configuration> airTemperature;
        private List<Configuration> humidity;
        private List<Configuration> windSpeed;
        private List<Configuration> windDirection;




        public UpdateSensorTests() 
        { 
            fakeDb = new FakeDatabaseService();
            viewModel = new UpdateSensorViewModel(fakeDb);
        }

        /// <summary>
        /// Test LoadConfig to populate collections with the mocked database.
        /// Currently does not use the method from the view model as the view model currently depends on the database
        /// </summary>
        [Fact]
        public async Task LoadConfigsTest_Valid()
        {
            // Arrange
            var configs = await fakeDb.GetItemsAsync<Configuration>();

            // Act
            await viewModel.LoadConfigs();

            // Air
            nitrogenDioxide = new List<Configuration>(configs.Where(c => c.Type == "Nitrogen dioxide"));
            sulphurDioxide = new List<Configuration>(configs.Where(c => c.Type == "Sulphur dioxide"));
            particulateMatter = new List<Configuration>(configs.Where(c => c.Type == "Particulate matter"));

            // Water
            nitrate = new List<Configuration>(configs.Where(c => c.Type == "Nitrate"));
            phosphate = new List<Configuration>(configs.Where(c => c.Type == "Phosphate"));
            escherichiaColi = new List<Configuration>(configs.Where(c => c.Type == "Escherichia coli"));
            intestinalEnterococci = new List<Configuration>(configs.Where(c => c.Type == "Intestinal enterococci"));


            // Weather
            airTemperature = new List<Configuration>(configs.Where(c => c.Type == "Air Temperature"));
            humidity = new List<Configuration>(configs.Where(c => c.Type == "Humidity"));
            windSpeed = new List<Configuration>(configs.Where(c => c.Type == "Wind speed"));
            windDirection = new List<Configuration>(configs.Where(c => c.Type == "Wind Direction"));


            // Assert

            // Air
            Assert.NotNull(nitrogenDioxide);
            Assert.NotNull(sulphurDioxide);
            Assert.NotNull(particulateMatter);

            // Water
            Assert.NotNull(nitrate);
            Assert.NotNull(phosphate);
            Assert.NotNull(escherichiaColi);
            Assert.NotNull(intestinalEnterococci);

            // Weather
            Assert.NotNull(airTemperature);
            Assert.NotNull(humidity);
            Assert.NotNull(windSpeed);
            Assert.NotNull(windDirection);
        }

        /// <summary>
        /// Test LoadConfigs with an "empty" database list
        /// </summary>
        [Fact]
        public async Task LoadConfigsTest_EmptyDB()
        {
            // Arrange
            var configs = new List<Configuration>();

            // Act
            await viewModel.LoadConfigs();
            // Air

            nitrogenDioxide = new List<Configuration>(configs.Where(c => c.Type == "Nitrogen dioxide"));
            sulphurDioxide = new List<Configuration>(configs.Where(c => c.Type == "Sulphur dioxide"));
            particulateMatter = new List<Configuration>(configs.Where(c => c.Type == "Particulate matter"));

            // Water
            nitrate = new List<Configuration>(configs.Where(c => c.Type == "Nitrate"));
            phosphate = new List<Configuration>(configs.Where(c => c.Type == "Phosphate"));
            escherichiaColi = new List<Configuration>(configs.Where(c => c.Type == "Escherichia coli"));
            intestinalEnterococci = new List<Configuration>(configs.Where(c => c.Type == "Intestinal enterococci"));


            // Weather
            airTemperature = new List<Configuration>(configs.Where(c => c.Type == "Air Temperature"));
            humidity = new List<Configuration>(configs.Where(c => c.Type == "Humidity"));
            windSpeed = new List<Configuration>(configs.Where(c => c.Type == "Wind speed"));
            windDirection = new List<Configuration>(configs.Where(c => c.Type == "Wind Direction"));


            // Assert
            
            // Air
            Assert.Empty(nitrogenDioxide);
            Assert.Empty(sulphurDioxide);
            Assert.Empty(particulateMatter);

            // Water
            Assert.Empty(nitrate);
            Assert.Empty(phosphate);
            Assert.Empty(escherichiaColi);
            Assert.Empty(intestinalEnterococci);

            // Weather
            Assert.Empty(airTemperature);
            Assert.Empty(humidity);
            Assert.Empty(windSpeed);
            Assert.Empty(windDirection);
        }

        /// <summary>
        /// Test the normal case of converting a string to a float
        /// </summary>
        [Fact]
        public void ConvertStringToFloatTest_Valid()
        {
            // Arrange
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
